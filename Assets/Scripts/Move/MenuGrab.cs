using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuGrab : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == Controller.WhichIsHand.rightHand)
        {
            Controller.Instance.IsRightMenuGrab = true;
            Controller.Instance.RightMenuGrab = this.gameObject.transform.parent.gameObject;
        } 
        else if (other.gameObject.name == Controller.WhichIsHand.leftHand)
        {
            Controller.Instance.IsLeftMenuGrab = true;
            Controller.Instance.LeftMenuGrab = this.gameObject.transform.parent.gameObject;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == Controller.WhichIsHand.rightHand)
        {
            Controller.Instance.IsRightMenuGrab = true;
            Controller.Instance.RightMenuGrab = this.gameObject.transform.parent.gameObject;
        } 
        else if (other.gameObject.name == Controller.WhichIsHand.leftHand)
        {
            Controller.Instance.IsLeftMenuGrab = true;
            Controller.Instance.LeftMenuGrab = this.gameObject.transform.parent.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == Controller.WhichIsHand.rightHand)
        {
            Controller.Instance.IsRightMenuGrab = false;
            Controller.Instance.RightMenuGrab = null;
        } 
        else if (other.gameObject.name == Controller.WhichIsHand.leftHand)
        {
            Controller.Instance.IsLeftMenuGrab = false;
            Controller.Instance.LeftMenuGrab = null;
        }
    }
}
