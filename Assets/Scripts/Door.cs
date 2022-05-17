using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Door : BaseActionnable
{
    [SerializeField] private Vector3 basePosition;
    [SerializeField] private Vector3 baseRotation;
    [SerializeField] private Vector3 prevPositionY;
    [SerializeField] private Transform pivotPorte;
    [SerializeField] private Data myData;

    private void Start()
    {
        if (myData.doorLocation != Vector3.zero)
        {
            basePosition = myData.doorLocation;
        }
        else
            basePosition = transform.localPosition;

        if (myData.doorRotation != Vector3.zero)
        {
            baseRotation = myData.doorRotation;
        }
        else
            baseRotation = transform.localRotation.eulerAngles;

        transform.localEulerAngles = baseRotation;

        pivotPorte = transform;
    }

    protected override void ActionContinue(Vector3 interatorPosition)
    {
        base.ActionContinue(interatorPosition);

        if (prevPositionY == Vector3.zero)
        {
            prevPositionY = interatorPosition;
        }

        Vector3 dc1 = prevPositionY - pivotPorte.position; //precedente position - point de pivot
        Vector3 dc2 = interatorPosition - pivotPorte.position; //position actuel - point de pivot

        float delta = Vector3.SignedAngle(dc1, dc2, Vector3.up);
        print("delta: " + delta);

        transform.localPosition = basePosition;
        prevPositionY = interatorPosition;

        transform.localRotation = Quaternion.Euler(baseRotation.x, Mathf.Clamp(transform.localEulerAngles.y + delta * 2, 272f, 359f), baseRotation.z);

        myData.doorLocation = transform.localPosition;
        myData.doorRotation = transform.localRotation.eulerAngles;     
    }
}
    
