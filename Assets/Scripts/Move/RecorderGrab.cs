using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecorderGrab : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == Controller.WhichIsHand.rightHand)
        {
            Controller.Instance.IsRightRecorderGrab = true;
            Controller.Instance.RightRecorderGrab = this.gameObject.transform.parent.gameObject;
        } 
        else if (other.gameObject.name == Controller.WhichIsHand.leftHand)
        {
            Controller.Instance.IsLeftRecorderGrab = true;
            Controller.Instance.LeftRecorderGrab = this.gameObject.transform.parent.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == Controller.WhichIsHand.rightHand)
        {
            Controller.Instance.IsRightRecorderGrab = false;
            Controller.Instance.RightRecorderGrab = null;
        } 
        else if (other.gameObject.name == Controller.WhichIsHand.leftHand)
        {
            Controller.Instance.IsLeftRecorderGrab = false;
            Controller.Instance.LeftRecorderGrab = null;
        }
    }
}
