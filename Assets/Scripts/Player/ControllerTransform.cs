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
    [SerializeField] private Transform ramp;

    private bool isScale = false;

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
        // 스케일
        ScaleChange(SteamVR_Input_Sources.LeftHand, SteamVR_Input_Sources.RightHand, Controller.Instance.RightScalePos, Controller.Instance.LeftScalePos, Controller.Instance.IsRightScale, Controller.Instance.IsLeftScale, Controller.Instance.RightInst, Controller.Instance.LeftInst);

        if (isScale)
        {
            return;
        }
        
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
        
        //램프바닥
        TransformChange(SteamVR_Input_Sources.LeftHand, Controller.Instance.IsLeftRampBottomGrab, Controller.Instance.LeftRampBottomGrab, null);
        
        //램프탑
        TransformChange(SteamVR_Input_Sources.LeftHand, Controller.Instance.IsLeftRampTopGrab, Controller.Instance.LeftRampTopGrab, ramp);
        
        //루프
        TransformChange(SteamVR_Input_Sources.LeftHand, Controller.Instance.IsLeftLoopGrab, Controller.Instance.LeftLoopGrab, null);
    }

    void UpdateRight()
    {
        // 스케일
        ScaleChange(SteamVR_Input_Sources.LeftHand, SteamVR_Input_Sources.RightHand, Controller.Instance.RightScalePos, Controller.Instance.LeftScalePos, Controller.Instance.IsRightScale, Controller.Instance.IsLeftScale, Controller.Instance.RightInst, Controller.Instance.LeftInst);
        
        if (isScale)
        {
            return;
        }
        
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
        
        //램프바닥
        TransformChange(SteamVR_Input_Sources.RightHand, Controller.Instance.IsRightRampBottomGrab, Controller.Instance.RightRampBottomGrab, null);
        
        //램프탑
        TransformChange(SteamVR_Input_Sources.RightHand, Controller.Instance.IsRightRampTopGrab, Controller.Instance.RightRampTopGrab, ramp);
        
        //루프
        TransformChange(SteamVR_Input_Sources.RightHand, Controller.Instance.IsRightLoopGrab, Controller.Instance.RightLoopGrab, null);
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

            if (gameObject.transform.childCount > 0)
            {
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

    void ScaleChange(SteamVR_Input_Sources hand1, SteamVR_Input_Sources hand2, Vector3 rightScalePos, Vector3 leftScalePos, bool isRightScale, bool isLeftScale, GameObject rightObj, GameObject leftObj)
    {
        if (Controller.Instance.Grab.GetState(hand1) && Controller.Instance.Grab.GetState(hand2) && isRightScale && isLeftScale)
        {
            if (rightObj == null || leftObj == null)
            {
                Debug.LogError("Scale Obj is null");
                return;
            }
            
            if (rightObj == leftObj)
            {
                GameObject inst = rightObj;
                
                float instDist = Vector3.Distance(rightScalePos, leftScalePos);
                float clampinstDist = Mathf.Clamp01(instDist);
                Debug.Log(clampinstDist);

                float ballDist = Vector3.Distance(rightBall.transform.position, leftBall.transform.position);
                float clampBallDist = Mathf.Clamp01(ballDist);
                Debug.Log(clampBallDist);
                
                isScale = true;

                if (rightObj.transform.localScale.x >= 0.7f && rightObj.transform.localScale.x <= 1.0f)
                {
                    rightObj.transform.localScale = new Vector3(clampBallDist, clampBallDist, clampBallDist);
                }
                else if (rightObj.transform.localScale.x < 0.7f)
                {
                    rightObj.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                }
                else if (rightObj.transform.localScale.x > 1.0f)
                {
                    rightObj.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                }
            }
        }

        if (Controller.Instance.Grab.GetStateUp(hand1) || Controller.Instance.Grab.GetStateUp(hand2) && isScale)
        {
            isScale = false;

            Controller.Instance.RightScalePos = Vector3.zero;
            Controller.Instance.LeftScalePos = Vector3.zero;
            Controller.Instance.IsRightScale = false;
            Controller.Instance.IsLeftScale = false;
            Controller.Instance.RightInst = null;
            Controller.Instance.LeftInst = null;
        }
    }
}
