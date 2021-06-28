using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    public GameObject initialMenu, optionsMenu, creditsMenu;
    private bool isFullscreen;

    private void Awake()
    {
        InitialMenu();
        isFullscreen = true;
        SetResolutuion(1920, 1080);
    }

    public void InitialMenu()
    {
        initialMenu.SetActive(true);
        optionsMenu.SetActive(false);
        creditsMenu.SetActive(false);
    }
    
    public void OptionsMenu()
    {
        optionsMenu.SetActive(true);
        initialMenu.SetActive(false);
        creditsMenu.SetActive(false);
    }
    
    public void CreditsMenu()
    {
        creditsMenu.SetActive(true);
        initialMenu.SetActive(false);
        optionsMenu.SetActive(false);
    }

    public void Play()
    {
        SceneManager.LoadScene("Initial Scene");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void SetFullscreen(bool fullscreen)
    {
        isFullscreen = fullscreen;
        Screen.fullScreen = isFullscreen;
    }


    public void SetResolutionIndex(int index)
    {
        switch (index)
        {
            case 0:
                {
                    SetResolutuion(1920, 1080);
                    break;
                }
            case 1:
                {
                    SetResolutuion(1360, 768);
                    break;
                }
            case 2:
                {
                    SetResolutuion(1280, 720);
                    break;
                }
        }
    }

    void SetResolutuion(int width, int height)
    {
        Screen.SetResolution(width, height, isFullscreen);
    }

    public void EraseData()
    {
        PlayerPrefs.DeleteAll();
    }
}
