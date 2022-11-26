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
    public static int TimeOut = 30;
    public static float Speed = 0.02f;
    public static float SpeedWaving = 0.02f;
    public static float Amplitude = 0.001f;
    public static int TimeGarbageAppearMax = 5;
}
