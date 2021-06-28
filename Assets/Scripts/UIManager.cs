using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private TextMeshProUGUI highScoreText;
    private TextMeshProUGUI scoreText;
    private GameObject pauseMenu, tutorial;
    private bool gamePaused;
    private float volume;
    private int seconds;

    private void Awake()
    {
        highScoreText = transform.Find("High Score Text (TMP)").GetComponent<TextMeshProUGUI>();
        scoreText = transform.Find("Score Text (TMP)").GetComponent<TextMeshProUGUI>();
        pauseMenu = transform.Find("Pause Menu").gameObject;
        tutorial = transform.Find("Tutorial").gameObject;
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        highScoreText.text = $"Recorde: {GameManager.Instance.HighScore}";
        scoreText.text = $"Pontos: {GameManager.Instance.Score}";

        if (Input.GetKeyDown(KeyCode.P))
        {
            gamePaused = !gamePaused;
            PauseGame(gamePaused);
        }

        seconds++;

        if (seconds / 60 > 30)
        {
            tutorial.SetActive(false);
        }
    }

    private void PauseGame(bool gamePaused)
    {
        if (gamePaused)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            volume = AudioListener.volume;
            AudioListener.volume = AudioListener.volume / 10;
        }
        else
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            AudioListener.volume = volume;
        }
    }

    public void ContinueGame()
    {
        gamePaused = false;
        PauseGame(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
