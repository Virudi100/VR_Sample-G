using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HoverButton : HoverInteratable
{
    [Header("XRInteractable")]
    [SerializeField] private XRSimpleInteractable simpleInteractable;

    [Header("Sprite de hover")]
    [SerializeField] private GameObject hisSelectedSprite;

    private void Start()
    {
        hisSelectedSprite.SetActive(false);     //desactive le sprite au demarrage
    }

    protected override void HoverEnter(HoverEnterEventArgs args)
    {
        hisSelectedSprite.SetActive(true);  //active le sprite au hover
    }

    protected override void HoverExit(HoverExitEventArgs args)
    {
        hisSelectedSprite.SetActive(false); //désactive le sprite au hover exit
    }

}
