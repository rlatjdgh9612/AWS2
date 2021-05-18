using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampTopGrab : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == Controller.WhichIsHand.rightHand)
        {
            Controller.Instance.IsRightRampTopGrab = true;
            Controller.Instance.RightRampTopGrab = this.gameObject;
        } 
        else if (other.gameObject.name == Controller.WhichIsHand.leftHand)
        {
            Controller.Instance.IsLeftRampTopGrab = true;
            Controller.Instance.LeftRampTopGrab = this.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == Controller.WhichIsHand.rightHand)
        {
            Controller.Instance.IsRightRampTopGrab = false;
            Controller.Instance.RightRampTopGrab = null;
        } 
        else if (other.gameObject.name == Controller.WhichIsHand.leftHand)
        {
            Controller.Instance.IsLeftRampTopGrab = false;
            Controller.Instance.LeftRampTopGrab = null;
        }
    }
}
