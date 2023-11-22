using Unity.FPS.Game;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Unity.FPS.UI
{
    public class LoadSceneButton : MonoBehaviour
    {
        public string SceneName = "";

        void Update()
        {
            if (EventSystem.current.currentSelectedGameObject == gameObject
                && ControlFreak2.CF2Input.GetButtonDown(GameConstants.k_ButtonNameSubmit))
            {
                LoadTargetScene();
            }
        }

        public void LoadTargetScene()
        {

            if (SceneName.Equals("Level1"))
                PlayerPrefs.SetInt("SelectedLevel", 1);
            else if (SceneName.Equals("Level2"))
                PlayerPrefs.SetInt("SelectedLevel", 2);
            else if (SceneName.Equals("Level3"))
                PlayerPrefs.SetInt("SelectedLevel", 3);
            else if (SceneName.Equals("Level4"))
                PlayerPrefs.SetInt("SelectedLevel", 4);

            SceneManager.LoadScene(SceneName);
        }
        public void ReloadGame()
        {
            int CurrentLevel = PlayerPrefs.GetInt("SelectedLevel", 1);
            
                string NewLevel = "Level" + CurrentLevel;
                PlayerPrefs.SetInt("SelectedLevel", CurrentLevel);
                SceneManager.LoadScene(NewLevel);
            
        }
        public void Back()
        {
            SceneManager.LoadScene("GameSwitcher");
        }
        public void LoadNextScene()
        {
            int CurrentLevel= PlayerPrefs.GetInt("SelectedLevel", 1);
            if(CurrentLevel==4)
            {
                SceneManager.LoadScene("IntroMenu");
            }
            else
            {
                CurrentLevel++;
                string NewLevel = "Level" + CurrentLevel;
                PlayerPrefs.SetInt("SelectedLevel", CurrentLevel);
                SceneManager.LoadScene(NewLevel);
            }
        }
    }
}