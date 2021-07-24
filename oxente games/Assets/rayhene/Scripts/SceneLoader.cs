using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public int sceneIndex;
    void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
