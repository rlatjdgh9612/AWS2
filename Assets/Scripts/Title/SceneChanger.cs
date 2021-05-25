using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private GameObject controllerGrp;
    [SerializeField] private GameObject pointer;

    private float fadeTime = 1.5f;
    
    void Awake()
    {
        
    }
    
    void Start()
    {
        Controller.Instance.ControllerModelRight.SetActive(false);
        Controller.Instance.ControllerBallRight.GetComponent<MeshRenderer>().enabled = false;
        Controller.Instance.ControllerBallRight.GetComponent<TrailRenderer>().enabled = false;
        Controller.Instance.ControllerModelLeft.SetActive(false);
        Controller.Instance.ControllerBallLeft.GetComponent<MeshRenderer>().enabled = false;
        Controller.Instance.ControllerBallLeft.GetComponent<TrailRenderer>().enabled = false;
        Controller.Instance.IsTitle = true;
        pointer.SetActive(false);
        StartCoroutine(IEfadeStart());
    }
    
    private IEnumerator IEfadeStart()
    {
        yield return new WaitForSeconds(12.5f);
        
        SteamVR_Fade.Start(Color.black, fadeTime, true);
        
        yield return new WaitForSeconds(fadeTime);
        
        controllerGrp.transform.position = Vector3.zero;
        Controller.Instance.IsTitle = false;
        Controller.Instance.ControllerModelRight.SetActive(true);
        Controller.Instance.ControllerBallRight.GetComponent<MeshRenderer>().enabled = true;
        Controller.Instance.ControllerBallRight.GetComponent<TrailRenderer>().enabled = true;
        Controller.Instance.ControllerModelLeft.SetActive(true);
        Controller.Instance.ControllerBallLeft.GetComponent<MeshRenderer>().enabled = true;
        Controller.Instance.ControllerBallLeft.GetComponent<TrailRenderer>().enabled = true;
        transform.parent.gameObject.SetActive(false);
        pointer.SetActive(true);
        
        SteamVR_Fade.Start(Color.clear, fadeTime, true);
    }
}
