using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skybox : MonoBehaviour
{
    public Material[] skyBox;//SkyBox Materials..

    void Start()
    {

        RenderSettings.skybox = skyBox[Random.Range(0, skyBox.Length)];



    }
}
