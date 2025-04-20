using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OneUp : MonoBehaviour
{
    public GameController gameController;
    public Button oneUpButton;


    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void Update()
    {
        if (!gameController.gamesOn)
        {

            if (gameController.startTimer <= 0)
            {
                oneUpButton.interactable = false;
            }
        }
    }

    public void UseUp()
    {
        gameController.amountPushes++;
        gameController.pushes[gameController.amountPushes - 1].color = gameController.activated;
        oneUpButton.interactable = false;


    }
}
