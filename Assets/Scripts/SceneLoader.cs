using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // Count number of scenes.  If last scene, go to first scene        
        if (currentSceneIndex == SceneManager.sceneCountInBuildSettings + 1)
        {
            FindObjectOfType<GameSession>().ResetGame();
            Invoke("LoadEndScene", .1f);
        }
        else
        {
            Invoke("LoadIncrementedScene", .1f);
        }        
    }

    public void LoadStartScene()
    {        
        FindObjectOfType<GameSession>().ResetGame();
        SceneManager.LoadScene(0);
    }

    public void LoadIncrementedScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadEndScene()
    {
        SceneManager.LoadScene("Z_End Menu");
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
