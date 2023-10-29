using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallJson : MonoBehaviour
{
    public static CallJson instance;

    public JsonSaves save;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if(!save) save = GetComponent<JsonSaves>();
    }
}
