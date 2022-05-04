using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class ColorButton : MonoBehaviour
{
    [SerializeField] private GameObject myWall;
    private Color colorToApply;
    [SerializeField] private GameObject canvasButton;

    private void Start()
    {
        colorToApply = gameObject.GetComponent<Image>().color;
        
    }

    public void Exit()
    {
        //myWall.enabled = myWall.enabled;
        canvasButton.SetActive(false);
    }

    public void ChangeColor()
    {
        myWall.GetComponent<Renderer>().material.color = colorToApply;
        print("color changed");
    }
}