using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]    
	public GameObject pausePanelBegin;
    public GameObject PanelInfo;
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
    public void btnInfo()
    {
        PanelInfo.SetActive(true);
    }
    public void btnClosePanelInfo()
    {
        PanelInfo.SetActive(false);
    }
}

