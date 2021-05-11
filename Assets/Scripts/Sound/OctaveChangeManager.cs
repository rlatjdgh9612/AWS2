using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OctaveChangeManager : MonoBehaviour
{
    #region 변수들

    // 옥타브를 바꾸고 싶은 오디오소스가 달린 오브젝트
    [SerializeField] private AudioSource sound;
    //

    private const int plus = 12;
    private const int minus = -12;

    private string[] split;
    private int changeIndex;
    private string path;

    #endregion
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            // 옥타브 + 1 버튼에 이 함수 실행
            // sound.clip은 넣을 오디오소스에 클립
            sound.clip = OctaveChange(PathFinder(sound.clip.name, plus));
            //
        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            // 옥타브 - 1 버튼에 이 함수 실행
            // sound.clip은 넣을 오디오소스에 클립
            sound.clip = OctaveChange(PathFinder(sound.clip.name, minus));
            //
        }
    }

    #region 함수들

    private string PathFinder(string soundName, int changeNum)
    {
        char slash = '/';
        
        foreach(SoundMenuData soundMenuData in SoundSystem.Instance.SoundMenu.SoundMenuData)
        {
            for (int i = 0; i < soundMenuData.instrumentSoundPath.Count; i++)
            {
                split = soundMenuData.instrumentSoundPath[i].Split(slash);

                if (split.Last() == soundName)
                {
                    changeIndex = OctaveMath(i, changeNum, soundMenuData.instrumentSoundPath.Count);
                    path = soundMenuData.instrumentSoundPath[changeIndex];
                }
            }
        }
        return path;
    }

    private int OctaveMath(int index, int changeNum, int count)
    {
        int reIndex = index + changeNum;
        
        if (reIndex < 0 || reIndex > count)
        {
            Debug.Log("Octave is too lower or higher");
            return index;
        }

        return reIndex;
    }

    private AudioClip OctaveChange(string resourcePath)
    {
        AudioClip audioClip = null;

        audioClip = Resources.Load<AudioClip>(resourcePath);
        if (!audioClip)
        {
            Debug.LogError("Resources Load Error! FilePath = " + resourcePath);
            return null;
        }

        return audioClip;
    }

    #endregion
    
}
