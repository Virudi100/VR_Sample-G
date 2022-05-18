using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveManager
{
    public static string directory = "/SaveData/";          //dossier de la sauvegarde
    public static string fileName = "MyData.txt";           //nom du fichier de la sauvegarde

    public static void Save(Data myData)                    //fonction de sauvegarde
    {
        string dir = Application.persistentDataPath + directory;    //recupere le chemin de la sauvegarde

        if (!Directory.Exists(dir))                         //si le dossier exist pas il en creer un
            Directory.CreateDirectory(dir);

        string json = JsonUtility.ToJson(myData);           //ça converti le contenu de Data en string
        File.WriteAllText(dir + fileName, json);            //ecrit le contenu sur le fichier mydata.txt
    }

    public static Data Load()                               //fonction de rechargement
    {
        Data myData = new Data();

        myData = GameObject.FindWithTag("LevelManager").GetComponent<LevelManager>().myData;    //recupere la base de donnée sur le level manager
        string fullpath = Application.persistentDataPath + directory + fileName;            //recupere le chemin de la sauvegarde
        

        if(File.Exists(fullpath))       //si la sauvegarde existe, on recupere les donnée et on les utilises pour remplacer ceux de la base de donnée
        {
            string json = File.ReadAllText(fullpath);
            JsonUtility.FromJsonOverwrite(json,myData);
        }
        else
        {
            Debug.Log("Save file does not exist");      //log si le ficher existe pas
        }

        return myData;
    }
}
