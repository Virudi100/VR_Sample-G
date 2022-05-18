using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private bool isSaving = false;

    [Header("Base de donnée")]
    public Data myData;

    private void Awake()
    {
        SaveManager.Load();     //charge la sauvegarde au demarrage de l'application
    }

    void Update()
    {
        if (isSaving == false)      //est ce que le jeu est entrain de sauvegarder
        {
            isSaving = true;
            StartCoroutine(Saving());
        }
    }

    IEnumerator Saving()
    {
        SaveManager.Save(myData);       //sauvegarde la partie toute les 5sec

        yield return new WaitForSeconds(5f);
        isSaving = false;
    }
}
