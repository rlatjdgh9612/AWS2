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
    [SerializeField] private GameObject tutorMarker;

    private string _tutorPath;
    private string _tutorVideoPath;
    private bool _isMarker = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Controller.Instance.Menu2.GetStateUp(SteamVR_Input_Sources.RightHand) && !Controller.Instance.IsPadTouch)
        {
            if (_tutorPath == String.Empty || _tutorVideoPath == String.Empty)
            {
                return;
            }
            
            TutorGenerate(Load(_tutorPath), TutorVideoLoad(_tutorVideoPath), tutorParent, false);

            TutorGenerateFail(false);
        }

        if (tutorMarker != null)
        {
            tutorMarker.SetActive(_isMarker);
        }
    }

    void TutorGenerateFail(bool isSelect)
    {
        _tutorPath = String.Empty;

        _isMarker = false;
        rightBall.GetComponent<PlayerBall>().ColorChange(isSelect);
    }
    
    public void TutorInput(string tutorPath, string tutorVideoPath, bool isMarker, bool isSelect)
    {
        _tutorPath = tutorPath;
        _tutorVideoPath = tutorVideoPath;
        _isMarker = isMarker;
        
        rightBall.GetComponent<PlayerBall>().ColorChange(isSelect);
    }

    private GameObject Load(string resourcePath)
    {
        GameObject go = null;

        go = Resources.Load<GameObject>(resourcePath);

        if (!go)
        {
            Debug.Log("Resources Load Error! FilePath = " + resourcePath);
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
            Debug.Log("Resources Load Error! FilePath = " + resourcePath);
            return null;
        }

        VideoClip instancedVideo = video;
        return instancedVideo;
    }
    
    public bool TutorGenerate(GameObject instancedGo, VideoClip instancedVideo, Transform parent, bool isSelect)
    {
        if (instancedGo == null || instancedVideo == null)
        {
            return false;
        }
        
        GameObject tutor = Instantiate<GameObject>(instancedGo, parent, true);
        string replaceName = tutor.name.Replace("(Clone)", "");
        tutor.name = replaceName;
        tutor.transform.position = rightBall.transform.position + rightBall.transform.forward * 0.25f;
        tutor.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        tutor.transform.forward = playerCam.transform.forward;
        tutor.transform.localEulerAngles = new Vector3(0.0f, tutor.transform.localEulerAngles.y, tutor.transform.localEulerAngles.z);
        tutor.GetComponent<VideoPlayer>().clip = instancedVideo;
        rightBall.GetComponent<PlayerBall>().ColorChange(isSelect);
        _isMarker = false;
        
        return true;
    }
}
