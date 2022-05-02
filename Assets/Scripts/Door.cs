using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Door : BaseActionnable
{
    [SerializeField] private Vector3 basePosition;
    [SerializeField] private Quaternion baseRotation;
    [SerializeField] private Vector3 prevPositionY;
    [SerializeField] private Transform pivotPorte;

    private void Start()
    {
        basePosition = transform.position;
        baseRotation = transform.rotation;
        pivotPorte = transform;
    }

    protected override void ActionContinue(Vector3 interatorPosition)
    {
        base.ActionContinue(interatorPosition);
        if (prevPositionY == Vector3.zero)
        {
            prevPositionY = interatorPosition;
        }
        Vector3 dc1 = prevPositionY-pivotPorte.position; //precedente position - point de pivot
        Vector3 dc2 = interatorPosition-pivotPorte.position; //position actuel - point de pivot

        float delta = Vector3.SignedAngle(dc1, dc2, Vector3.up);
        print("delta: " + delta);

        transform.position = basePosition;
        prevPositionY = interatorPosition;

        //transform.rotation = Quaternion.Euler(baseRotation.x, Mathf.Clamp(transform.localEulerAngles.y + delta, baseRotation.y - 0.1f, baseRotation.y), transform.localEulerAngles.z);
        transform.rotation = Quaternion.Euler(baseRotation.x, transform.localEulerAngles.y + delta, baseRotation.z);

        //mettre en simple
    }

}
    
