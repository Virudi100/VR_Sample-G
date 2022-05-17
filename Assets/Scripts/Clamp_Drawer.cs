using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Clamp_Drawer : BaseActionnable
{
    private Vector3 basePosition;
    private Quaternion baseRotation;

    private Vector3 clampHautMax = new Vector3(0f,0.7597f,-0.6079999f);
    private Vector3 clampHautMin = new Vector3(0f,0.7597f,-1.138f);

    private Vector3 clampBasMax = new Vector3(0f, 0.456f, -0.6079999f);
    private Vector3 clampBasMin = new Vector3(0f, 0.456f, -1.138f);

    private float prevInteractorPosZ;
    [SerializeField] private Data myData;

    private void Start()
    {
        if(gameObject.GetComponent<TiroirBas>() != null)
        {
            if (myData.tiroirBasLocation != Vector3.zero)
            {
                basePosition = myData.tiroirBasLocation;
            }
            else
                basePosition = transform.localPosition;

            transform.localPosition = basePosition;

            if (myData.tiroirBasRotation != Vector3.zero)
            {
                baseRotation.eulerAngles = myData.tiroirBasRotation;
            }
            else
                baseRotation = transform.localRotation;
        }
        else if(gameObject.GetComponent<TiroirHaut>() != null)
        {
            if (myData.tiroirHautLocation != Vector3.zero)
            {
                basePosition = myData.tiroirHautLocation;
            }
            else
                basePosition = transform.localPosition;

            transform.localPosition = basePosition;

            if (myData.tiroirHautRotation != Vector3.zero)
            {
                baseRotation.eulerAngles = myData.tiroirHautRotation;
            }
            else
                baseRotation = transform.localRotation;
        }

        transform.localRotation = baseRotation;
    }

    protected override void ActionContinue(Vector3 interatorPosition)
    {
        base.ActionContinue(interatorPosition);
       
        if(prevInteractorPosZ == 0f)
        {
            prevInteractorPosZ = interatorPosition.z;
        }
        float delta = Mathf.Clamp(interatorPosition.z - prevInteractorPosZ,-0.01f,0.01f);
        transform.localRotation = baseRotation; 
        prevInteractorPosZ = interatorPosition.z;

        if (gameObject.GetComponent<TiroirHaut>() != null)
        {
            transform.localPosition = new Vector3(basePosition.x, basePosition.y, Mathf.Clamp(transform.localPosition.z + delta, clampHautMin.z, clampHautMax.z));

            myData.tiroirHautLocation = transform.localPosition;
            myData.tiroirHautRotation = transform.localRotation.eulerAngles;
        }
        else if (gameObject.GetComponent<TiroirBas>() != null)
        {
            transform.localPosition = new Vector3(basePosition.x, basePosition.y, Mathf.Clamp(transform.localPosition.z + delta, clampBasMin.z , clampBasMax.z));

            myData.tiroirBasLocation = transform.localPosition;
            myData.tiroirBasRotation = transform.localRotation.eulerAngles;
        }
    }
}
