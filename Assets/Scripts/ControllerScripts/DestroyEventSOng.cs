using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEventSOng : MonoBehaviour
{
    public static DestroyEventSOng instance;
    public static  GameObject sd;
    private void Awake(GameObject sd)
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
