using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Valve.VR;

public class ControllerTutor : MonoBehaviour
{
    [SerializeField] private GameObject rightBall;
    [SerializeField] private Transform tutorParent;
    [SerializeField] private Transform playerCam;

    private string _tutorPath;
    private string _tutorVideoPath;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Controller.Instance.Menu2.GetStateUp(SteamVR_Input_Sources.RightHand) && !Controller.Instance.IsPadTouch)
        {
            if (_tutorPath == String.Empty)
            {
                return;
            }
            
            TutorGenerate(Load(_tutorPath), TutorVideoLoad(_tutorVideoPath), tutorParent, false);
        }
    }

    void TutorGenerateFail()
    {
        
    }
    
    public void TutorInput(string tutorPath, string tutorVideoPath, bool isSelect)
    {
        _tutorPath = tutorPath;
        _tutorVideoPath = tutorVideoPath;
        
        rightBall.GetComponent<PlayerBall>().ColorChange(isSelect);
    }

    private GameObject Load(string resourcePath)
    {
        GameObject go = null;

        go = Resources.Load<GameObject>(resourcePath);

        if (!go)
        {
            Debug.LogError("Resources Load Error! FilePath = " + resourcePath);
            return null;
        }

        GameObject instancedGo = go;
        return instancedGo;
    }

    private VideoClip TutorVideoLoad(string resourcePath)
    {
        VideoClip video = null;

        video = Resources.Load<VideoClip>(resourcePath);

        if (!video)
        {
            Debug.LogError("Resources Load Error! FilePath = " + resourcePath);
            return null;
        }

        VideoClip instancedVideo = video;
        return instancedVideo;
    }
    
    public bool TutorGenerate(GameObject instancedGo, VideoClip instancedVideo, Transform parent, bool isSelect)
    {
        GameObject tutor = Instantiate<GameObject>(instancedGo, parent, true);
        string replaceName = tutor.name.Replace("(Clone)", "");
        tutor.name = replaceName;
        tutor.transform.position = rightBall.transform.position + rightBall.transform.forward * 0.25f;
        tutor.transform.localScale = Vector3.one;
        tutor.transform.forward = playerCam.transform.forward;
        tutor.transform.localEulerAngles = new Vector3(0.0f, tutor.transform.localEulerAngles.y, tutor.transform.localEulerAngles.z);
        tutor.GetComponent<VideoPlayer>().clip = instancedVideo;
        rightBall.GetComponent<PlayerBall>().ColorChange(isSelect);
        
        return true;
    }
}
