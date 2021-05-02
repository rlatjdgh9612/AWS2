using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noise : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(IeTonaido());
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Random.insideUnitSphere;
    }

    IEnumerator IeTonaido()
    {
        while (true)
        {
            transform.localPosition = Random.insideUnitSphere;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
