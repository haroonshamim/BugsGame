using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Game;
using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    public static QuestionManager instance;
    public Question CurrentQuestion;
    public int TotalMistakes;
    public int CorrectlyMarked;
    public Text CurrentMarkedText;
    public GameObject Proceed;
    public Question[] AllQuestions;

    public int levelnumber = 1;
    int CurrentQuestionIndex = 0;
    public GameObject Panel;
    public Health PlayerHealth;

    public GameObject[] ThingsToToogle;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    public void SetQuestion()
    {
        Time.timeScale = 0;
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
        ControlFreak2.CFCursor.visible = true; ControlFreak2.CFCursor.lockState = CursorLockMode.None;
        for(int i=0;i<ThingsToToogle.Length;i++)
        {
            ThingsToToogle[i].SetActive(false);
        }
    }
    public void WrongMarked()
    {
        Debug.Log("Wrong");
        PlayerHealth.TakeDamage(10, null);
        if(PlayerHealth.CurrentHealth<=0)
        {
            Time.timeScale = 1;
            for (int z = 0; z < AllQuestions.Length; z++)
            {
                AllQuestions[z].gameObject.SetActive(false);
            }
            // Player.SetActive(true);
            Panel.SetActive(false);
            ControlFreak2.CFCursor.visible = false;
            for (int i = 0; i < ThingsToToogle.Length; i++)
            {
                ThingsToToogle[i].SetActive(true);
            }
        }
        
    }
    public void ProceedBtnClick()
    {
        Time.timeScale = 1;
        for (int z = 0; z < AllQuestions.Length; z++)
        {
            AllQuestions[z].gameObject.SetActive(false);
        }
       // Player.SetActive(true);
        Panel.SetActive(false);
        ControlFreak2.CFCursor.visible = false;
        for (int i = 0; i < ThingsToToogle.Length; i++)
        {
            ThingsToToogle[i].SetActive(true);
        }
    }
    public void CorrectMarked()
    {

        CorrectlyMarked++;
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
    // Start is called before the first frame update
    void Start()
    {
        CurrentQuestionIndex = (3 * (levelnumber-1));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
