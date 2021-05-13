using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RadialMenu : MonoBehaviour
{
    public bool isOnFirstGroup = false;
    private bool isOnSecondGroup = false;
    private bool isOnTypeUp = true; // 시작 상태는 Up == true 
    private bool isOnType = false;
    private bool isOnColor = false;
    private bool isOnOctave = false;

    public Toggle TypeUp;
    public Toggle TypeDown;

    public Animator radialAnim;
    public GameObject radialMenu;

    private void Awake()
    {
        if (TypeUp != null)
        {
            TypeUp.isOn = isOnTypeUp;
            TypeUp.isOn = !TypeDown.isOn;
        }
    }
    private void Update()
    {

    }

    public void OnEnableOctave()
    {
        if (!isOnOctave)
        {
            isOnOctave = true;
            radialAnim.Play("Octave_On");
        }
    }

    public void OnDisableOctave()
    {
        if (isOnOctave)
        {
            isOnOctave = false;
            radialAnim.Play("Octave_Off");
        }
    }

    public void OnEnableType()
    {
        if (!isOnType)
        {
            isOnType = true;
            if (isOnTypeUp) radialAnim.Play("Type_Enabled_Up");
            if (!isOnTypeUp) radialAnim.Play("Type_Enabled_Down");
        }
    }

    public void OnDisableType()
    {
        if (isOnType)
        {
            isOnType = false;
            radialAnim.Play("Type_Disabled");
        }
    }

    public void OnEnableColor()
    {
        if (!isOnColor)
        {
            isOnColor = true;
            radialAnim.Play("Color_On");
        }
    }

    public void OnDisableColor()
    {
        if (isOnColor)
        {
            isOnColor = false;
            radialAnim.Play("Color_Off");
        }
    }

    public void OnEnabledMenu()
    {
        if (!isOnFirstGroup && !isOnSecondGroup)
        {
            isOnFirstGroup = true;
            radialAnim.Play("Radial_On");
        }
    }

    public void OnDisableMenu()
    {
        if (isOnFirstGroup && !isOnSecondGroup)
        {
            isOnFirstGroup = false;
            radialAnim.Play("Radial_Off");
        }
    }

    public void OnDeleteButton()
    {
        Destroy(gameObject);
    }

    public void OnTypeUp()
    {
        if (!isOnTypeUp)
        {
            isOnTypeUp = true;
            radialAnim.Play("Type_Up");
        }
    }

    public void OnTypeDown()
    {
        if (isOnTypeUp)
        {
            isOnTypeUp = false;
            radialAnim.Play("Type_Down");
        }
    }

    public void OnBackButton()
    {
        if (isOnType) OnDisableType();
        if (isOnColor) OnDisableColor();
        if (isOnOctave) OnDisableOctave();
    }
}
