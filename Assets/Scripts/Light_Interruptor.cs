using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Light_Interruptor : BaseActionnable
{
    [SerializeField] private GameObject light;
    [SerializeField] private GameObject plafonnier;

    protected override void StartSelect(SelectEnterEventArgs args)
    {
        print("Enter light selected");
        if(light.activeInHierarchy)
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
}
