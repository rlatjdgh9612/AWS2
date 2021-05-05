using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ControllerMenu : MonoBehaviour
{
    public SteamVR_Action_Boolean menu;
    
    private bool isMainMenu = false;

    // Update is called once per frame
    void Update()
    {
        if (menu.GetStateDown(SteamVR_Input_Sources.RightHand))
        {
            isMainMenu = !isMainMenu;
            
            if (!isMainMenu)
            {
                return;
            }
            
            ButtonManager.Instance.OnButtonFind("MainMenu");
        }
    }
}
