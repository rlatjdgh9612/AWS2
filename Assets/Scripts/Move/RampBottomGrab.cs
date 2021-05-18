using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampBottomGrab : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == Controller.WhichIsHand.rightHand)
        {
            Controller.Instance.IsRightRampBottomGrab = true;
            Controller.Instance.RightRampBottomGrab = this.transform.parent.gameObject;
        } 
        else if (other.gameObject.name == Controller.WhichIsHand.leftHand)
        {
            Controller.Instance.IsLeftRampBottomGrab = true;
            Controller.Instance.LeftRampBottomGrab = this.transform.parent.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == Controller.WhichIsHand.rightHand)
        {
            Controller.Instance.IsRightRampBottomGrab = false;
            Controller.Instance.RightRampBottomGrab = null;
        } 
        else if (other.gameObject.name == Controller.WhichIsHand.leftHand)
        {
            Controller.Instance.IsLeftRampBottomGrab = false;
            Controller.Instance.LeftRampBottomGrab = null;
        }
    }
}
