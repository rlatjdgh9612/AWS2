using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstrumentPad : MonoBehaviour
{
    // 민찬 변수
    #region 민찬 변수

    public enum HitState
    {
        Ready,
        Hit,
        Reset
    }

    public HitState hitState = HitState.Ready;
    
    private Material mat;

    private float speed;
    [Range(0f, 255.0f)]
    public float glow;
    public float defaultGlow = 40.0f;
    private float targetGlow;

    #endregion
    //
    
    TriggerEnterEvent triggerEvent;

    [SerializeField]
    public AudioClip sound;
    private AudioSource note;

    public int padIndex;

    void Start()
    {
        //민찬 변수 선언
        #region 민찬 변수 선언

        mat = GetComponent<MeshRenderer>().material;

        #endregion
        //
        
        if (note == null) note = gameObject.AddComponent<AudioSource>();

        note.clip = sound;
    }

    private void Update()
    {
        // 민찬 업데이트
        #region 민찬 업데이트

        switch(hitState)
        {
            case HitState.Ready:
                UpdateReady();
                break;
            case HitState.Hit:
                UpdateHit();
                break;
            case HitState.Reset:
                UpdateReset();
                break;
        }
        
        mat.SetColor("_Color", new Color32(255,255,255,(byte)glow));

        #endregion
        //
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

    // 민찬 함수
    #region 민찬 함수

    private void UpdateHit()
    {
        if (glow >= targetGlow - 1.0f)
        {
            targetGlow = defaultGlow;
            hitState = HitState.Reset;
            return;
        }

        glow = Mathf.Lerp(glow, targetGlow, Time.deltaTime * speed);
    }

    private void UpdateReset()
    {
        if (glow <= targetGlow + 1.0f)
        {
            hitState = HitState.Ready;
            return;
        }
        
        glow = Mathf.Lerp(glow, targetGlow, Time.deltaTime * speed);
    }

    private void UpdateReady()
    {
        
    }

    public void Hit(float targetGlowPower, float speedPower)
    {
        targetGlow = targetGlowPower;
        speed = speedPower;
        hitState = HitState.Hit;
    }

    #endregion
    //
}
