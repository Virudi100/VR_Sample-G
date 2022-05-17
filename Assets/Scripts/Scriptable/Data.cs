using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create MyScriptableObject")]
public class Data : ScriptableObject
{
    [Header("Save Door Location")]
    public Vector3 doorLocation = Vector3.zero;
    public Vector3 doorRotation = Vector3.zero;

    [Header("Save Door Location")]
    public Vector3 tiroirHautLocation = Vector3.zero;
    public Vector3 tiroirHautRotation = Vector3.zero;

    public Vector3 tiroirBasLocation = Vector3.zero;
    public Vector3 tiroirBasRotation = Vector3.zero;

    [Header("Save Sphere Location")]
    public Vector3 ballLocation = Vector3.zero;
    public Vector3 ballRotation = Vector3.zero;

    [Header("Save Cube Location")]
    public Vector3 cubeLocation = Vector3.zero;
    public Vector3 cubeRotation = Vector3.zero;

    [Header("Save Lama Location")]
    public Vector3 lamaLocation = Vector3.zero;
    public Vector3 lamaRotation = Vector3.zero;

    [Header("Save Light Interruptor")]
    public bool interruptorUsed = false;

    /*[Header("Save Wall Matérial")]
    public Material wallDoorMat;
    public Material wallMeubleMat;
    public Material wallWindowMat;
    public Material wallTargetMat;
    */

    [Header("Save Score Target")]
    public int scoreTarget;
}
