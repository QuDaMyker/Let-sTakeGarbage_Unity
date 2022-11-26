using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    
    
	public GameObject pausePanelBegin;
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

