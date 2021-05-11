using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RadialMenu : MonoBehaviour
{
    public GameObject radialMenu;
    public Animator radialAnim;
    private bool isOnFirstGroup = false;
    private bool isOnSecondGroup = false;
    private bool isOnTypeUp = true; // 시작 상태는 Up == true 

    public Toggle TypeUp;
    public Toggle TypeDown;

    private void Awake()
    {
        TypeUp.isOn = isOnTypeUp;
        TypeUp.isOn = !TypeDown.isOn;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) OnEnabledMenu();
        if (Input.GetKeyDown(KeyCode.B)) OnEnableColor();
        if (Input.GetKeyDown(KeyCode.E)) OnEnableType();
        if (Input.GetKeyDown(KeyCode.C)) OnTypeUp();
        if (Input.GetKeyDown(KeyCode.D)) OnTypeDown();
        if (Input.GetKeyDown(KeyCode.F)) OnEnableOctave();
    }

    private void OnEnableOctave()
    {
        if (isOnFirstGroup && !isOnSecondGroup)
        {
            isOnSecondGroup = true;
            radialAnim.Play("Octave_On");
        }
        else if (isOnFirstGroup && isOnSecondGroup)
        {
            isOnSecondGroup = false;
            radialAnim.Play("Octave_Off");
        }
    }

    private void OnEnableType()
    {
        if (isOnFirstGroup && !isOnSecondGroup)
        {
            isOnSecondGroup = true;
            radialAnim.Play("Radial_Off");
            if (isOnTypeUp) radialAnim.Play("Type_Enabled_Up");
            if (!isOnTypeUp) radialAnim.Play("Type_Enabled_Down");
        }
        else if (isOnFirstGroup && isOnSecondGroup)
        {
            isOnSecondGroup = false;
            radialAnim.Play("Type_Disabled");
        }
    }

    private void OnEnableColor()
    {
        if (isOnFirstGroup && !isOnSecondGroup)
        {
            ////radialAnim.Play("Radial_Off");
            isOnFirstGroup = false;
            isOnSecondGroup = true;
            radialAnim.Play("Color_On");
        }
        else if (!isOnFirstGroup && isOnSecondGroup)
        {
            isOnFirstGroup = true;
            isOnSecondGroup = false;
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
        else if (isOnFirstGroup && !isOnSecondGroup)
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
        if (isOnFirstGroup && !isOnTypeUp && isOnSecondGroup)
        {
            isOnTypeUp = true;
            radialAnim.Play("Type_Up");
        }
    }

    public void OnTypeDown()
    {
        if (isOnFirstGroup && isOnTypeUp && isOnSecondGroup)
        {
            isOnTypeUp = false;
            radialAnim.Play("Type_Down");
        }
    }
}
