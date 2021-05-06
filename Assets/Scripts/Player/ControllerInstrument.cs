﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ControllerInstrument : MonoBehaviour
{
    [SerializeField] private GameObject rightBall;
    [SerializeField] private Transform instrumentParent;
    [SerializeField] private Transform playerCam;
    
    private GameObject instrumentMarker;
    public bool _isInstrumentDisplay = false;
    private string _resourcePath = String.Empty;
    
    // Update is called once per frame
    void Update()
    {
        if (Controller.Instance.Select.GetStateUp(SteamVR_Input_Sources.RightHand) && !Controller.Instance.IsPadTouch)
        {
            InstrumentGenerate(InstrumentLoad(_resourcePath), instrumentParent, false);
            
            InstrumentGenerateFail(false);
        }

        if (instrumentMarker != null)
        {
            instrumentMarker.SetActive(_isInstrumentDisplay);
        }
    }

    void InstrumentGenerateFail(bool isSelect)
    {
        if (_resourcePath == String.Empty)
        {
            return;
        }
        
        _resourcePath = String.Empty;
        
        _isInstrumentDisplay = false;
        rightBall.GetComponent<PlayerBall>().ColorChange(isSelect);
    }
    
    public void InstrumentInput(GameObject go, string resourcePath, bool isInstrumentDisplay, bool isSelect)
    {
        _isInstrumentDisplay = isInstrumentDisplay;
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
        instrument.transform.position = rightBall.transform.position + rightBall.transform.forward * 0.25f;
        instrument.transform.localScale = new Vector3(0.7f,0.7f,0.7f);
        instrument.transform.forward = playerCam.forward;
        instrument.transform.localEulerAngles = new Vector3(0.0f, instrument.transform.localEulerAngles.y, instrument.transform.localEulerAngles.z);
        _isInstrumentDisplay = false;
        rightBall.GetComponent<PlayerBall>().ColorChange(isSelect);

        return true;
    }
}
