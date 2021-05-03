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
    
    private bool isTouchInstrument = false;
    private bool isMainMenu = false;
    
    [SerializeField] private GameObject ball;
    public GameObject Ball => ball;

    [SerializeField] private Transform instrumentParent;
    [SerializeField] private Transform playerCam;

    private GameObject instrumentMarker;
    private bool isInstrumentDisplay = false;
    private string _resourcePath = String.Empty;

    #endregion
    //
    
    private void Start()
    {
        
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

        if (trigger.GetStateUp(SteamVR_Input_Sources.RightHand) && !isTouchInstrument)
        {
            SoundInputFail(false);
            
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pad"))
        {
            isTouchInstrument = true;
            other.GetComponent<VFXColor>().Hit(180, 5);
            ball.GetComponent<TrailRenderer>().material = other.GetComponent<MeshRenderer>().material;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Pad"))
        {
            if (trigger.GetStateUp(SteamVR_Input_Sources.RightHand))
            {
                SoundOutput(other.gameObject, false);
                Debug.Log(other.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Pad"))
        {
            isTouchInstrument = false;
        }
    }

    // 민찬 함수
    #region 민찬 함수
    
    void SoundInputFail(bool isSelect)
    {
        SoundSystem.Instance.Sound.InputRemove();
        ball.GetComponent<PlayerBall>().ColorChange(isSelect);
    }

    void SoundOutput(GameObject sound, bool isSelect)
    {
        SoundSystem.Instance.Sound.OutputSound(sound);
        ball.GetComponent<PlayerBall>().ColorChange(isSelect);
        isTouchInstrument = false;
    }
    
    public void InstrumentInput(GameObject go, string resourcePath, bool isInstrumentDisplay, bool isSelect)
    {
        this.isInstrumentDisplay = isInstrumentDisplay;
        _resourcePath = resourcePath;
        instrumentMarker = go;
        ball.GetComponent<PlayerBall>().ColorChange(isSelect);
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
        instrument.transform.position = ball.transform.position + (playerCam.forward * 0.5f);
        instrument.transform.rotation = playerCam.rotation;
        isInstrumentDisplay = false;
        ball.GetComponent<PlayerBall>().ColorChange(isSelect);

        return true;
    }
    
    #endregion
    
    
}
