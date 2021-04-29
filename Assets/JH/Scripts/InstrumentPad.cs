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
        None,
        Ready,
        Hit
    }

    public HitState hitState = HitState.None;
    
    private Material mat;

    private float speed = 1.0f;
    [Range(20.0f, 122.5f)]
    public float maxGlow = 80.0f;
    [Range(20.0f, 122.5f)]
    public float glow = 20.0f;
    public float defaultGlow = 20.0f;
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
            case HitState.None:
                break;
            case HitState.Ready:
                break;
            case HitState.Hit:
                UpdateHit();
                break;
        }

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
        float dist = Mathf.Abs(targetGlow - glow);

        if (dist == 0 || glow > maxGlow)
        {
            targetGlow = defaultGlow;
        }
        
        glow = Mathf.Lerp(glow, targetGlow, Time.deltaTime * speed);
        
        mat.SetColor("_Color", new Color32(255,255,255,(byte)glow));
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
