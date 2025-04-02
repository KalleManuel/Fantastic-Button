using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Anticipate : MonoBehaviour
{
    public Button bLeft, bRight;
    public GameObject[] markings;

    public int anticipation;

    public GameController gameControll;
  
    

    // Start is called before the first frame update
    void Start()
    {
        anticipation = 1;
        bLeft.interactable = false;
        markings[anticipation-1].SetActive(true);
   
    }

    private void Update()
    {
        if (gameControll.gamesOn)
        {
            bLeft.interactable = false;
            bRight.interactable = false;
        }
    }

    public void GoLeft()
    {
        if (anticipation >= 2)
        {
            markings[anticipation - 1].SetActive(false);
            anticipation--;
            markings[anticipation - 1].SetActive(true);
            Check();
        }
       
        
    }

    public void GoRight()
    {
        markings[anticipation - 1].SetActive(false);
        anticipation++;
        markings[anticipation - 1].SetActive(true);

        Check();
    }

    private void Check()
    {
        if (anticipation <= 1)
        {
            bLeft.interactable = false;
        }
        else bLeft.interactable = true;


        if (anticipation >= 10)
        {
            bRight.interactable = false;

        }
        else bRight.interactable = true;
    }

}
