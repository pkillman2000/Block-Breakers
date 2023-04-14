using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private GameSession _gameSession;

    private void Start()
    {
        _gameSession = GameObject.Find("GameSession").GetComponent<GameSession>();
        if(_gameSession == null )
        {
            Debug.Log("Game Session is Null!");
        }
    }
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // Count number of scenes.  If last scene, go to first scene        
        if (currentSceneIndex == SceneManager.sceneCountInBuildSettings + 1)
        {
            _gameSession.ResetGame();
            Invoke("LoadEndScene", .1f);
        }
        else
        {
            Invoke("LoadIncrementedScene", .1f);
        }        
    }

    // The first _level of the game needs to always be called Level001
    public void LoadFirstLevel()
    {
        SceneManager.LoadScene("Level001");
    }

    public void LoadMainMenuReset()
    {        
        _gameSession.ResetGame();
        SceneManager.LoadScene(0);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadIncrementedScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadInstructionsScene()
    {
        SceneManager.LoadScene("Z_Instructions");
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
