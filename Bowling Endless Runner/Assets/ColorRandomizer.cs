using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorRandomizer : MonoBehaviour
{
    public static float h;
    public static int direction = 1;
    void OnEnable(){

        MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer>();
        float counter = 1;
        foreach (MeshRenderer meshRenderer in meshRenderers){

            int materialIndex = meshRenderer.transform.tag == "Pin" ? 1 : 0;
            Color c = Color.HSVToRGB(h, .8f * (counter / 2), 1);
            meshRenderer.materials[materialIndex].color = c;
            counter++;
        }

        h += (.025f * direction);
        if (h > 1 || h < 0) direction *= -1;
    }   
}