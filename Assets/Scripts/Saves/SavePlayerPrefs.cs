using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayerPrefs : MonoBehaviour
{
    public static SavePlayerPrefs instance;

    public string namePlayer = "";
    public int energy;

    public string appVersion = "";

    [Tooltip("Energia del jugador")]
    public const string energyKey = "Energy";
    public const string namePlayerKey = "PlayerName";


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        appVersion = Application.productName + " Version " + Application.version;
    }

    public void LoadVariables()
    {
        energy = PlayerPrefs.GetInt(energyKey, energy);
        namePlayer = PlayerPrefs.GetString(namePlayerKey, namePlayer);

        Debug.Log($"<color=magenta> Game loaded </color>");
    }

    public void SaveVariables(int energyV, string nameV)
    {
        PlayerPrefs.SetInt(energyKey, energyV);
        PlayerPrefs.SetString(namePlayerKey, nameV);

        PlayerPrefs.Save();
        Debug.Log($"<color=green> Game Saved </color>");
    }

    public void DeleteAllDatas()
    {
        PlayerPrefs.DeleteAll(); //Me borra las key y todo los valores que tenia adentro
        LoadVariables(); //Volveme a cargar las keys y me lo deja en predeterminado

        Debug.Log($"<color=red  > Deleted Data </color>");
    }

    public void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            //PlayerPrefs.SetInt("Energy", _energy);
            //PlayerPrefs.SetString("PlayerName", _namePlayer);
            PlayerPrefs.Save();
        }

        else
            SavePlayerPrefs.instance.LoadVariables();
    }

    //private void OnApplicationQuit()
    //{
    //    SaveVariables();
    //}

    //private void OnApplicationPause(bool pause)
    //{
    //    if(pause)
    //        SaveVariables();
    //    else
    //        LoadVariables();
    //}
}
