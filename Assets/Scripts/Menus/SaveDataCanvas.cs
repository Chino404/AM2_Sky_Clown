using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDataCanvas : MonoBehaviour
{
    public GameObject menuCanvas;
    [SerializeField] float _seconds;
    void Start()
    {
        StartCoroutine(ActivateCanvas());
    }

    IEnumerator ActivateCanvas()
    {
        yield return new WaitForSeconds(_seconds);
        menuCanvas.SetActive(true);
        gameObject.SetActive(false);
    }

    
}
