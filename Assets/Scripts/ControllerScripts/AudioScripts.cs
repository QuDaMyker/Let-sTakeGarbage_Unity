using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScripts : MonoBehaviour
{
    public static AudioScripts instance;

    public void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(transform.gameObject);
        }
    }
}
