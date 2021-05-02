using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ColorChange(float r, float g, float b, float a)
    {
        GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(r, g, b, a));
    }
}
