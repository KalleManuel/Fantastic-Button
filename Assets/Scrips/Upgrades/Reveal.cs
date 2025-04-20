using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reveal : MonoBehaviour
{
    public GameController gameController;
    public Progression prog;

    public Button reavealButton;



    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        prog = GameObject.FindGameObjectWithTag("GameController").GetComponent<Progression>();
    }

    private void Update()
    {
        if (!gameController.gamesOn)
        {

            if (gameController.startTimer <= 0)
            {
                reavealButton.interactable = false;
            }              
        }
    }

    public void UseReveal()
    {
        if (!gameController.gamesOn)
        {
            for (int i = 1; i < (prog.scores.Length); i++)
            {
                if (prog.scores[i] <= 30)
                {

                    prog.parts[i].GetComponent<PartScript>().text.color = Color.magenta;
                }
            }

            reavealButton.interactable = false;


        }
    }
}
