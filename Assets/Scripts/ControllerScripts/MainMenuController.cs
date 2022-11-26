using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]    
	public GameObject pausePanelBegin;
    //public static AudioListener audioListener;
    public static bool isMute = false;
    public void Mute()
    {
        isMute = !isMute;
        if(isMute)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = 1;
        }
    }
    
    public void Playgame()
    {
        Application.LoadLevel("LevelMenu");
        Debug.Log(this);
    }
    public void btnExit()
    {
        pausePanelBegin.SetActive (true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void CancelExit()
    {
        pausePanelBegin.SetActive (false);
    }
    
}

