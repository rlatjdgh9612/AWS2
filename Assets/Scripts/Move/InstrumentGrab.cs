using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InstrumentGrab : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == Controller.WhichIsHand.rightHand)
        {
            Controller.Instance.IsRightPadGrab = true;
            Controller.Instance.RightGrabPad = this.gameObject.transform.parent.gameObject;
        } 
        else if (other.gameObject.name == Controller.WhichIsHand.leftHand)
        {
            Controller.Instance.IsLeftPadGrab = true;
            Controller.Instance.LeftGrabPad = this.gameObject.transform.parent.gameObject;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == Controller.WhichIsHand.rightHand)
        {
            Controller.Instance.IsRightPadGrab = true;
            Controller.Instance.RightGrabPad = this.gameObject.transform.parent.gameObject;
        } 
        else if (other.gameObject.name == Controller.WhichIsHand.leftHand)
        {
            Controller.Instance.IsLeftPadGrab = true;
            Controller.Instance.LeftGrabPad = this.gameObject.transform.parent.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == Controller.WhichIsHand.rightHand)
        {
            Controller.Instance.IsRightPadGrab = false;
            Controller.Instance.RightGrabPad = null;
        } 
        else if (other.gameObject.name == Controller.WhichIsHand.leftHand)
        {
            Controller.Instance.IsLeftPadGrab = false;
            Controller.Instance.LeftGrabPad = null;
        }
    }
}
