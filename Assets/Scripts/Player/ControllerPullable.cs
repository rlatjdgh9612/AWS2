using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ControllerPullable : MonoBehaviour
{
    public GameObject metro;
    public GameObject recorder;
    public GameObject ramp;

    private void Update()
    {
        if (Controller.Instance.IsTitle == false)
        {
            if (Controller.Instance.GetMetro.GetStateDown(SteamVR_Input_Sources.LeftHand))
            {
                GetMetro();
                GetRamp();
            }
            if (Controller.Instance.GetRecorder.GetStateDown(SteamVR_Input_Sources.LeftHand)) GetRecorder();
        }
    }

    void GetMetro()
    {
        metro.transform.position = transform.position + new Vector3(0, 0, 0.5f);
    }

    void GetRecorder()
    {
        recorder.transform.position = transform.position + new Vector3(0, 0, 0.5f);
    }

    void GetRamp()
    {
        ramp.transform.position = transform.position + new Vector3(0, 0.5f, 0.5f);
    }
}