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

    public Record recorder;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pad"))
        {
            other.GetComponent<VFXColor>().Hit(180, 10);
            ball.GetComponent<TrailRenderer>().material = other.GetComponent<MeshRenderer>().material;
            //recorder.padCount = other.GetComponentInParent<Instrument>().padList.Length;
        }
    }

}
