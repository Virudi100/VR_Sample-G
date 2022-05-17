using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Light_Interruptor : BaseActionnable
{
    [SerializeField] private GameObject light;
    [SerializeField] private GameObject plafonnier;
    [SerializeField] private Data myData;

    private void Start()
    {
        if (myData.interruptorUsed == true)
        {
            light.SetActive(true);
        }
        else
            light.SetActive(false);
    }

    protected override void StartSelect(SelectEnterEventArgs args)
    {
        myData.interruptorUsed = true;

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

    protected override void StopSelect(SelectExitEventArgs args)
    {
        myData.interruptorUsed = false;
    }
}
