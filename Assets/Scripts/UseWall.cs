using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class UseWall : BaseActionnable
{
    [SerializeField] private GameObject canvasButton;

    private void Start()
    {
        canvasButton.SetActive(false);
    }

    protected override void StartSelect(SelectEnterEventArgs args)
    {
        base.StartSelect(args);
        canvasButton.SetActive(true);
    }
}
