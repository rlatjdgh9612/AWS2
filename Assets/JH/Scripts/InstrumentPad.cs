using System;
using System.Collections;
using System.Collections.Generic;
using Deform;
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
    private Deformable deform;

    private float speed;
    [Range(0f, 255.0f)]
    public float glow;
    public float defaultGlow = 40.0f;
    private float targetGlow;

    private float deformTime;
    private float deformSpeed;
    private float targetOffset;
    private float defaultOffset = 0.0f;
    private float offset = 0.0f;

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
        //deform = GetComponent<Deformable>();
        
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
        //mat.SetColor("_Color", new Color(1, 1, 1, glow / 255f));

        //deform.DeformerElements[0].Component.GetComponent<RippleDeformer>().Offset = offset;

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
        if (glow >= targetGlow - 1.0f || offset >= targetOffset - 1.0f)
        {
            targetGlow = defaultGlow;
            targetOffset = defaultOffset;
            hitState = HitState.Reset;
            return;
        }

        glow = Mathf.Lerp(glow, targetGlow, Time.deltaTime * speed);
        offset = Mathf.MoveTowards(offset, targetOffset, Time.deltaTime * deformSpeed);
    }

    private void UpdateReset()
    {
        if (glow <= targetGlow + 1.0f || offset <= targetOffset + 1.0f)
        {
            hitState = HitState.Ready;
            return;
        }
        glow = Mathf.Lerp(glow, targetGlow, Time.deltaTime * speed);
        offset = Mathf.MoveTowards(offset, targetOffset, Time.deltaTime * deformSpeed);
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

    public void HitDeform(float offsetPower, float speedPower)
    {
        if (deform == null)
        {
            return;
        }

        targetOffset = offsetPower;
        deformSpeed = speedPower;
        hitState = HitState.Hit;
    }

    #endregion
    //
}
