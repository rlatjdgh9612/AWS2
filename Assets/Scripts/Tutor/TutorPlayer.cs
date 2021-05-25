using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TutorPlayer : MonoBehaviour
{
    private bool isPlayDelay;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Controller"))
        {
            if (this.gameObject.name == "Play")
            {
                StartCoroutine(TouchAnim());
                GetComponentInParent<VideoPlayer>().Stop();
                GetComponentInParent<VideoPlayer>().Play();
            }
            
            if (this.gameObject.name == "Pause")
            {
                StartCoroutine(TouchAnim());
                GetComponentInParent<VideoPlayer>().Play();
                GetComponentInParent<VideoPlayer>().Pause();
            }
            
            if (this.gameObject.name == "Cancel")
            {
                Destroy(GetComponentInParent<VideoPlayer>().gameObject);
            }
        }
    }

    IEnumerator TouchAnim()
    {
        GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(0, 1f, 0f, 80.0f/255.0f));
        
        yield return new WaitForSeconds(1.0f);
        
        GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(80.0f/255.0f, 80.0f/255.0f, 80.0f/255.0f, 80.0f/255.0f));
    }
}
