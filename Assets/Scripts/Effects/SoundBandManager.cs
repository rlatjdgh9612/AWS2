using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoundBandManager : MonoBehaviour
{
    [SerializeField] private static SoundBandManager instance = null;
    public static SoundBandManager Instance => instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("singletone error!");
            Destroy(gameObject);
            return;
        }

        instance = this;
    }
    private const string path = "SoundBands/SoundBand";
    private int rnd;
    
    // Start is called before the first frame update
    void Start()
    {
        this.transform.eulerAngles = new Vector3(0, 45.0f, 0);
    }

    public GameObject Load(string resourcePath)
    {
        GameObject go = null;

        go = Resources.Load<GameObject>(resourcePath);
        if (!go)
        {
            Debug.LogError("Resources Load Error! filePath = " + resourcePath);
            return null;
        }

        GameObject instancedGo = go;
        instancedGo.name = instancedGo.name.Replace("(Clone)", "");
        return instancedGo;
    }

    public bool GenerateSoundBand()
    {
        GameObject soundBand = Instantiate<GameObject>(Load(path));
        soundBand.SetActive(true);
        soundBand.transform.position = this.transform.position;
        soundBand.transform.parent = this.transform;
        soundBand.transform.position = Vector3.forward * 8.0f;
        soundBand.GetComponent<SoundBand>().ScrollData.speed = 1.0f;
        rnd = Random.Range(0, 90);
        this.transform.eulerAngles = new Vector3(0, rnd * 2.0f, 0);
        
        StartCoroutine(SoundBandReset(soundBand));

        return true;
    }

    IEnumerator SoundBandReset(GameObject soundBand)
    {
        yield return new WaitForSeconds(3.0f);
        
        soundBand.GetComponent<SoundBand>().ScrollData.speed = 0.0f;
        Destroy(soundBand);
    }

}
