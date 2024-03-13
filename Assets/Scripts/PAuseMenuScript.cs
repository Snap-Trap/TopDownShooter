using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PAuseMenuScript : MonoBehaviour
{
    public GameObject PauseMenu;
    public static bool isPaused;
    public GameObject HelpMenu;
    public GameObject EerstePause;

    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
        HelpMenu.SetActive(false);

        


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isPaused) 
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }

        }
    }

    public void PauseGame()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void ResumeGame()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

    }
    public void QuitGame() 
    {
        Application.Quit();
    }

    public void Helpmenu()
    { 
       PauseMenu.SetActive(false);
       HelpMenu.SetActive(true);
    }

    

    public void GoBack()
    {
        PauseMenu.SetActive(true);
        HelpMenu.SetActive(false);
    }
}
