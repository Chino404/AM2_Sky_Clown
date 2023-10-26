using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnergyBar : MonoBehaviour
{
    public static EnergyBar instance;
    private Slider _slider;
    public TextMeshProUGUI _numberEnergy;

    private void Awake()
    {
        if (instance == null)
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

    void Start()
    {
        _slider = GetComponent<Slider>();
    }

    public void ChangeMaxEnerfy(int maxEnergy)
    {
        _slider.maxValue = maxEnergy;
    }

    public void ChangeActualEnergy(int cantEnergy)
    {
        _numberEnergy.text = cantEnergy.ToString();
        _slider.value = cantEnergy;
    }

    //public void InitializeEnergyBar(int cantEnergy)
    //{
    //    ChangeMaxEnerfy(cantEnergy);
    //    ChangeActualEnergy(cantEnergy);
    //}
}
