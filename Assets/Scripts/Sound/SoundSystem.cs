using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    [SerializeField] private static SoundSystem instance = null;
    public static SoundSystem Instance => instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("singleton error!");
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    [SerializeField] private Controller playerR;
    public Controller PlayerR => playerR;

    [SerializeField] private Sound sound;
    public Sound Sound => sound;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [SerializeField] SoundManager soundManager;
    public SoundManager SoundManager => soundManager;

    [SerializeField] private SoundMenu soundMenu;
    public SoundMenu SoundMenu => soundMenu;
}
