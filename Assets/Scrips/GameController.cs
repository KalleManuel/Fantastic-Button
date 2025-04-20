using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public bool gamesOn;
    public bool startGame;
    public float countdownStart = 10;
    public float startTimer;
    

    public Progression prog;
    public Button mainButton;
    

    public int playerScore;
    public TextMeshProUGUI playerScoreDisplay;

    public int pushPerPart;
    public int totalPush;
    public int amountPushes;

    public Image[] pushes;

    public Color used, activated, dectivated;

    private bool buttonActive;

    public Anticipate anticipateScript;
    public Endurence enduranceScript;

    public bool regret, anticipate, oneUp, endurence, reveal, strength;

    

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

                if (anticipate) 
                {
                   /* if (anticipateScript == null)
                    {
                        anticipateScript = GameObject.FindGameObjectWithTag("Anticipate").GetComponent<Anticipate>();
                    } */

                    if (anticipateScript.anticipation == totalPush)

                    {
                        playerScore += prog.scores[prog.counter];
                    }

                } 
                playerScoreDisplay.text = "" + playerScore;

                prog.parts[prog.counter].GetComponent<PartScript>().text.text = "" + prog.scores[prog.counter];
                prog.parts[prog.counter].GetComponent<PartScript>().text.color = Color.black;
                prog.parts[prog.counter].GetComponent<PartScript>().pushOne.SetActive(true);

                if (endurence)
                {
                   /* if (enduranceScript == null)
                    {
                        enduranceScript = GameObject.FindGameObjectWithTag("Endurence").GetComponent<Endurence>();
                    } */

                    if (!enduranceScript.enduranceActive)
                    {
                        DeactivateMainButton();
                    }
                }

            }

            else if (pushPerPart == 2 && endurence)
            {
                playerScore += prog.scores[prog.counter];
                pushes[totalPush].color = used;
                totalPush++;

                if (anticipate)
                {
                    /* if (anticipateScript == null)
                    {
                        anticipateScript = GameObject.FindGameObjectWithTag("Anticipate").GetComponent<Anticipate>();
                    } */

                    if (anticipateScript.anticipation == totalPush)

                    {
                        playerScore += prog.scores[prog.counter];
                    }

                }
                playerScoreDisplay.text = "" + playerScore;

                prog.parts[prog.counter].GetComponent<PartScript>().pushTwo.SetActive(true);
                mainButton.interactable = false;

                /* if (enduranceScript == null)
                {
                    enduranceScript = GameObject.FindGameObjectWithTag("Endurence").GetComponent<Endurence>();
                }*/

                if (enduranceScript.enduranceActive)
                {

                    enduranceScript.UseEndurance();
                }
                
            }

            if (strength)
            {
                playerScore += prog.scores[prog.counter];
                strength = false;
               
            }

            playerScoreDisplay.text = "" + playerScore;
        }
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
