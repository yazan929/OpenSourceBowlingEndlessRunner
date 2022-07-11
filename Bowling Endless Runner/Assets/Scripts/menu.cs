using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menu : MonoBehaviour
{
    public GameObject menuPanel;
    public void Play(){
        SceneManager.LoadScene ("Level0");
    }
    public void Quit(){
        Application.Quit();
    }

    public void Menu(){
        menuPanel.SetActive(true);
    }

    public void CloseMenu(){
        menuPanel.SetActive(false);
    }

    
}
