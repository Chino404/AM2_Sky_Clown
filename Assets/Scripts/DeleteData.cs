using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DeleteData : MonoBehaviour
{
    public Button boton;

    private void Awake()
    {
        boton = GetComponent<Button>();
    }

    void Start()
    {
        boton.onClick.AddListener(CallJson.instance.save.DeleteJSON);  
    }
}
