using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DestroySongEnd : MonoBehaviour
{
    public static DestroySongEnd instance;
    //public GameObject sd;
    
    private void Awake()
    {
        // DontDestroyOnLoad(this.gameObject);

        // if (instance == null)
        // {
        //     instance = this;
        // }
        // else
        // {
        //     Destroy(gameObject);
        // }
        Destroy(this);
    }
}
