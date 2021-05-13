using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScrollDatas
{
    public float offsetY;
    public float speed;
}

public class SoundBand : MonoBehaviour
{
    [SerializeField] ScrollDatas scrollData;
    public ScrollDatas ScrollData => scrollData;

    private Material mat;
    
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScroll();
    }

    void UpdateScroll()
    {
        scrollData.offsetY += (float) scrollData.speed * Time.deltaTime;

        if (scrollData.offsetY > 1.0f)
        {
            scrollData.offsetY = scrollData.offsetY % 1.0f;
        }
        
        Vector2 offset = new Vector2(0, scrollData.offsetY * -1.0f);
        
        mat.SetTextureOffset("_MainTex", offset);
    }

}
