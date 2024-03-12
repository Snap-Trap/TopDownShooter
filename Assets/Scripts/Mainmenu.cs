using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Helpmenu()
    {
        SceneManager.LoadScene("HelpScene");
    }
    public void GOBACK()
    {
        SceneManager.LoadScene("Mainmenu");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
