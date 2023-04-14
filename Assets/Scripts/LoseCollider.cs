using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    SceneLoader _sceneLoader;

    private void Awake()
    {
        _sceneLoader = GameObject.Find("SceneLoader").GetComponent<SceneLoader>();
        if(_sceneLoader == null)
        {
            Debug.Log("Scene Loader is Null!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ball")
        {
            _sceneLoader.LoadEndScene();
        } 
        else if(collision.tag == "AdditionalBall")
        {
            Destroy(collision.gameObject);
        }
    }
}
