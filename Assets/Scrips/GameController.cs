using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public bool gamesOn;
    private bool startGame;
    public float countdownStart = 10;
    private float startTimer;
    

    public Progression prog;
    public Button mainButton;
    public Button regretButton;

    public int playerScore;
    public TextMeshProUGUI playerScoreDisplay;

    public int pushPerPart;
    public int totalPush;
    public int amountPushes;

    public Image[] pushes;

    public Color used, activated, dectivated;

    private bool buttonActive;

    public Anticipate anticipate;
    public Endurence endurance;
    public bool strong;

    public Button reavealButton, oneUpButton, strengthButton;
    

    // Start is called before the first frame update
    void Start()
    {
        gamesOn = false;
        startGame = true;
        startTimer = countdownStart;
        amountPushes = 10;

        for (int i = 0; i < pushes.Length; i++)
        {
            pushes[i].color = dectivated;
        }

        StartCoroutine(LoadButton());

        pushPerPart = 0;
        totalPush = 0;
        playerScore = 0;

        
        buttonActive = false;
        mainButton.interactable = false;

    }
    private void Update()
    {
        if (!gamesOn)
        {
            if (startTimer > 0)
            {
                startTimer-=Time.deltaTime;
                playerScoreDisplay.text = "" + (int)startTimer;
            }
            else if (startGame)
            {
                gamesOn = true;
                startGame = false;
                playerScoreDisplay.text = "" + playerScore;
                buttonActive = true;
                mainButton.interactable = true;
                reavealButton.interactable = false;
            }
        }
        if (buttonActive)
        {
            if (totalPush == amountPushes)
            {
                mainButton.interactable = false;
            }
        }
    }

    public void PushTheButton()
    {
        if (totalPush < amountPushes)
        {
            pushPerPart++;

            if (pushPerPart == 1)
            {
                playerScore += prog.scores[prog.counter];
                pushes[totalPush].color = used;
                totalPush++;

                if (anticipate.anticipation == totalPush)
                {
                    playerScore += prog.scores[prog.counter];
                }
                playerScoreDisplay.text = "" + playerScore;

                prog.parts[prog.counter].GetComponent<PartScript>().text.text = "" + prog.scores[prog.counter];
                prog.parts[prog.counter].GetComponent<PartScript>().text.color = Color.black;
                prog.parts[prog.counter].GetComponent<PartScript>().pushOne.SetActive(true);

                if (!endurance.enduranceActive)
                {
                    DeactivateMainButton();
                }

            }

            else if (pushPerPart == 2 && endurance.enduranceActive)
            {
                playerScore += prog.scores[prog.counter];
                pushes[totalPush].color = used;
                totalPush++;

                if (anticipate.anticipation == totalPush)
                {
                    playerScore += prog.scores[prog.counter];
                }
                playerScoreDisplay.text = "" + playerScore;

                prog.parts[prog.counter].GetComponent<PartScript>().pushTwo.SetActive(true);
                mainButton.interactable = false;
                endurance.UseEndurance();
            }

            if (strong)
            {
                playerScore += prog.scores[prog.counter];
                strong = false;
               
            }

            playerScoreDisplay.text = "" + playerScore;
        }
    }

    public void Regret()
    {
        
        if (pushPerPart == 1)
        {
            prog.parts[prog.counter].GetComponent<PartScript>().pushOne.SetActive(false);
            regretButton.interactable = false;
            totalPush--;
            pushes[totalPush].color = activated;
            playerScore -= prog.scores[prog.counter];
            playerScoreDisplay.text = "" + playerScore;

        }
        else if( pushPerPart >= 2)
        {
            prog.parts[prog.counter].GetComponent<PartScript>().pushTwo.SetActive(false);
            regretButton.interactable = false;
            totalPush--;
            pushes[totalPush].color = activated;
            playerScore -= prog.scores[prog.counter];
            playerScoreDisplay.text = "" + playerScore;
        }

    }

    public void OneUp()
    {
        amountPushes++;
        pushes[amountPushes-1].color = activated;
        oneUpButton.interactable = false;


    }

    public void Reveal()
    {
        if (!gamesOn)
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
    public void Strength()
    {
        strong = true;
        strengthButton.interactable = false;
    }

    public void ActivateMainButton()
    {
        mainButton.interactable = true;
    }

    public void DeactivateMainButton()
    {
        mainButton.interactable = false;
    }

    private IEnumerator LoadButton() 
    {
        for (int i = 0; i < amountPushes; i++)
        {
            pushes[i].color = activated;
            yield return new WaitForSeconds(0.1f);
        }
    
    }

}
