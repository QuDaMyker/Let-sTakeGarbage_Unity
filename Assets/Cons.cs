using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CONS
{
    public enum EType
    {
        ORGANIC,
        INORGANIC
    }
    public static int DeltaScore = 10;
    public static int TimeOut = 10;
    public static float Speed = 0.1f;
    public static float SpeedWaving = 0.02f;
    public static float Amplitude = 0.001f;
    public static int TimeGarbageAppearMax = 2;
    public static float TimeFrame = 0.01f;
    //lv 2
    public static float TimeWindGap = 2f;
    public static float Friction = 0.02f;
    public static float WindSpeed = 0.4f;
    public static float SpeedRolling =  - 100f;


}
