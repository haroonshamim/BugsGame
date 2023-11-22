using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Question : MonoBehaviour
{
    public int Mistakes;
    private void OnEnable()
    {

    }
   
    public void WrongMarked()
    {
        QuestionManager.instance.WrongMarked();
    }
    public void CorrectMarked()
    {
     
        QuestionManager.instance.CorrectMarked();
    }
    // Start is called before the first frame update
    void Start()
    {

  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
