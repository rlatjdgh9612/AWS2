using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Controller : MonoBehaviour
{
    [SerializeField] private static Controller instance = null;
    public static Controller Instance => instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("singletone error!");
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    public struct WhichIsHand
    {
        public const string rightHand = "ControllerRight";
        public const string leftHand = "ControllerLeft";
    }

    [SerializeField] private SteamVR_Action_Boolean select;
    public SteamVR_Action_Boolean Select => select;
    
    [SerializeField] private SteamVR_Action_Boolean menu;
    public SteamVR_Action_Boolean Menu => menu;

    [SerializeField] private SteamVR_Action_Boolean grab;
    public SteamVR_Action_Boolean Grab => grab;

    
    [SerializeField] private bool isPadTouch = false;
    public bool IsPadTouch
    {
        get => isPadTouch;
        set => isPadTouch = value;
    }

    [SerializeField] private bool isRightPadGrab = false;
    public bool IsRightPadGrab
    {
        get => isRightPadGrab;
        set => isRightPadGrab = value;
    }
    
    [SerializeField] private bool isLeftPadGrab = false;
    public bool IsLeftPadGrab
    {
        get => isLeftPadGrab;
        set => isLeftPadGrab = value;
    }
    
    [SerializeField] private GameObject rightGrabPad = null;
    public GameObject RightGrabPad
    {
        get => rightGrabPad;
        set => rightGrabPad = value;
    }
    
    [SerializeField] private GameObject leftGrabPad = null;
    public GameObject LeftGrabPad
    {
        get => leftGrabPad;
        set => leftGrabPad = value;
    }
}
