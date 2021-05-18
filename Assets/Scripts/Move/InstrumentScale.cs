using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentScale : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.name == "ScaleGrabRight")
        {
            if (other.gameObject.name == Controller.WhichIsHand.rightHand)
            {
                Controller.Instance.RightScalePos = transform.position;
                Controller.Instance.RightInst = transform.parent.gameObject;
                Controller.Instance.IsRightScale = true;
            }
        }

        if (this.gameObject.name == "ScaleGrabLeft")
        {
            if (other.gameObject.name == Controller.WhichIsHand.leftHand)
            {
                Controller.Instance.LeftScalePos = transform.position;
                Controller.Instance.LeftInst = transform.parent.gameObject;
                Controller.Instance.IsLeftScale = true;
            }
        }
    }
}
