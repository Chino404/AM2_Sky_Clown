using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialButton : MonoBehaviour
{
    public Button boton;

    private void Awake()
    {
        boton = GetComponent<Button>();
    }

    void Start()
    {
        boton.onClick.AddListener(GameManager.instance.TutorialLevel);
    }
}
