using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingPin : MonoBehaviour
{
    public int scoreOnHit = 10;
    public float lifeTime = 2;
    bool hit;
    public AudioClip AudioClip;
    
    void OnEnable()
    {
        gameObject.AddComponent<AudioSource>();
        AudioClip = Resources.Load("Collect") as AudioClip;

    }
    void OnCollisionEnter(Collision other){

        if (hit) return;

        if (other.transform.CompareTag("Player")
        || other.transform.CompareTag("Pin")){
            gameObject.GetComponent<AudioSource>().PlayOneShot(AudioClip);
            hit = true;
            Score.Instance.Increment(scoreOnHit);
            Destroy(gameObject, lifeTime);
        }
    }
}
