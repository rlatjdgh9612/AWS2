using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class InstrumentMenu : MonoBehaviour
{
    public SteamVR_Action_Boolean trigger;
    
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
    
    private GameObject go;
    
    // Start is called before the first frame update
    void Start()
    {
        go = GameObject.Find("InstrumentMarker").transform.Find(findName).gameObject;

        if (!go)
        {
            Debug.LogError("Instrument Load Error");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Controller"))
        {
            if (trigger.GetState(SteamVR_Input_Sources.RightHand))
            {
                other.GetComponent<Controller>().InstrumentInput(go, resourcePath, true, true);
            }
        }
    }
}
