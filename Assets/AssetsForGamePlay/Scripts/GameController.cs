using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    public float Timeout;
    public int Score;
    public int minScore = 0;
    public Text txtScore;
    public Text txtTimeout;
    public GameObject trashObj;
    public static GameController instance;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;   
    }
    void Start()
    {
        Time.timeScale = 1;
        Timeout = CONS.TimeOut;
        txtScore.text = "Score: " + Score.ToString();
        txtTimeout.text = "Time left: " + Timeout.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        if (Timeout == 0) return;
        UpdateTimeout();
        txtScore.text = "Score: " + Score.ToString();
        txtTimeout.text = "Time: " + Mathf.RoundToInt(Timeout).ToString();
    }
    void UpdateTimeout()
    {
        if (Timeout > 0)
        {
            Timeout -= Time.deltaTime;
        }
        else
        {
            Timeout = 0;
        }
    }
    // hàm cho bên ngoài dùng
    public void GainScore()
    {
        Score += CONS.DeltaScore;
    }
}
