using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenuControl : MonoBehaviour
{

    public Button startGameBtn;
    public Button optionsBtn;
    public Button quitBtn;

    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void EnterOptionsScene()
    {
        Debug.Log("Options!");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
