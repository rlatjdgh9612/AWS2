using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class Sound : MonoBehaviour
{
    public SteamVR_Action_Boolean trigger;

    private bool isPlay = false;
    
    public Queue<AudioClip> queue = new Queue<AudioClip>();
    
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
        queue.Enqueue(go.GetComponent<AudioSource>().clip);
        Debug.Log(queue.First());
    }

    public void OutputSound(GameObject go)
    {
        if (queue.Contains(null))
        {
            Debug.Log("inputSound is null");
            return;
        }
        
        //go.GetComponent<AudioSource>().clip = SoundSystem.Instance.PlayerR.Ball.GetComponent<AudioSource>().clip;
        //go.GetComponent<InstrumentPad>().sound = SoundSystem.Instance.PlayerR.Ball.GetComponent<AudioSource>().clip;
        Debug.Log(queue);
        Debug.Log(go);
        go.GetComponent<InstrumentPad>().sound = queue.Dequeue();
        go.GetComponent<AudioSource>().clip = go.GetComponent<InstrumentPad>().sound;
        SoundSystem.Instance.PlayerR.Ball.GetComponent<AudioSource>().clip = null;
    }

    public void InputRemove()
    {
        queue.Clear();
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
                    SoundSystem.Instance.PlayerR.Ball.GetComponent<PlayerBall>().ColorChange(true);
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
