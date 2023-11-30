using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallJson : MonoBehaviour
{
    public static CallJson instance;

    public JsonSaves save;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        if (!save) save = GetComponent<JsonSaves>();
    }
}
