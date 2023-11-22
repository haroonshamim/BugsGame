using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomePage : MonoBehaviour
{
    public GameObject Animations;
    public void SetLevel(int i)
    {
        PlayerPrefs.SetInt("Level", i);
     

        if (i == 0)
        {
            Animations.SetActive(true);
            Invoke("LoadLevel", 22f);
        }
           
        else
            LoadLevel();
    }
    public void Back()
    {
        SceneManager.LoadScene("GameSwitcher");
    }
    public void LoadLevel()
    {
        SceneManager.LoadScene("Bugs2dGamePlay");
    }
    public void PlayGame ( )
    {
        PlayerPrefs.SetInt("Level", 0);
        Animations.SetActive(true);
        Invoke("LoadLevel", 22f);
    }
}