using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Clamp_Drawer : BaseActionnable
{
    private Vector3 basePosition;
    private Quaternion baseRotation;
    private float prevInteractorPosZ;

    //private float zValue = 0f;

    private void Start()
    {
        basePosition = transform.position;
        baseRotation = transform.rotation;
    }
    protected override void ActionContinue(Vector3 interatorPosition)
    {
        base.ActionContinue(interatorPosition);
        if(prevInteractorPosZ == 0f)
        {
            prevInteractorPosZ = interatorPosition.z;
        }
        float delta = Mathf.Clamp(interatorPosition.z - prevInteractorPosZ,-0.01f,0.01f);
        transform.rotation = baseRotation; 
        prevInteractorPosZ = interatorPosition.z;

        transform.position = new Vector3(basePosition.x, basePosition.y, Mathf.Clamp(transform.position.z + delta, basePosition.z-0.57f , basePosition.z));
    }

    //Marche

    /*private void Update()
    {
        zValue = Mathf.Clamp(transform.position.z, 0.75f, 1.29f);
        transform.position = new Vector3(transform.position.x, transform.position.y, zValue);
    }*/
}
