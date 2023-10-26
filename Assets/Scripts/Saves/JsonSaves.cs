using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonSaves : MonoBehaviour
{
    [SerializeField] SaveData saveData = new SaveData();
    string path = ""; //Es la barra que aparece arriba en los archivos, para buscarlos

    private void Awake()
    {

        //path = Application.persistentDataPath + "/SaveData"; //Basico y predeterminado

        string customDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).Replace("\\", "/") + "/" + Application.companyName + "/"
                + Application.productName + "/SaveData";//Mas pro, Customisiado

        if (!Directory.Exists(customDir)) //Si no existe la creo
            Directory.CreateDirectory(customDir);

        path = customDir + "/Saves.Json";

        Debug.Log(path);
    }

    private void OnApplicationQuit()
    {
        SaveJSON();
    }

    private void Start()
    {
        CallJson.instance.save = this;

        LoadJSON();
    }

    public void SaveJSON()
    {
        string json = JsonUtility.ToJson(saveData, true); //Hacemos un string en donde se va a crear el archivo de JSON y en los parametros le ponemos true para que me lo cree ordenado

        File.WriteAllText(path, json); //Me crea un archivo JSON con los datos que estan en SaveData, me lo escribe

        Debug.Log(json);
    }

    public void LoadJSON()
    {
        if (File.Exists(path))
        {
            Debug.LogWarning($"No hay archivo para cargar");
            return;
        }

        string json = File.ReadAllText(path); //Me lee el archivo de esa ubicacion, es para acceder a archivos

        if (json == null)
        {
            SaveJSON(); //Si no existe, creo uno
            json = File.ReadAllText(path);
        }

        JsonUtility.FromJsonOverwrite(json, saveData); //Sobrescribo los datos, le digo en donde esta (json) y le paso los datos (saveData)
    }

    public void DeleteJSON()
    {
        Debug.Log("Se borro el save data");
        File.Delete(path);

        //saveData = new SaveData();//Si quiero resetear los datos
    }

    public SaveData GetSaveData { get { return saveData; } }
}
