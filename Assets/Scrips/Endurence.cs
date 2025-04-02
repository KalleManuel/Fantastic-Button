using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Endurence : MonoBehaviour
{
    public int amountDoubles = 3;
    public int usedDubles;

    public GameController gameController;

    public Image [] bulbs;
    

    public bool enduranceActive;

    // Start is called before the first frame update
    void Start()
    {
        usedDubles = 0;
        enduranceActive = true;

        for (int i = 0; i < bulbs.Length; i++)
        {
            bulbs[i].color = Color.green;
        }
    }

    public void UseEndurance()
    {
        bulbs[usedDubles].color = Color.gray;
        usedDubles++;



        if (usedDubles == amountDoubles)
        {
            enduranceActive = false;
        }
        
    }
}

