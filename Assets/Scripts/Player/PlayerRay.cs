﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRay : MonoBehaviour
{
    private bool isInstrument = false;
    private bool isMainMenu = false;
    private bool isAppMenu = false;
    
    [SerializeField] private GameObject ball;
    public GameObject Ball => ball;

    private GameObject mainMenu;
    private GameObject appMenu;
    
    private void Start()
    {
        mainMenu = GameObject.Find("1st_Menu_Group").transform.Find("MainMenu").gameObject;
        appMenu = GameObject.Find("1st_Menu_Group").transform.Find("ApplicationMenu").gameObject;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            isMainMenu = !isMainMenu;
            mainMenu.SetActive(isMainMenu);
            isAppMenu = !isMainMenu;
            appMenu.SetActive(isAppMenu);
        }

        if (Input.GetMouseButtonUp(1) && !isInstrument)
        {
            SoundSystem.Instance.Sound.InputRemove();
            SoundSystem.Instance.Sound.isInput = false;
            ball.GetComponent<MeshRenderer>().material.SetColor("Color_6CAB6821", new Color32(255, 255, 255, 255));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pad"))
        {
            isInstrument = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Pad"))
        {
            if (Input.GetMouseButtonUp(1))
            {
                SoundSystem.Instance.Sound.OutputSound(other.gameObject);
                SoundSystem.Instance.Sound.isInput = false;
                ball.GetComponent<MeshRenderer>().material.SetColor("Color_6CAB6821", new Color32(255, 255, 255, 255));
                isInstrument = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Pad"))
        {
            isInstrument = false;
        }
    }
}
