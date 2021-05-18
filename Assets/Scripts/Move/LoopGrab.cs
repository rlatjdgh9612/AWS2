//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class LoopGroup : MonoBehaviour
//{
//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.gameObject.name == Controller.WhichIsHand.rightHand)
//        {
//            Controller.Instance.IsRightLoopGrab = true;
//            Controller.Instance.RightLoopGrab = this.gameObject.transform.parent.transform.parent.gameObject;
//        }
//        else if (other.gameObject.name == Controller.WhichIsHand.leftHand)
//        {
//            Controller.Instance.IsLeftLoopGrab = true;
//            Controller.Instance.LeftLoopGrab = this.gameObject.transform.parent.transform.parent.gameObject;
//        }
//    }


//    private void OnTriggerExit(Collider other)
//    {
//        if (other.gameObject.name == Controller.WhichIsHand.rightHand)
//        {
//            Controller.Instance.IsRightLoopGrab = false;
//            Controller.Instance.RightLoopGrab = null;
//        }
//        else if (other.gameObject.name == Controller.WhichIsHand.leftHand)
//        {
//            Controller.Instance.IsLeftLoopGrab = false;
//            Controller.Instance.LeftLoopGrab = null;
//        }
//    }
//}
