using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class InstrumentMenu : MonoBehaviour
{
    [SerializeField] private string resourcePath;
    public string ResourcePath
    {
        get => resourcePath;
        set => resourcePath = value;
    }

    [SerializeField] private string findName;
    public string FindName
    {
        get => findName;
        set => findName = value;
    }
    
    private GameObject instrumentMarker;
    
    // Start is called before the first frame update
    void Start()
    {
        instrumentMarker = GameObject.Find("InstrumentMarker").transform.Find(findName).gameObject;

        if (!instrumentMarker)
        {
            Debug.LogError("Instrument Load Error");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Controller"))
        {
            if (Controller.Instance.Select.GetState(SteamVR_Input_Sources.RightHand))
            {
                other.GetComponent<ControllerInstrument>().InstrumentInput(instrumentMarker, resourcePath, true, true);
            }
        }
    }
}
