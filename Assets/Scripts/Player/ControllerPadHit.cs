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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pad"))
        {
            other.GetComponent<VFXColor>().Hit(180, 5);
            ball.GetComponent<TrailRenderer>().material = other.GetComponent<MeshRenderer>().material;
        }
        print(other.gameObject.name);
    }

}
