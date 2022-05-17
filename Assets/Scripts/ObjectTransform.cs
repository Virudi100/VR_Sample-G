using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTransform : MonoBehaviour
{
    [SerializeField] private Data myDatas;

    private void Start()
    {
        if (gameObject.GetComponent<Sphere>() != null)
        {
            if (myDatas.ballLocation != Vector3.zero)
            {
                gameObject.transform.position = myDatas.ballLocation;
            }
            
            if(myDatas.ballRotation != Vector3.zero)
            {
                gameObject.transform.eulerAngles = myDatas.ballRotation;
            }
        }

        if (gameObject.GetComponent<Cube>() != null)
        {
            if(myDatas.cubeLocation != Vector3.zero)
            {
                gameObject.transform.position = myDatas.cubeLocation;
            }

            if(myDatas.cubeRotation != Vector3.zero)
            {
                gameObject.transform.eulerAngles = myDatas.cubeRotation;
            }            
        }

        if (gameObject.GetComponent<Lama>() != null)
        {
            if(myDatas.lamaLocation != Vector3.zero)
            {
                gameObject.transform.position = myDatas.lamaLocation;
            }

            if(myDatas.lamaRotation != Vector3.zero)
            {
                gameObject.transform.eulerAngles = myDatas.lamaRotation;
            }
            
        }
    }

    private void Update()
    {
        if(gameObject.GetComponent<Sphere>() != null)
        {
            myDatas.ballLocation = gameObject.transform.position;
            myDatas.ballRotation = gameObject.transform.eulerAngles;
        }

        if(gameObject.GetComponent<Cube>() != null)
        {
            myDatas.cubeLocation = gameObject.transform.position;
            myDatas.cubeRotation = gameObject.transform.eulerAngles;
        }

        if(gameObject.GetComponent<Lama>() != null)
        {
            myDatas.lamaLocation = gameObject.transform.position;
            myDatas.lamaRotation = gameObject.transform.eulerAngles;
        }
    }
}
