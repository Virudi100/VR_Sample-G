using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class ColorButton : MonoBehaviour
{
    [Header("Wall GameObject")]
    [SerializeField] private GameObject myWall;

    [Header("Couleur a utilis� avec le button actuel")]
    private Color colorToApply;

    [Header("Canvas du bouton actuel")]
    [SerializeField] private GameObject canvasButton;

    private void Start()
    {
        colorToApply = gameObject.GetComponent<Image>().color;      //recupere la couleur a appliqu� sur la couleur du boutton lui meme
    }

    public void Exit()
    {
        canvasButton.SetActive(false);  //d�sactive le canvas
    }

    public void ChangeColor()
    {
        myWall.GetComponent<Renderer>().material.color = colorToApply;  //change la couleur du mur
    }
}