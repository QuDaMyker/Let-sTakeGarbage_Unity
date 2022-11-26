using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindController : MonoBehaviour
{
    public float TimeWindGapLeft;
    public GameObject Garbages;
    // Start is called before the first frame update
    void Start()
    {
        TimeWindGapLeft = CONS.TimeWindGap;
    }

    void Flow()
    {
        var trf = Garbages.transform;
        for (int i = 0, len = Garbages.transform.childCount; i < len; i++)
        {
            Debug.Log(i);
            trf.GetChild(i).GetComponent<GarbageControllerForLv2>().BeFlown();
        }
    } 
    // Update is called once per frame
    void Update()
    {
        if (TimeWindGapLeft < 0)
        {
            Flow();
            TimeWindGapLeft = CONS.TimeWindGap;
        }
        else
        {
            TimeWindGapLeft -= Time.deltaTime;
        }
    }
}
