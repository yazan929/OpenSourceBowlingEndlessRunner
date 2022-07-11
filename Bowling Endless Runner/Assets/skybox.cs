﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skybox : MonoBehaviour
{
    public Material[] skyBox;//SkyBox Materials..

    void Start()
    {
        RenderSettings.skybox = skyBox[Random.Range(0, skyBox.Length)];
    }


    void Update()
    {
        int i = Random.Range(0, skyBox.Length);

        if(Input.GetKey(KeyCode.Tab))
        {
            RenderSettings.skybox = skyBox[i];
            i = Random.Range(0, skyBox.Length);
        }
    }
}
