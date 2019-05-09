using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{

    public Animator animator;

    private string sceneToLoadName;
    
    public void FadeToScene(string sceneName)
    {
        sceneToLoadName = sceneName;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComlete()
    {
        SceneManager.LoadScene(sceneToLoadName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
