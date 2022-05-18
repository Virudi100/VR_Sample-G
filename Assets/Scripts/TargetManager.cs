using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetManager : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioSource goal;

    [Header("UI Elements")]
    [SerializeField] private Text scoreUI;

    [Header("Led Materials")]
    [SerializeField] private Material lightGreen;
    [SerializeField] private Material lightRed;

    [Header("led GameObject")]
    [SerializeField] private GameObject lightTarget;

    [Header("Base de donnée")]
    [SerializeField] private Data myData;

    private void Start()
    {
        lightTarget.GetComponent<Renderer>().material = lightGreen;     //recup le matérial vert
        RefreshScore();     //Fonction pour changer le score afficher sur l'ui
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Object"))     //quand un objet entre en collision avec la cible
        {
            myData.scoreTarget++;       //Score +1
            RefreshScore();             //Actualise le score sur l'ui
            goal.Play();                //Joue le son de "but"
            StartCoroutine(LedGoal());  //Change la couleur de la led en rouge puis apres 0.5sec repasse bleu
        }
    }

    private void RefreshScore()
    {
            scoreUI.text = myData.scoreTarget.ToString();
    }

    IEnumerator LedGoal()
    {
        lightTarget.GetComponent <Renderer>().material = lightRed;
        yield return new WaitForSeconds(0.5f);
        lightTarget.GetComponent<Renderer>().material = lightGreen;
    }
}
