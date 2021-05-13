using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Color_Picker : MonoBehaviour
{
    public FlexibleColorPicker fcp;
    public List<Material> materials = new List<Material>();

    public Color externalColor;
    private Color internalColor;

    Renderer rend;
    private void Start()
    {
        internalColor = externalColor;
    }

    private void Update()
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
            // List에 중복으로 들어가지 않게 중복제거
            materials = materials.Distinct().ToList();
            materials[i].SetColor("_EmissionColor", fcp.color * 2f);
        }
    }
}
