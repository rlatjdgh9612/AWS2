using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Test_Ray : MonoBehaviour
{
    public SteamVR_Action_Boolean leftTrigger;
    RadialMenu radial;
    private void Update()
    {
        if (leftTrigger.GetStateDown(SteamVR_Input_Sources.LeftHand))
        {
            Ray ray;
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, 10.0f))
            {
                radial = hit.transform.GetComponent<InstrumentPad>().radial;
                if (!radial.isOnFirstGroup)
                    radial.GetComponent<Animator>().Play("Radial_On");
            }
        }
    }
}
