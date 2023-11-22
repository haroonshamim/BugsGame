using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameSwitcher : MonoBehaviour
{
    public void Load2dGame()
    {
        SceneManager.LoadScene("Bugs2dMainMenu");
    }
    public void Load3dGame()
    {
        SceneManager.LoadScene("IntroMenu");
    }
}
