using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float speed = 10.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateInput();
    }

    void UpdateInput()
    {
        Vector3 dir = Vector3.zero;
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        dir = new Vector3(h, v, 0);
        
        if (Input.GetKey(KeyCode.Q))
        {
            dir.z = 1.0f;
        }

        if (Input.GetKey(KeyCode.E))
        {
            dir.z = -1.0f;
        }

        transform.position += dir * (speed * Time.deltaTime);
    }

}
