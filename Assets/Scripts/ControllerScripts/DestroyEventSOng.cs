using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEventSOng : MonoBehaviour
{
    public static DestroyEventSOng instance;
    public GameObject sd;
    private void Awake()
    {
        DontDestroyOnLoad(sd);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
