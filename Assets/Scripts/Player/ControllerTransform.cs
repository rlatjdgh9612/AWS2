using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ControllerTransform : MonoBehaviour
{
    public enum HandState
    {
        None,
        Left,
        Right
    }

    public HandState handState = HandState.None;

    [SerializeField] private Transform leftBall;
    [SerializeField] private Transform rightBall;
    [SerializeField] private Transform instrumentParent;
    [SerializeField] private Transform menuParent;
    [SerializeField] private Transform sampleAudio;

    // Start is called before the first frame update
    void Start()
    {
        RightOrLeft();
    }
    
    private bool RightOrLeft()
    {
        if (gameObject.name == Controller.WhichIsHand.rightHand)
        {
            handState = HandState.Right;
            return true;
        }
        else if(gameObject.name == Controller.WhichIsHand.leftHand)
        {
            handState = HandState.Left;
            return true;
        }
        else
        {
            return false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (handState)
        {
            case HandState.Left:
                UpdateLeft();
                break;
            case HandState.Right:
                UpdateRight();
                break;
        }
    }

    void UpdateLeft()
    {
        // 악기
        TransformChange(SteamVR_Input_Sources.LeftHand, Controller.Instance.IsLeftPadGrab, Controller.Instance.LeftGrabPad, instrumentParent);
        
        // 메트로놈
        TransformChange(SteamVR_Input_Sources.LeftHand, Controller.Instance.IsLeftMetronomGrab, Controller.Instance.LeftMetronomGrab, null);
        
        // 레코더
        TransformChange(SteamVR_Input_Sources.LeftHand, Controller.Instance.IsLeftRecorderGrab, Controller.Instance.LeftRecorderGrab, null);
        
        // 메뉴
        TransformChange(SteamVR_Input_Sources.LeftHand, Controller.Instance.IsLeftMenuGrab, Controller.Instance.LeftMenuGrab, menuParent);
        
        // 샘플오디오
        TransformChange(SteamVR_Input_Sources.LeftHand, Controller.Instance.IsLeftSampleGrab, Controller.Instance.LeftSampleGrab, sampleAudio);
    }

    void UpdateRight()
    {
        // 악기
        TransformChange(SteamVR_Input_Sources.RightHand, Controller.Instance.IsRightPadGrab, Controller.Instance.RightGrabPad, instrumentParent);
        
        // 메트로놈
        TransformChange(SteamVR_Input_Sources.RightHand, Controller.Instance.IsRightMetronomGrab, Controller.Instance.RightMetronomGrab, null);
        
        // 레코더
        TransformChange(SteamVR_Input_Sources.RightHand, Controller.Instance.IsRightRecorderGrab, Controller.Instance.RightRecorderGrab, null);
        
        // 메뉴
        TransformChange(SteamVR_Input_Sources.RightHand, Controller.Instance.IsRightMenuGrab, Controller.Instance.RightMenuGrab, menuParent);
        
        // 샘플오디오
        TransformChange(SteamVR_Input_Sources.RightHand, Controller.Instance.IsRightSampleGrab, Controller.Instance.RightSampleGrab, sampleAudio);
    }

    void TransformChange(SteamVR_Input_Sources hand, bool isGrab, GameObject grabObject, Transform originParent)
    {
        if (Controller.Instance.Grab.GetState(hand) && isGrab)
        {
            if (grabObject == null)
            {
                Debug.LogError("Grab Object is null");
                return;
            }

            grabObject.transform.parent = gameObject.transform;
        }

        if (Controller.Instance.Grab.GetStateUp(hand) && isGrab)
        {
            grabObject.transform.parent = originParent;
            grabObject = null;
        }
    }
}
