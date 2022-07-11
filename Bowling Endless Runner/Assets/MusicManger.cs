using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManger : MonoBehaviour
{
    public AudioClip music;
    public bool isPlaying = true;
    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = music;
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.V))
        {
            if(isPlaying){
                GetComponent<AudioSource>().Pause();
                isPlaying = false;
            }
            else{
                GetComponent<AudioSource>().Play();
                isPlaying = true;
            }
        }
    }
}
