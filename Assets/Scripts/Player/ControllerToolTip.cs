using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ControllerToolTip : MonoBehaviour
{
    [SerializeField] private GameObject toolTip;
    [SerializeField] private GameObject toolTipMenu;
    public GameObject ToolTipMenu => toolTipMenu;

    private float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        toolTip.SetActive(Controller.Instance.IsToolTip);

        if (this.gameObject.name == Controller.WhichIsHand.rightHand)
        {
            if (toolTipMenu.activeSelf == true)
            {
                currentTime += Time.deltaTime;
                if (currentTime > 3.0f)
                {
                    toolTipMenu.SetActive(false);
                    currentTime = 0.0f;
                }
            }
        }
    }
}
