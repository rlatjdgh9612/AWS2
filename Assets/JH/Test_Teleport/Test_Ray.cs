using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Test_Ray : MonoBehaviour
{
    public SteamVR_Action_Boolean leftTrigger;
    public GameObject RayPos;
    RadialMenu radial;

    private void Update()
    {
        if (leftTrigger.GetStateDown(SteamVR_Input_Sources.LeftHand))
        {
            Ray ray;
            RaycastHit hit;

            if (Physics.Raycast(RayPos.transform.position, RayPos.transform.forward, out hit, 10.0f))
            {
                if (radial == null) radial = hit.transform.GetComponent<InstrumentPad>().radial;
                if (radial != null) radial.OnEnabledMenu();
            }
        }
    }
}
