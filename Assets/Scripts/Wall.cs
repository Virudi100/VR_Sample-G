using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRSimpleInteractable))]
public class Wall : MonoBehaviour
{
    private XRSimpleInteractable interatable;
    private bool isHover = false;
    private Material defaultMat;
    [SerializeField] private Material hoverMat;

    private void Awake()
    {
        defaultMat = GetComponent<Renderer>().material;
        interatable = gameObject.GetComponent<XRSimpleInteractable>();
    }

    private void OnEnable()
    {
        interatable.hoverEntered.AddListener(HoverEnter);
        interatable.hoverExited.AddListener(HoverExit);
    }

    private void OnDisable()
    {
        interatable.hoverEntered.RemoveListener(HoverEnter);
        interatable?.hoverExited.RemoveListener(HoverExit);
    }

    private void HoverEnter(HoverEnterEventArgs args)
    {
        isHover = true;
    }

    private void HoverExit(HoverExitEventArgs args)
    {
        isHover= false;
    }

    private void Update()
    {
        if(isHover)
        {
            gameObject.GetComponent<Renderer>().material = hoverMat;
        }
        else if(gameObject.GetComponent<Renderer>().material != defaultMat)
        {
            gameObject.GetComponent<Renderer>().material = defaultMat;
        }
    }
}
