using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CorrectAnswer : MonoBehaviour
{
    public GameObject[] ObjsToBeTurnedOn;
    
    public void Mark()
    {
      this.GetComponent<Image>().color = Color.white;
      this.GetComponent<Button>().interactable = false;  
      for(int i=0;i<ObjsToBeTurnedOn.Length;i++)
        {
            ObjsToBeTurnedOn[i].gameObject.SetActive(true);
        }

    }
    void Start()
    {
   
        for (int i = 0; i < ObjsToBeTurnedOn.Length; i++)
        {
            ObjsToBeTurnedOn[i].gameObject.SetActive(false);
        }
        Color imageColor = this.GetComponent<Image>().color;

        // Set the alpha component to 0
        imageColor.a = 0f;

        // Set the new color of the image
        this.GetComponent<Image>().color = imageColor;

        this.GetComponent<Button>().interactable = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
