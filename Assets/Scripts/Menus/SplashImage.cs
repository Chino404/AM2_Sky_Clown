using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashImage : MonoBehaviour
{
    [SerializeField] float _seconds;
    void Start()
    {
        StartCoroutine(MainMenu());
    }

    IEnumerator MainMenu()
    {
        yield return new WaitForSeconds(_seconds);
        SceneManager.LoadScene(1);
    }

    
}
