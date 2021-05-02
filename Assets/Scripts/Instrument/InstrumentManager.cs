using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InstrumentData
{
    public Transform instrumentParent;
    public int instrumentCacheCount;
    public List<string> instrumentPath = new List<string>();
}

public class InstrumentManager : MonoBehaviour
{
    [SerializeField] private InstrumentFactory instrumentFactory;
    [SerializeField] private string instrumentPrefabPath;
    public string InstrumentPrefabPath => instrumentPrefabPath;
    [SerializeField] private InstrumentData[] instrumentData;
    public 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool GenerateInstrument(Transform instrumentParent, List<string> instrumentPath)
    {
        //GameObject go = instrumentFactory.Load();
        return true;
    }
}
