using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class TutorMenu : MonoBehaviour
{
    [SerializeField] private string tutorPath;
    public string TutorPath
    {
        get => tutorPath;
        set => tutorPath = value;
    }

    [SerializeField] private string tutorVideoPath;
    public string TutorVideoPath
    {
        get => tutorVideoPath;
        set => tutorVideoPath = value;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Controller"))
        {
            if (Controller.Instance.Menu2.GetState(SteamVR_Input_Sources.RightHand))
            {
                other.gameObject.GetComponent<ControllerTutor>().TutorInput(tutorPath, tutorVideoPath, true, true);
            }
        }
    }
}
