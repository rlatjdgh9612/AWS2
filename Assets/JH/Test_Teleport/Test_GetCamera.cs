using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Test_GetCamera : MonoBehaviour
{
    Camera cam;
    Canvas can;
    private void Awake()
    {
        can = GetComponent<Canvas>();
        cam = GameObject.Find("Pointer").GetComponent<Camera>();
        can.worldCamera = cam;
    }
}
