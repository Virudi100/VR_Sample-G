using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Clamp_Drawer : BaseActionnable
{
    [Header("Position de Base")]
    private Vector3 basePosition;
    private Quaternion baseRotation;

    [Header("Valeur de clamp")]
    private Vector3 clampHautMax = new Vector3(0f,0.7597f,-0.6079999f);
    private Vector3 clampHautMin = new Vector3(0f,0.7597f,-1.138f);

    private Vector3 clampBasMax = new Vector3(0f, 0.456f, -0.6079999f);
    private Vector3 clampBasMin = new Vector3(0f, 0.456f, -1.138f);

    [Header("Position précédante de l'interactor")]
    private float prevInteractorPosZ;

    [Header("Base de donnée")]
    [SerializeField] private Data myData;

    private void Start()
    {
        if(gameObject.GetComponent<TiroirBas>() != null)        //Verifie si le tiroir est celui du haut
        {
            if (myData.tiroirBasLocation != Vector3.zero)       //si la position sauvegarder n'est pas celle par defaut je la recupère dans la base de donnée
            {
                basePosition = myData.tiroirBasLocation;
            }
            else
                basePosition = transform.localPosition;         //sinon je prend celle actuelle

            transform.localPosition = basePosition;             //je l'assigne a l'objet

            if (myData.tiroirBasRotation != Vector3.zero)       //si la rotation sauvegarder n'est pas celle par defaut je la recupere dans la base de donnée
            {
                baseRotation.eulerAngles = myData.tiroirBasRotation;    
            }
            else
                baseRotation = transform.localRotation;         //sinon je prend celle actuel

            transform.localPosition = basePosition;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        else if(gameObject.GetComponent<TiroirHaut>() != null)  //Verifie si le tiroir est celui du bas
        {
            if (myData.tiroirHautLocation != Vector3.zero)      //si la position sauvegarder n'est pas celle par defaut je la recupère dans la base de donnée
            {
                basePosition = myData.tiroirHautLocation;
            }
            else
                basePosition = transform.localPosition;         //sinon je prend celle actuelle

           // transform.localPosition = basePosition;             //je l'assigne a l'objet

            if (myData.tiroirHautRotation != Vector3.zero)       //si la rotation sauvegarder n'est pas celle par defaut je la recupere dans la base de donnée
            {
                baseRotation.eulerAngles = myData.tiroirHautRotation;
            }
            else
                baseRotation = transform.localRotation;          //sinon je prend celle actuel

            transform.localRotation = baseRotation;              //je l'assigne a l'objet
        }
    }

    protected override void ActionContinue(Vector3 interatorPosition)
    {
        base.ActionContinue(interatorPosition);
       
        if(prevInteractorPosZ == 0f)                    //si la position precedente = 0
        {
            prevInteractorPosZ = interatorPosition.z;
        }

        float delta = Mathf.Clamp(interatorPosition.z - prevInteractorPosZ,-0.01f,0.01f);       //calcule du delta entre la position precedante de la main et celui actuel

        transform.localRotation = baseRotation; 

        prevInteractorPosZ = interatorPosition.z;           //remplace la position precedante par celle de la frame actuel

        if (gameObject.GetComponent<TiroirHaut>() != null)
        {
            transform.localPosition = new Vector3(basePosition.x, basePosition.y, Mathf.Clamp(transform.localPosition.z + delta, clampHautMin.z, clampHautMax.z)); //deplacement le tiroir par rapport a la main et dans la limite du clamp

            myData.tiroirHautLocation = transform.localPosition;
            myData.tiroirHautRotation = transform.localRotation.eulerAngles;
        }
        else if (gameObject.GetComponent<TiroirBas>() != null)
        {
            transform.localPosition = new Vector3(basePosition.x, basePosition.y, Mathf.Clamp(transform.localPosition.z + delta, clampBasMin.z , clampBasMax.z)); ////deplacement le tiroir par rapport a la main et dans la limite du clamp

            myData.tiroirBasLocation = transform.localPosition;
            myData.tiroirBasRotation = transform.localRotation.eulerAngles;
        }
    }
}
