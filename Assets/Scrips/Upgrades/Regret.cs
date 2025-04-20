using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Regret : MonoBehaviour
{
    public GameController gameController;
    public Progression progression;

    public Button regretButton;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        progression = GameObject.FindGameObjectWithTag("GameController").GetComponent<Progression>();
    }

    public void UseRegret()
    {

        if (gameController.pushPerPart == 1)
        {
            gameController.prog.parts[progression.counter].GetComponent<PartScript>().pushOne.SetActive(false);
            regretButton.interactable = false;
            gameController.totalPush--;
            gameController.pushes[gameController.totalPush].color = gameController.activated;
            gameController.playerScore -= progression.scores[progression.counter];
            gameController.playerScoreDisplay.text = "" + gameController.playerScore;

        }
        else if (gameController.pushPerPart >= 2)
        {
            progression.parts[progression.counter].GetComponent<PartScript>().pushTwo.SetActive(false);
            regretButton.interactable = false;
            gameController.totalPush--;
            gameController.pushes[gameController.totalPush].color = gameController.activated;
            gameController.playerScore -= progression.scores[progression.counter];
            gameController.playerScoreDisplay.text = "" + gameController.playerScore;
        }

    }
}
