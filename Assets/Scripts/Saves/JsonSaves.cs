using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class JsonSaves : MonoBehaviour
{
    [SerializeField] SaveData saveData = new SaveData();
    string _path = ""; //Es la barra que aparece arriba en los archivos, para buscarlos

    private void Awake()
    {

        //path = Application.persistentDataPath + "/SaveData"; //Basico y predeterminado

        string customDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).Replace("\\", "/") + "/" + Application.companyName + "/"
                + Application.productName + "/SaveData";//Mas pro, Customisiado

        if (!Directory.Exists(customDir)) //Si no existe la creo
            Directory.CreateDirectory(customDir);

        _path = customDir + "/Saves.Json";

        Debug.Log(_path);
    }

    private void OnApplicationQuit()
    {
        SaveJSON();
    }


    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            SaveJSON();
        }
    }


    private void Start()
    {
        CallJson.instance.save = this;

        LoadJSON();
        print("Cargó!!!!!!!!!!");
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            SaveJSON();
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            LoadJSON();
        }
    }

    public void SaveJSON()
    {
        string json = JsonUtility.ToJson(saveData, true); //Hacemos un string en donde se va a crear el archivo de JSON y en los parametros le ponemos true para que me lo cree ordenado.
        File.WriteAllText(_path, json); //Me crea un archivo JSON con los datos que estan en SaveData, me lo escribe.
        JSONCheck();


        Debug.Log(json);
    }

    public void LoadJSON()
    {
        JSONCheck();
        string json = File.ReadAllText(_path); //Me lee el archivo de esa ubicacion, es para acceder a archivos.
        JsonUtility.FromJsonOverwrite(json, saveData); //Sobrescribo los datos, le digo en donde esta (json) y le paso los datos (saveData).
    }

    private void JSONCheck()
    {
        if (!File.Exists(_path))
        {
            Debug.LogWarning($"No existe ese camino para guardar/cargar.");

            string json = JsonUtility.ToJson(saveData, true);
            File.WriteAllText(_path, json); //Me crea un archivo JSON con los datos que estan en SaveData, me lo escribe.
        }
    }

    public void DeleteJSON()
    {
        Debug.LogWarningFormat("Se borro el save data");
        File.Delete(_path);

        CallJson.instance.save.GetSaveData.tutorialCompletedJSON = false;
        CallJson.instance.save.GetSaveData.moneyJSON = 0;

        //saveData = new SaveData();//Si quiero resetear los datos
    }

    public SaveData GetSaveData { get { return saveData; } }
}
