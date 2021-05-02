using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class Sound : MonoBehaviour
{
    public SteamVR_Action_Boolean trigger;
    
    public bool isInput;

    private bool isPlay = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play(GameObject go)
    {
        go.GetComponent<AudioSource>().Play();
    }

    public void InputSound(GameObject go)
    {
        SoundSystem.Instance.PlayerR.Ball.GetComponent<AudioSource>().clip = go.GetComponent<AudioSource>().clip;
    }

    public void OutputSound(GameObject go)
    {
        if (SoundSystem.Instance.PlayerR.Ball.GetComponent<AudioSource>().clip == null)
        {
            Debug.Log("inputSound is null");
            return;
        }
        else
        {
            go.GetComponent<AudioSource>().clip = SoundSystem.Instance.PlayerR.Ball.GetComponent<AudioSource>().clip;
            SoundSystem.Instance.PlayerR.Ball.GetComponent<AudioSource>().clip = null;
        }
    }

    public void InputRemove()
    {
        SoundSystem.Instance.PlayerR.Ball.GetComponent<AudioSource>().clip = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Controller"))
        {
            if (!isPlay)
            {
                isPlay = true;
                GetComponentInChildren<Transform>().Find("Marker").GetComponent<Image>().color = new Color(1,1,1,1);
                Play(this.gameObject);
            }

            StartCoroutine(PlayDelay());
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Controller"))
        {
            if (trigger.GetState(SteamVR_Input_Sources.RightHand))
            {
                InputSound(this.gameObject);
                if (SoundSystem.Instance.PlayerR.Ball.GetComponent<AudioSource>().clip != null)
                {
                    SoundSystem.Instance.PlayerR.Ball.GetComponent<PlayerBall>().ColorChange(1, 1, 80.0f / 255.0f, 1);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GetComponentInChildren<Transform>().Find("Marker").GetComponent<Image>().color = new Color(1,1,1,25.0f / 255.0f);
    }

    IEnumerator PlayDelay()
    {
        yield return new WaitForSeconds(1f);
        isPlay = false;
    }
}
