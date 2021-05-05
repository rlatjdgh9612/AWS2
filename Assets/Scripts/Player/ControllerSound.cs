using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ControllerSound : MonoBehaviour
{
    public SteamVR_Action_Boolean select;
    
    [SerializeField] private GameObject rightBall;
    public GameObject RightBall => rightBall;

    // Update is called once per frame
    void Update()
    {
        if (select.GetStateUp(SteamVR_Input_Sources.RightHand) && !Controller.Instance.isPadTouch)
        {
            SoundInputFail(false);
        }
    }
    
    void SoundInputFail(bool isSelect)
    {
        rightBall.GetComponent<PlayerBall>().AudioRemove();
        rightBall.GetComponent<PlayerBall>().ColorChange(isSelect);
    }
    
    void SoundOutput(GameObject sound, bool isSelect)
    {
        if (rightBall.GetComponent<AudioSource>().clip == null)
        {
            Debug.Log("inputSound is null");
            return;
        }
         
        sound.GetComponent<InstrumentPad>().SoundOutput(rightBall.GetComponent<AudioSource>().clip);
        rightBall.GetComponent<PlayerBall>().ColorChange(isSelect);
        rightBall.GetComponent<AudioSource>().clip = null;
    }

    
    // 오른쪽 컨트롤러가 악기에 닿았을때 사운드를 악기에 할당시킨다
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Pad"))
        {
            if (select.GetStateUp(SteamVR_Input_Sources.RightHand) && Controller.Instance.isPadTouch)
            {
                SoundOutput(other.gameObject, false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Controller.Instance.isPadTouch = true;
    }

    private void OnTriggerExit(Collider other)
    {
        Controller.Instance.isPadTouch = false;
    }
}
