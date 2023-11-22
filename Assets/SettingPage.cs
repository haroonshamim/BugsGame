using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine. SceneManagement;
using UnityEngine.UI;
public class SettingPage : MonoBehaviour
{
    //public Slider MusicSlider;
    //public Slider SoundSlider;
    public void Start()
    {
        //MusicSlider.value = PlayerPrefs.GetFloat("MUSIC", 1);
        //SoundSlider.value = PlayerPrefs.GetFloat("SOUND", 1);

    }
    public void QuitGame ( )
    {
        Debug.Log("QUIT!");
        Application.Quit ();
    }
    //public void ChangeMusic()
    //{
    //    PlayerPrefs.SetFloat("MUSIC", MusicSlider.value);
    //}
    //public void ChangeSound()
    //{
    //    PlayerPrefs.SetFloat("SOUND", SoundSlider.value);
    //}
}