using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ControllerInstrument : MonoBehaviour
{
    public SteamVR_Action_Boolean select;
    
    [SerializeField] private GameObject rightBall;
    [SerializeField] private Transform instrumentParent;
    [SerializeField] private Transform playerCam;
    
    private GameObject instrumentMarker;
    private bool isInstrumentDisplay = false;
    private string _resourcePath = String.Empty;
    
    // Update is called once per frame
    void Update()
    {
        if (select.GetStateUp(SteamVR_Input_Sources.RightHand) && !Controller.Instance.isPadTouch)
        {
            if (_resourcePath == String.Empty)
            {
                return;
            }

            InstrumentGenerate(InstrumentLoad(_resourcePath), instrumentParent, false);
            _resourcePath = String.Empty;
        }
        
        if (instrumentMarker != null)
        {
            instrumentMarker.SetActive(isInstrumentDisplay);
        }
    }
    
    public void InstrumentInput(GameObject go, string resourcePath, bool isInstrumentDisplay, bool isSelect)
    {
        this.isInstrumentDisplay = isInstrumentDisplay;
        _resourcePath = resourcePath;
        instrumentMarker = go;
        rightBall.GetComponent<PlayerBall>().ColorChange(isSelect);
    }
    
    private GameObject InstrumentLoad(string resourcePath)
    {
        GameObject go = null;
        
        go = Resources.Load<GameObject>(resourcePath);

        if (!go)
        {
            Debug.LogError("Resources Load Error Path = " + resourcePath);
            return null;
        }

        GameObject instancedGo = go;
        return instancedGo;
    }

    private bool InstrumentGenerate(GameObject instancedGo, Transform parent, bool isSelect)
    {
        GameObject instrument = Instantiate<GameObject>(instancedGo, parent, true);
        string replace = instrument.name.Replace("(Clone)", "");
        instrument.name = replace;
        instrument.transform.position = rightBall.transform.position + (playerCam.forward * 0.5f);
        instrument.transform.rotation = playerCam.rotation;
        isInstrumentDisplay = false;
        rightBall.GetComponent<PlayerBall>().ColorChange(isSelect);

        return true;
    }
}
