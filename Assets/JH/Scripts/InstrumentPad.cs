using System;
using System.Collections;
using System.Collections.Generic;
using Deform;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class InstrumentPad : MonoBehaviour
{
    TriggerEnterEvent triggerEvent;

    [SerializeField]
    public AudioClip sound;
    private AudioSource note;
    public RadialMenu radial;

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

            SoundBandManager.Instance.HitColor(GetComponent<MeshRenderer>().material.GetColor("_EmissionColor"));
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

    public void SoundOutput(AudioClip clip)
    {
        sound = clip;
        note.clip = clip;
    }
}
