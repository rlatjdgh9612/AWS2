using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Color_Picker : MonoBehaviour
{
    private FlexibleColorPicker fcp;
    public List<Material> materials = new List<Material>();

    public Color externalColor;
    private Color internalColor;

    // Mat 가져오는 예외처리 변수 선언
    public bool isGetMat;


    Renderer rend;
    private void Start()
    {
        internalColor = externalColor;
    }

    private void Update()
    {
        print(fcp);
        if (fcp?.GetComponent<FlexibleColorPicker>().enabled == true)
        {
            //apply color of this script to the FCP whenever it is changed by the user
            if (internalColor != externalColor)
            {
                fcp.color = externalColor;
                internalColor = externalColor;
            }
            //extract color from the FCP and apply it to the object material
            for (int i = 0; i < materials.Count; i++)
            {
                // List�� �ߺ����� ���� �ʰ� �ߺ�����
                materials = materials.Distinct().ToList();
                materials[i].SetColor("_EmissionColor", fcp.color * 2f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (fcp == null) fcp = other.transform.parent.GetComponentInChildren<FlexibleColorPicker>();
        if (fcp != null) fcp = other.transform.parent.GetComponentInChildren<FlexibleColorPicker>();

    }
}
