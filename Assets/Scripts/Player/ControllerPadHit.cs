using System;
using System.Collections;
using System.Collections.Generic;
using Deform;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class ControllerPadHit : MonoBehaviour
{
    [SerializeField] private GameObject ball;

    Rigidbody rig;
    public SteamVR_Action_Vibration hapticAction;

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rig.WakeUp();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pad"))
        {
            other.GetComponent<VFXColor>().Hit(150, 12.5f);

            if (gameObject.name.Contains("Left")) Pulse(1, 150, 75, SteamVR_Input_Sources.LeftHand);
            if (gameObject.name.Contains("Right")) Pulse(1, 150, 75, SteamVR_Input_Sources.RightHand);

            ball.GetComponent<TrailRenderer>().material = other.GetComponent<MeshRenderer>().material;
        }
    }

    private void Pulse(float duration, float frequency, float amplitude, SteamVR_Input_Sources source)
    {
        hapticAction.Execute(0, duration, frequency, amplitude, source);
    }

}
