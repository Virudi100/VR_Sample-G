using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HoverInteratable : MonoBehaviour
{
    [SerializeField] private XRBaseInteractable interatable;
    private bool isHover = false;
    private Material defaultMat;
    [SerializeField] private Material hoverMat;
    [SerializeField] private Renderer objetToHover;


    private void Awake()
    {
        if (objetToHover == null)
        {
            defaultMat = gameObject.GetComponent<Renderer>().material;
        }
        else
            defaultMat = objetToHover.material;

            interatable = gameObject.GetComponent<XRBaseInteractable>();
        
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

    protected virtual void HoverEnter(HoverEnterEventArgs args)
    {
        isHover = true;
    }

    protected virtual void HoverExit(HoverExitEventArgs args)
    {
        isHover = false;
    }

    private void Update()
    {
        if (objetToHover == null)
        {
            if (isHover)
            {
                gameObject.GetComponent<Renderer>().material = hoverMat;
            }
            else if (gameObject.GetComponent<Renderer>().material != defaultMat)
            {
                gameObject.GetComponent<Renderer>().material = defaultMat;
            }
        }
        else
        {
            if (isHover)
            {
                objetToHover.material = hoverMat;
            }
            else if (objetToHover.material != defaultMat)
            {
                objetToHover.material = defaultMat;
            }
        }
    }
}
