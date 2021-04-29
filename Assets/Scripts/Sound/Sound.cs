using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
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
                GetComponentInChildren<Transform>().Find("Marker").GetComponent<Image>().color = new Color32(255,255,255,255);
                Play(this.gameObject);
            }

            StartCoroutine(PlayDelay());
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Controller"))
        {
            if (Input.GetMouseButton(1))
            {
                InputSound(this.gameObject);
                if (SoundSystem.Instance.PlayerR.Ball.GetComponent<AudioSource>().clip != null)
                {
                    SoundSystem.Instance.PlayerR.Ball.GetComponent<MeshRenderer>().material.SetColor("Color_6CAB6821", new Color32(255, 255, 80, 255));
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GetComponentInChildren<Transform>().Find("Marker").GetComponent<Image>().color = new Color32(255,255,255,25);
    }

    IEnumerator PlayDelay()
    {
        yield return new WaitForSeconds(1f);
        isPlay = false;
    }
}
