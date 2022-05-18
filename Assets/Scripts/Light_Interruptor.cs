using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Light_Interruptor : BaseActionnable
{
    [Header("Light componant")]
    [SerializeField] private GameObject light;
    [SerializeField] private GameObject plafonnier;

    [Header("Base de donnée")]
    [SerializeField] private Data myData;

    private void Start()
    {
        if (myData.interruptorUsed == true)     //si l'interrupteur est eteint dans la base de donnée il s'allume et l'inverse
        {
            light.SetActive(true);
        }
        else
            light.SetActive(false);
    }

    protected override void StartSelect(SelectEnterEventArgs args)
    {
        myData.interruptorUsed = true;      //change la valeur dans la base de donnée

        if(light.activeInHierarchy)         //quand on utilise l'interrupteur, eteint la lumiere si elle est allumé et l'inverse
        {
            light.SetActive(false);
            plafonnier.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
        }
        else
        {
            light.SetActive(true);
            plafonnier.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        }
    }

    protected override void StopSelect(SelectExitEventArgs args)
    {
        myData.interruptorUsed = false;         //change la valeur dans la base de donnée
    }
}
