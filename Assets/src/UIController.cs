using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static int score;
    public const int ScoreMax = 500; 
    GameObject scoreText;

    public void AddScore()
    {
        score += 10;
    }

    public void GameClear()
    {
        if ( score >= ScoreMax)
        {
            SceneManager.LoadScene("GameClear");
        }
    }
        // Start is called before the first frame update
        void Start()
    {
        this.scoreText = GameObject.Find("Score");
        score = 10;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.GetComponent<Text>().text = "Score:" + score.ToString("D3") + "/500";
        GameClear();
    }
}
