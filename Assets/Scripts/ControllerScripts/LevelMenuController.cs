using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        Application.LoadLevel("PlayGame");
    }

    public void BackToMenu()
    {
        Application.LoadLevel("mainMenu");
    }
}
