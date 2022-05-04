using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HoverButton : HoverInteratable
{
    [SerializeField] private XRSimpleInteractable simpleInteractable;
    [SerializeField] private GameObject hisSelectedSprite;

    private void Start()
    {
        hisSelectedSprite.SetActive(false);
    }

    protected override void HoverEnter(HoverEnterEventArgs args)
    {
        hisSelectedSprite.SetActive(true);
    }

    protected override void HoverExit(HoverExitEventArgs args)
    {
        hisSelectedSprite.SetActive(false);
    }

}
