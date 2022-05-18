using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Door : BaseActionnable
{
    [Header("Position / Rotation par defaut")]
    [SerializeField] private Vector3 basePosition;
    [SerializeField] private Vector3 baseRotation;

    [Header("Position précédente de la porte")]
    [SerializeField] private Vector3 prevPositionY;

    [Header("Transform de la porte")]
    [SerializeField] private Transform pivotPorte;

    [Header("Base de donnée")]
    [SerializeField] private Data myData;

    private void Start()
    {
        if (myData.doorLocation != Vector3.zero)        //si la position sauvegarder n'est pas celle par defaut je la recupère dans la base de donnée
        {
            basePosition = myData.doorLocation;
        }
        else
            basePosition = transform.localPosition;     //sinon j'utilise celle de l'objet

        if (myData.doorRotation != Vector3.zero)        //si la position sauvegarder n'est pas celle par defaut je la recupère dans la base de donnée
        {
            baseRotation = myData.doorRotation;
        }
        else
            baseRotation = transform.localRotation.eulerAngles;     //sinon j'utilise celle de l'objet

        transform.localEulerAngles = baseRotation;
        pivotPorte = transform;
    }

    protected override void ActionContinue(Vector3 interatorPosition)
    {
        base.ActionContinue(interatorPosition);

        if (prevPositionY == Vector3.zero)  //si la position sauvegarder est celle par defaut je recupère la position de l'interactor a la frame actuelle
        {
            prevPositionY = interatorPosition;
        }

        Vector3 dc1 = prevPositionY - pivotPorte.position;      //precedente position - point de pivot
        Vector3 dc2 = interatorPosition - pivotPorte.position;      //position actuel - point de pivot

        float delta = Vector3.SignedAngle(dc1, dc2, Vector3.up);    //delta entre la position de la porte et celle du controller

        transform.localPosition = basePosition;     //affecte la position par defaut
        prevPositionY = interatorPosition;      //change l'ancienne position par celle actuelle

        transform.localRotation = Quaternion.Euler(baseRotation.x, Mathf.Clamp(transform.localEulerAngles.y + delta * 2, 272f, 359f), baseRotation.z); //rotation par rapport au delta et dans la limite du clamp

        myData.doorLocation = transform.localPosition;
        myData.doorRotation = transform.localRotation.eulerAngles;     
    }
}
    
