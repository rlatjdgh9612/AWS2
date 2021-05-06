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
        if (Controller.Instance.Grab.GetState(SteamVR_Input_Sources.LeftHand) && Controller.Instance.IsLeftPadGrab)
        {
            if (Controller.Instance.LeftGrabPad == null)
            {
                Debug.LogError("GrabPad is null");
                return;
            }

            Controller.Instance.LeftGrabPad.transform.parent = gameObject.transform;
        }

        if (Controller.Instance.Grab.GetStateUp(SteamVR_Input_Sources.LeftHand) && Controller.Instance.IsLeftPadGrab)
        {
            Controller.Instance.LeftGrabPad.transform.parent = instrumentParent;
            Controller.Instance.LeftGrabPad = null;
        }
    }

    void UpdateRight()
    {
        if (Controller.Instance.Grab.GetState(SteamVR_Input_Sources.RightHand) && Controller.Instance.IsRightPadGrab)
        {
            if (Controller.Instance.RightGrabPad == null)
            {
                Debug.LogError("GrabPad is null");
                return;
            }
            
            Controller.Instance.RightGrabPad.transform.parent = gameObject.transform;
        }
        
        if (Controller.Instance.Grab.GetStateUp(SteamVR_Input_Sources.RightHand) && Controller.Instance.IsRightPadGrab)
        {
            Controller.Instance.RightGrabPad.transform.parent = instrumentParent;
            Controller.Instance.RightGrabPad = null;
        }
    }
}
