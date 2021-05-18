using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetronomGrab : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == Controller.WhichIsHand.rightHand)
        {
            Controller.Instance.IsRightMetronomGrab = true;
            Controller.Instance.RightMetronomGrab = this.gameObject;
        } 
        else if (other.gameObject.name == Controller.WhichIsHand.leftHand)
        {
            Controller.Instance.IsLeftMetronomGrab = true;
            Controller.Instance.LeftMetronomGrab = this.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == Controller.WhichIsHand.rightHand)
        {
            Controller.Instance.IsRightMetronomGrab = false;
            Controller.Instance.RightMetronomGrab = null;
        } 
        else if (other.gameObject.name == Controller.WhichIsHand.leftHand)
        {
            Controller.Instance.IsLeftMetronomGrab = false;
            Controller.Instance.LeftMetronomGrab = null;
        }
    }
}
