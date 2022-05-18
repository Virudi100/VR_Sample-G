using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTransform : MonoBehaviour
{
    [Header("Base de donnée")]
    [SerializeField] private Data myDatas;

    private void Start()
    {
        if (gameObject.GetComponent<Sphere>() != null)          //verifie si l'objet est la sphere
        {
            if (myDatas.ballLocation != Vector3.zero)           //si la position sauvegarder n'est pas celle par defaut je la recupère dans la base de donnée
            {
                gameObject.transform.position = myDatas.ballLocation;
            }
            
            if(myDatas.ballRotation != Vector3.zero)            //si la position sauvegarder n'est pas celle par defaut je la recupère dans la base de donnée
            {
                gameObject.transform.eulerAngles = myDatas.ballRotation;
            }
        }

        if (gameObject.GetComponent<Cube>() != null)            //verifie si l'objet est le cube
        {
            if(myDatas.cubeLocation != Vector3.zero)            //si la position sauvegarder n'est pas celle par defaut je la recupère dans la base de donnée
            {
                gameObject.transform.position = myDatas.cubeLocation;
            }

            if(myDatas.cubeRotation != Vector3.zero)            //si la position sauvegarder n'est pas celle par defaut je la recupère dans la base de donnée
            {
                gameObject.transform.eulerAngles = myDatas.cubeRotation;
            }            
        }

        if (gameObject.GetComponent<Lama>() != null)            //verifie si l'objet est le lama
        {
            if(myDatas.lamaLocation != Vector3.zero)            //si la position sauvegarder n'est pas celle par defaut je la recupère dans la base de donnée
            {
                gameObject.transform.position = myDatas.lamaLocation;
            }

            if(myDatas.lamaRotation != Vector3.zero)            //si la position sauvegarder n'est pas celle par defaut je la recupère dans la base de donnée
            {
                gameObject.transform.eulerAngles = myDatas.lamaRotation;
            }
        }
    }

    private void Update()
    {
        if(gameObject.GetComponent<Sphere>() != null)           //verifie si l'objet est la sphere
        {
            myDatas.ballLocation = gameObject.transform.position;       //enregistre la position dans la base de donnée
            myDatas.ballRotation = gameObject.transform.eulerAngles;
        }

        if(gameObject.GetComponent<Cube>() != null)             //verifie si l'objet est le cube
        {
            myDatas.cubeLocation = gameObject.transform.position;       //enregistre la position dans la base de donnée
            myDatas.cubeRotation = gameObject.transform.eulerAngles;
        }

        if(gameObject.GetComponent<Lama>() != null)             //verifie si l'objet est le lama
        {
            myDatas.lamaLocation = gameObject.transform.position;       //enregistre la position dans la base de donnée
            myDatas.lamaRotation = gameObject.transform.eulerAngles;
        }
    }
}
