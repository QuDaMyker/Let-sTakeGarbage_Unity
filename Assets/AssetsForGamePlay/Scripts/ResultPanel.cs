using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ResultPanel : MonoBehaviour
{
    public GameObject resultPanel;
    public float score;
    public int minScore;
    public Text scoreTxt;
    public Text infoTxt;
    public TextMeshProUGUI playbtnTxt;
    public GameObject playBtn;
    bool isFinished = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //End game and show panel
        if (GameController.instance.Timeout == 0)
        {
            resultPanel.SetActive(true);
            Time.timeScale = 0;
            ShowStatus();
        }
    }
    void ShowStatus()
    {
        if (GameController.instance.Score >= GameController.instance.minScore)
        {
            if (SceneManager.GetActiveScene().name=="Lv2"){
                scoreTxt.text = "Bravo! You are the winner! ";
                playBtn.SetActive(false);
                isFinished = true;
                return;
            }
            scoreTxt.text = "Congratulation! You have finished the stage with " + GameController.instance.Score.ToString() + " points!";
            playbtnTxt.text = "Next Stage";
            isFinished = true;
        }
        else
        {
            scoreTxt.text = "Sorry you need " + GameController.instance.Score.ToString() +"/" + GameController.instance.minScore.ToString() + " to finish the stage!";
            playbtnTxt.text = "Play Again";
            isFinished = false;
        }
    }
    public void Continue()
    {
        if (isFinished)
        {

            SceneManager.LoadScene("mainMenu");
            Application.LoadLevel("Lv2");
        }
        else
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
    public void BacktoMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }
}
