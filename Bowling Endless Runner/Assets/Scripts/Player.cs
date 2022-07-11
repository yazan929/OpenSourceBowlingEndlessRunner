using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float forwardSpeed;
    public float sideSpeed;
    public int currentLives;
    public int maxLives;
    public float hitCooldown = .15f;

    public Health health;
    public InputButton right;
    public InputButton left;

    public static Player Instance;

    bool canLoseLife;
    float horizontal;
    Rigidbody rb;
    Animator animator;

    public AudioSource AudioSource;
    public AudioClip hitBlockerAudio;
    public AudioClip hitBoolingAudio;

    public bool isOutside = false;
    void Awake()
    {

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        Instance = this;
    }

    void Start()
    {

        health.onDeathEvent.AddListener(OnPlayerDeath);
        canLoseLife = true;
    }

    void Update()
    {

        horizontal = right.value + left.value; 
        if(gameObject.transform.position.x >= 8.3f || gameObject.transform.position.x <=2.0f){
            isOutside = true;
        }
        if (isOutside){
             gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;  
        }

        if (Input.GetKeyDown(KeyCode.R)) ResetLevel();

        if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene("Main menu");

    }

    void FixedUpdate()
    {

        Move();
    }

    void Move()
    {

        Vector3 vel = Vector3.forward * forwardSpeed;
        rb.velocity = new Vector3(vel.x, rb.velocity.y, vel.z);

        rb.AddForce(Vector3.right * horizontal * sideSpeed, ForceMode.VelocityChange);
    }

    void OnCollisionEnter(Collision other)
    {

        if (other.transform.CompareTag("Death"))
        {

            Debug.Log("IsDead!");
            ResetLevel();
        }

        if (other.transform.CompareTag("Blocker"))
        {

            if (canLoseLife)
            {

                animator.SetTrigger("hit");
                AudioSource.PlayOneShot(hitBlockerAudio);
                health.Damage(1);
            }

            canLoseLife = false;
            CancelInvoke("StartHitCooldown");
            Invoke("StartHitCooldown", hitCooldown);

            Destroy(other.gameObject);
        }


    }

    void StartHitCooldown()
    {

        canLoseLife = true;
    }

    void OnPlayerDeath()
    {

        //show ui
        //resetlevel

        ResetLevel();
    }


    public void ResetLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}