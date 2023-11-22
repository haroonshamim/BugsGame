using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class QuestionManager2 : MonoBehaviour
{
    public static QuestionManager2 instance;

    public AudioSource CorrectSound;
    public AudioSource WrongSound;

    [HideInInspector]
    public Question2 CurrentQuestion;
    public int TotalMistakes;
    public int CorrectlyMarked;
    public Text CurrentMarkedText;
    public GameObject Proceed;
    public Question2[] AllQuestions;

    public int levelnumber = 1;
    int CurrentQuestionIndex = 0;
    public GameObject Panel;
    public int PlayerHealth = 3;

    public GameObject[] ThingsToToogle;
    public GameObject[] Hearts;

    public GameObject Enemy;
    public GameObject Player;

    public GameObject GamePausedPanel;
    public void SetHearts()
    {
        for (int i = 0; i < Hearts.Length; i++)
        {
            Hearts[i].SetActive(false);
        }
        for (int w = 0; w < PlayerHealth; w++)
        {
            Hearts[w].SetActive(true);
        }
    }
    private void Awake()
    {

        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    public void SetQuestion()
    {
        AudioListener.volume = 1f;
        SetHearts();
        // Time.timeScale = 0;
        for (int z = 0; z < AllQuestions.Length; z++)
        {
            AllQuestions[z].gameObject.SetActive(false);
        }
        Proceed.SetActive(false);

        CurrentQuestion = AllQuestions[CurrentQuestionIndex];
        CorrectlyMarked = 0;
        TotalMistakes = CurrentQuestion.Mistakes;
        CurrentMarkedText.text = "Errors Found:0/" + TotalMistakes;
        AllQuestions[CurrentQuestionIndex].gameObject.SetActive(true);
        // Player.SetActive(false);
        Panel.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        for (int i = 0; i < ThingsToToogle.Length; i++)
        {
            ThingsToToogle[i].SetActive(false);
        }
    }
    public void WrongMarked()
    {
        Debug.Log("Wrong");
        WrongSound.Play();
        PlayerHealth--;
        SetHearts();
        endPoint += new Vector3(2f, 0, 0);
        if (IsInLerp == false)
            StartCoroutine(LerpObject());
        if (PlayerHealth <= 0)
        {
            Time.timeScale = 1;
            for (int z = 0; z < AllQuestions.Length; z++)
            {
                AllQuestions[z].gameObject.SetActive(false);
            }
            // Player.SetActive(true);
            Panel.SetActive(false);

            for (int i = 0; i < ThingsToToogle.Length; i++)
            {
                ThingsToToogle[i].SetActive(true);
            }
            Player.GetComponent<AudioSource>().mute = true;
            Player.GetComponent<Animator>().SetTrigger("Dead");
            Invoke("AfterDead", 5f);
        }

    }
    public GameObject LevelFailedPanel;
    public GameObject LevelCompletePanel;
    public GameObject GameCompletePanel;
    public void AfterDead()
    {
        Player.SetActive(false);
        Enemy.SetActive(false);
        LevelFailedPanel.SetActive(true);
    }

    public void Restart()
    {
        AudioListener.volume = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void NextLevel()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level", 0) + 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void PauseGame()
    {
        AudioListener.volume = 0f;
        GamePausedPanel.SetActive(true);
    }
    public void ResumeGame()
    {
        AudioListener.volume = 1f;
        GamePausedPanel.SetActive(false);
    }
    public void Home()
    {
      SceneManager.LoadScene("Main");
    }
    public void ProceedBtnClick()
    {

        Panel.SetActive(false);
        Player.SetActive(false);
        Enemy.SetActive(false);
        if (PlayerPrefs.GetInt("Level", 0) == 11)
            GameCompletePanel.SetActive(true);
        else
            LevelCompletePanel.SetActive(true);
        // for (int z = 0; z < AllQuestions.Length; z++)
        // {
        //     AllQuestions[z].gameObject.SetActive(false);
        // }
        //// Player.SetActive(true);
        // Panel.SetActive(false);
        // Cursor.visible = false;
        // for (int i = 0; i < ThingsToToogle.Length; i++)
        // {
        //     ThingsToToogle[i].SetActive(true);
        // }
    }
    public void CorrectMarked()
    {

        CorrectlyMarked++;
        CorrectSound.Play();
        CurrentMarkedText.text = "Errors Found:"+CorrectlyMarked+"/" + TotalMistakes;
        if (CorrectlyMarked == TotalMistakes)
        {
            Proceed.SetActive(true);
            CurrentQuestionIndex++;
        }
           else
        {

        }
    }

    public Vector3 startPoint;
    public Vector3 endPoint;
    public float lerpTime = 1f;
    public bool IsInLerp = false;
    private IEnumerator LerpObject()
    {
        startPoint = Enemy.transform.position;
        float currentLerpTime = 0f;
        IsInLerp = true;
        while (currentLerpTime < lerpTime)
        {
            currentLerpTime += Time.deltaTime;

            float t = currentLerpTime / lerpTime;
            Enemy.transform.position = Vector3.Lerp(startPoint, endPoint, t);

            yield return null;
        }

        // Ensure the object reaches the final position precisely
        Enemy.transform.position = endPoint;
        IsInLerp = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        CurrentQuestionIndex = PlayerPrefs.GetInt("Level", 0);
        SetQuestion();
        Enemy.transform.position += new Vector3((-2.5f*PlayerHealth),0,0);
        endPoint = Enemy.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
