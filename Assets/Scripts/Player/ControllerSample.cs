﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.iOS;
using UnityEngine;
using Valve.VR;

public class ControllerSample : MonoBehaviour
{
    [SerializeField] private GameObject rightBall;
    [SerializeField] private Transform sampleParent;
    [SerializeField] private Transform playerCam;

    private GameObject sampleMarker;
    private bool _isSampleDisplay = false;
    private string _resourcePath = String.Empty;
    private string _sampleClipResourcePath = String.Empty;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Controller.Instance.Select.GetStateUp(SteamVR_Input_Sources.RightHand) && !Controller.Instance.IsPadTouch)
        {
            if (_resourcePath == String.Empty)
            {
                return;
            }
            
            SampleGenerate(SampleLoad(_resourcePath), SampleLoadSound(_sampleClipResourcePath), sampleParent, false);
            
            SampleGenerateFail(false);
        }
        
        if (sampleMarker != null)
        {
            sampleMarker.SetActive(_isSampleDisplay);
        }
    }

    void SampleGenerateFail(bool isSelect)
    {
        _resourcePath = String.Empty;
        
        _isSampleDisplay = false;
        rightBall.GetComponent<PlayerBall>().ColorChange(isSelect);
    }
    
    public void SampleInput(GameObject go, string resourcePath, string sampleClipResourcePath, bool isSampleDisplay, bool isSelect)
    {
        _isSampleDisplay = isSampleDisplay;
        _resourcePath = resourcePath;
        _sampleClipResourcePath = sampleClipResourcePath;
        sampleMarker = go;
        rightBall.GetComponent<PlayerBall>().ColorChange(isSelect);
    }
    
    private GameObject SampleLoad(string resourcePath)
    {
        GameObject go = null;

        go = Resources.Load<GameObject>(resourcePath);

        if (!go)
        {
            Debug.Log("Resources Load Error filePath = " + resourcePath);
            return null;
        }

        GameObject instancedGo = go;
        return instancedGo;
    }

    private AudioClip SampleLoadSound(string resourcePath)
    {
        AudioClip clip = null;

        clip = Resources.Load<AudioClip>(resourcePath);

        if (!clip)
        {
            Debug.Log("Resources Load Error filePath = " + resourcePath);
            return null;
        }

        AudioClip instancedClip = clip;
        return instancedClip;
    }

    private bool SampleGenerate(GameObject instancedGo, AudioClip instancedClip, Transform parent, bool isSelect)
    {
        GameObject sample = Instantiate<GameObject>(instancedGo, parent, true);
        string replace = sample.name.Replace("(Clone)", "");
        sample.name = replace;
        sample.transform.position = rightBall.transform.position + rightBall.transform.forward * 0.25f;
        sample.transform.localScale = Vector3.one;
        sample.transform.forward = playerCam.transform.forward;
        sample.transform.localEulerAngles = new Vector3(0.0f, sample.transform.localEulerAngles.y, sample.transform.localEulerAngles.z);
        sample.GetComponent<AudioSource>().clip = instancedClip;
        _isSampleDisplay = false;
        rightBall.GetComponent<PlayerBall>().ColorChange(isSelect);
        
        return true;
    }
}
