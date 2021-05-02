using System;
using System.Collections;
using System.Collections.Generic;
using Deform;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class Controller : MonoBehaviour
{
    // 민찬 변수
    #region 민찬 변수

    public SteamVR_Action_Boolean menuButton;
    public SteamVR_Action_Boolean trigger;
    
    private bool isInstrument = false;
    private bool isMainMenu = false;
    
    [SerializeField] private GameObject ball;
    public GameObject Ball => ball;

    private GameObject mainMenu;

    #endregion
    //
    
    private void Start()
    {
        mainMenu = GameObject.Find("1st_Menu_Group").transform.Find("MainMenu").gameObject;
    }

    private void Update()
    {
        if (menuButton.GetStateDown(SteamVR_Input_Sources.RightHand))
        {
            isMainMenu = !isMainMenu;
            
            if (!isMainMenu)
            {
                return;
            }
            
            ButtonManager.Instance.OnButtonFind("MainMenu");
        }

        if (trigger.GetStateUp(SteamVR_Input_Sources.RightHand) && !isInstrument)
        {
            SoundSystem.Instance.Sound.InputRemove();
            SoundSystem.Instance.Sound.isInput = false;
            ball.GetComponent<MeshRenderer>().material.SetColor("_Color", new Color32(255, 255, 255, 255));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pad"))
        {
            isInstrument = true;
            other.GetComponent<InstrumentPad>().Hit(180, 5);
            other.GetComponent<InstrumentPad>().HitDeform(5, 5);
            ball.GetComponent<TrailRenderer>().material = other.GetComponent<MeshRenderer>().material;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Pad"))
        {
            if (trigger.GetStateUp(SteamVR_Input_Sources.RightHand))
            {
                SoundSystem.Instance.Sound.OutputSound(other.gameObject);
                SoundSystem.Instance.Sound.isInput = false;
                ball.GetComponent<MeshRenderer>().material.SetColor("_Color", new Color32(255, 255, 255, 255));
                isInstrument = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Pad"))
        {
            isInstrument = false;
        }
    }
}
