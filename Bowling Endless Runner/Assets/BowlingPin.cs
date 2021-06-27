using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingPin : MonoBehaviour
{
    public int scoreOnHit = 10;
    public float lifeTime = 2;
    bool hit;
    void OnCollisionEnter(Collision other){

        if (hit) return;

        if (other.transform.CompareTag("Player")
        || other.transform.CompareTag("Pin")){

            hit = true;
            Score.Instance.Increment(scoreOnHit);
            Destroy(gameObject, lifeTime);
        }
    }
}
