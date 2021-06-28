using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int score;
    private int highScore;
    private float highestPlayerHeight;
    private int difficulty = 1;

    public int Difficulty => difficulty;

    public int Score => score;
    public int HighScore => highScore;

    private void Awake()
    {
        Instance = this;
        highScore = PlayerPrefs.GetInt("HighScore");
    }

    private void Update()
    {
        if (Player.Instance.transform.position.y > highestPlayerHeight)
        {
            score++;
            highestPlayerHeight = Player.Instance.transform.position.y;
        }

        if (score > highScore)
        {
            highScore = score;
        }

        if (Player.Instance.transform.position.y > 2000 && Player.Instance.transform.position.y < 4999)
        {
            difficulty = 2;
        }
        else if (Player.Instance.transform.position.y > 5000)
        {
            difficulty = 3;
        }
    }

    public void SaveHighScore()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
    }
}
