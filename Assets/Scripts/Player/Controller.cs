using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private static Controller instance = null;
    public static Controller Instance => instance;

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

    public bool isPadTouch = false;
}
