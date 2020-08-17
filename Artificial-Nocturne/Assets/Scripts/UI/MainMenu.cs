using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string level;
    public string menu;
    public string credits;

    public void StartGame()
    {
        SceneManager.LoadScene(level);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainReturn()
    {
        SceneManager.LoadScene(menu);
    }

    public void Credits()
    {
        SceneManager.LoadScene(credits);
    }
}
