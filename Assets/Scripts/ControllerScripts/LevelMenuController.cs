using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenuController : MonoBehaviour
{
    public void PlayGame(int lv)
    {
        Application.LoadLevel($"Lv{lv}");
        Debug.Log(lv);
    }
    
    public void BackToMenu()
    {
        Application.LoadLevel("mainMenu");
    }
}
