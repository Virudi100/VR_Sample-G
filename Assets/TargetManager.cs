using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetManager : MonoBehaviour
{
    [SerializeField] private AudioSource goal;
    [SerializeField] private Text scoreUI;
    [SerializeField] private Material lightGreen;
    [SerializeField] private Material lightRed;
    [SerializeField] private GameObject lightTarget;

    [SerializeField] private Data myData;

    private void Start()
    {
        lightTarget.GetComponent<Renderer>().material = lightGreen;
        RefreshScore();
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Object"))
        {
            myData.scoreTarget++;
            RefreshScore();
            goal.Play();
            StartCoroutine(LedGoal());
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
