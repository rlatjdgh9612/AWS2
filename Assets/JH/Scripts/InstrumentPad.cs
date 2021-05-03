using System;
using System.Collections;
using System.Collections.Generic;
using Deform;
using UnityEngine;
using UnityEngine.UI;

public class InstrumentPad : MonoBehaviour
{
    TriggerEnterEvent triggerEvent;

    [SerializeField]
    public AudioClip sound;
    private AudioSource note;

    public int padIndex;

    void Start()
    {
        if (note == null) note = gameObject.AddComponent<AudioSource>();

        note.clip = sound;
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Controller")
        {
            note.Play();
            triggerEvent = new TriggerEnterEvent(sound, Record.Instance.recordStartTime, padIndex);
            Debug.Log(other.gameObject.tag);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Controller")
        {
            triggerEvent.OnTriggerExit();
            Record.Instance.AddPressButtonEvent(triggerEvent);

        }
    }
}
