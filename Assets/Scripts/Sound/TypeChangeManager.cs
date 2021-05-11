using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TypeChangeManager : MonoBehaviour
{
    #region 변수들

    List<string> typeInst = new List<string>(3);
    
    // 타입 바꾸려고 하는 오디오소스
    [SerializeField] private AudioSource sound;
    //
    
    private string instName;
    private string typeName;
    private string typeFolder;
    private string resourcePath;

    private bool isActivate = false;
    
    private const string path = "Sounds";
    
    #endregion

    private void Start()
    {
        #region 시작시에 타입리스트 생성

        typeInst.Add("Bass");
        typeInst.Add("Guitar");
        typeInst.Add("Piano");

        #endregion
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // 실행 함수
            // 실행을 한다 (한번만 실행되게 하는게 중요. 업데이트이면 안 됨. 트리거 업이나 온 트리거 엔터만 가능. 아니면 계속 실행되서 안 됨)
            //★★★★★★★★★★★★★★★★★★★★★★ 어쨌거나 저쨌거나 이 함수를 실행하면 되고
            // 인자의 sound.clip.name 을 타입 바꾸려고 하는 오디오소스의 클립 이름으로 하면 된다
            // ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
            // 이 함수를 버튼 클릭시 실행되게 하면 된다
            
            TypeChange(TypeChangeParsing(sound.clip.name));
            
            //
        }
        //
    }

    #region 함수들

    private bool TypeChange(string resourcePath)
    {
        AudioClip soundClip = null;

        soundClip = Resources.Load<AudioClip>(resourcePath);

        if (!sound)
        {
            Debug.LogError("Resources Load Error! FilePath = " + resourcePath);
            return false;
        }

        sound.clip = soundClip;
        return true;
    }

    private string TypeChangeParsing(string clipName)
    {
        char slash = '/';
        char divide = '_';
        string[] splite = clipName.Split(divide);
        for (int i = 0; i < typeInst.Count; i++)
        {
            if (typeInst[i] == splite.First())
            {
                instName = typeInst[i];
                
                if (splite[1] == "Grand" || splite[1] == "Classic")
                {
                    typeFolder = instName + "Electric";
                    typeName = "Electric";
                } 
                else if (splite[1] == "Electric")
                {
                    typeFolder = instName + "Classic";
                    
                    if (instName == "Piano")
                    {
                        typeName = "Grand";
                    } 
                    else if (instName == "Guitar" || instName == "Bass")
                    {
                        typeName = "Classic";
                    }
                }
            }
        }

        resourcePath = path + slash + typeFolder + slash + instName + divide + typeName + divide + splite[2] +
                       divide + splite[3];

        Debug.Log(resourcePath);
        return resourcePath;
        
    }

    #endregion
    
}
