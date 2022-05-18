using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BaseActionnable : MonoBehaviour
{
    [Header("XRInteractable")]
    public XRBaseInteractable interactable;

    [Header("Is action instantanée ?")]
    public bool actionInstantanee = true;

    [Header("Current objet is actualy being use ? ")]
    public bool isSelected = false;

    [Header("Transform de l'interactor")]
    public Transform interactorTransform;

    private void OnEnable()
    {
        interactable.selectEntered.AddListener(StartSelect);
        interactable.selectExited.AddListener(StopSelect);
    }

    private void OnDisable()
    {
        interactable.selectEntered.RemoveListener(StartSelect);
        interactable.selectExited.RemoveListener(StopSelect);
    }

    protected virtual void StartSelect(SelectEnterEventArgs args)
    {
        if(!actionInstantanee)      
        {
            isSelected = true;
            interactorTransform = args.interactorObject.transform;
        }
        else
        {
            ActionInstant();
        }
    }

    protected virtual void StopSelect(SelectExitEventArgs args)
    {
        if(!actionInstantanee)
        {
            isSelected = false;
        }
    }

    protected virtual void ActionInstant()
    {

    }

    protected virtual void ActionContinue(Vector3 interatorPosition)
    {

    }

    private void Update()
    {
        if(isSelected)
        {
            ActionContinue(interactorTransform.position);
        }
    }
}
