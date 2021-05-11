using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleAudioGrab : MonoBehaviour
{
    private LineRenderer line;
    
    private void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        UpdateLink();
    }

    void UpdateLink()
    {
        line.SetPosition(0, this.gameObject.transform.position);
        line.SetPosition(1, GetComponentInParent<SampleAudioVisualizer>().sampleNodes[0].gameObject.transform.position);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == Controller.WhichIsHand.rightHand)
        {
            Controller.Instance.IsRightSampleGrab = true;
            Controller.Instance.RightSampleGrab = this.gameObject.transform.parent.gameObject;
        } 
        else if (other.gameObject.name == Controller.WhichIsHand.leftHand)
        {
            Controller.Instance.IsLeftSampleGrab = true;
            Controller.Instance.LeftSampleGrab = this.gameObject.transform.parent.gameObject;
        }
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == Controller.WhichIsHand.rightHand)
        {
            Controller.Instance.IsRightSampleGrab = true;
            Controller.Instance.RightSampleGrab = this.gameObject.transform.parent.gameObject;
        } 
        else if (other.gameObject.name == Controller.WhichIsHand.leftHand)
        {
            Controller.Instance.IsLeftSampleGrab = true;
            Controller.Instance.LeftSampleGrab = this.gameObject.transform.parent.gameObject;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == Controller.WhichIsHand.rightHand)
        {
            Controller.Instance.IsRightSampleGrab = false;
            Controller.Instance.RightSampleGrab = null;
        } 
        else if (other.gameObject.name == Controller.WhichIsHand.leftHand)
        {
            Controller.Instance.IsLeftSampleGrab = false;
            Controller.Instance.LeftSampleGrab = null;
        }
    }
}
