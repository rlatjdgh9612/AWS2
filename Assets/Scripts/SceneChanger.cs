using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChanger : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this);    
    }

    void Start()
    {
        // 3초 뒤에 FadeOut 되면서
        Invoke("CallFader", 6.5f);
        //Fader.instance.FadeOut(3);
        //StartCoroutine(OnChange());
        Invoke("NextScene", 10.0f);
    }

    //public IEnumerator OnChange()
    //{
    //    // 6초후에 Game Scene으로 전환시킨다
    //    yield return new WaitForSeconds(6);
    //}
    
    public void NextScene()
    {
        SceneManager.LoadScene("Test Scene");
    }

    public void CallFader()
    {
        Fader.instance.FadeOut(3);
    }

}
