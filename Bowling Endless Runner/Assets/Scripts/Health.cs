using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{   
    public int fullHealth;
    public int currentHealth;
    public int lowHealthThreshold;
    public GameObject healthIconPrefab;
    public Transform container;
    public UnityEvent onDeathEvent;
    public UnityEvent onLowHealthEvent;
    public UnityEvent onFullHealthEvent;
    List<GameObject> healthIcons = new List<GameObject>();

    void Start(){

        for (int i=0; i < fullHealth; i++){

            GameObject healthIcon = Instantiate(healthIconPrefab, container);
            healthIcons.Add(healthIcon);
        }

        currentHealth = fullHealth;
    }

    void OnEnable(){

        onDeathEvent.AddListener(OnDeath);
        onFullHealthEvent.AddListener(OnFullHealth);
        onLowHealthEvent.AddListener(OnLowHealth);
    }

    void OnDisable(){

        onDeathEvent.RemoveListener(OnDeath);
        onFullHealthEvent.RemoveListener(OnFullHealth);
        onLowHealthEvent.RemoveListener(OnLowHealth);
    }
    
    public void Heal(int amount){

        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, fullHealth);

        UpdateHealthIcons();

        if (currentHealth >= fullHealth) onFullHealthEvent.Invoke();
    }

    public void Damage(int amount){

        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, fullHealth);

        UpdateHealthIcons();

        if (currentHealth == 0) onDeathEvent.Invoke();
        if (currentHealth <= lowHealthThreshold) onLowHealthEvent.Invoke();
    }

    void UpdateHealthIcons(){

        foreach(GameObject icon in healthIcons){

            icon.SetActive(false);
        }

        for (int i=0; i < currentHealth; i++){

            healthIcons[i].SetActive(true);
        }
    }
    
    void OnDeath(){

        Debug.Log("character: " + transform.name + " Died!");
    }
    void OnLowHealth(){

        Debug.Log("character: " + transform.name + " Low health!");
    }
    void OnFullHealth(){

        Debug.Log("character: " + transform.name + " Full health!");
    }
}
