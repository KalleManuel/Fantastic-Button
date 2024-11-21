using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    
    public bool gameOn;
    public int[] fastGamePoints;
    public int pointSlots;
    public GameObject[] slots;

    public float timer;
    public float timeframe;
    public float timeBetween;
    public float gameLength;

    public Slider TimeToNextSlider; 

    public int pushCount;
    public Material active;
    public Material deactivate;
    public Material groundMaterial;
    public GameObject[] bulbs;
    public int pushPerPoint;
    public int pushLimit;

    public int score;
    public int savedScore;
    public Text displaySavedScore;

    public Text displayScore;
    public Text TempScore;
    public Text revealPoints;

    public GameObject revealPanel;


    public GameObject theButton;
    public GameObject startFastGame;
    public Color green;
    public Color red;
    [Multiline(24)]
    public string reavealString;


    // Start is called before the first frame update
    void Start()
    {
        
        revealPanel.SetActive(false);

        gameOn = false;
        timer = 0;
        pointSlots = 0;
        timeframe = 10.0f;

        pushCount = 0;
        pushPerPoint = 0;
        displayScore.text = score + " points";

        ChangeColor(green, theButton);
        ChangeColor(green, startFastGame);
    }

    // Update is called once per frame
    void Update()
    {
        //check if an game is active
        if (gameOn)
        {
            //check if the game hasn't finished.
            if (timer < gameLength)
            {
                //add to timer
                timer += Time.deltaTime;
                TimeToNextSlider.value += 1 / timeBetween * Time.deltaTime;

                //check if it's time to activatethe next point slot
                if (timer > timeframe)
                {
                    //if yes: add time to timeslot
                    
                    timeframe += timeBetween;
                    TimeToNextSlider.value = 0;
        

                    // make the bulb that we leave red
                    MeshRenderer deactivatedMat = slots[pointSlots].GetComponent<MeshRenderer>();
                    deactivatedMat.material = deactivate;

                    //add the point to the releavestring and make it green if weve pushed the buttn on that slot 
                    if (pushPerPoint == 1)
                    {
                        reavealString += "<color=yellow>" + fastGamePoints[pointSlots] + "</color>\n";
                    }
                    else if (pushPerPoint >= 2)
                    {
                        reavealString += "<color=green>" + fastGamePoints[pointSlots] + "</color>\n";
                    }
                    else if (pushPerPoint == 0)
                    {
                        reavealString += "<color=red>" + fastGamePoints[pointSlots] + "</color>\n";
                    }

                    // Change to next point slot
                    pointSlots++;
                    
                    // color the active point slot green
                    MeshRenderer activatedMat = slots[pointSlots].GetComponent<MeshRenderer>();
                    activatedMat.material = active;
                    
                    // reset pushPerPoint so we can push again
                    pushPerPoint = 0;
                    
                }
            }
            else GameOver();

            if (pushPerPoint == 2)
            {
                ChangeColor(red, theButton);
            }
            else
            {
                ChangeColor(green, theButton);
            }

            if (pushCount == pushLimit)
            {
                GameOver();
            }


        }
        
        
    }

    public void StartFastGame()
    {
        if (!gameOn)
        {
            Shuffle();

            gameOn = true;
            ChangeColor(red, startFastGame);
            pushLimit = 10;
            timer = 0;
            timeBetween = 10.0f;
            gameLength = 240f;
            timeframe = timeBetween;

            MeshRenderer activated = slots[pointSlots].GetComponent<MeshRenderer>();
            activated.material = active;

            revealPanel.SetActive(false);
            reavealString = "";
            revealPoints.text = "";

        }


    }

    public void Shuffle()
    {
        for(int i = 0; i < fastGamePoints.Length; i++)
        {
            int temp = fastGamePoints[i];
            int random = Random.Range(0, i);
            fastGamePoints[i] = fastGamePoints[random];
            fastGamePoints[random] = temp;
        }
       
    }

    public void PushTheButton()
    {
        if (gameOn)
        {
            if (pushPerPoint < 2)
            {


                MeshRenderer meshRenderer = bulbs[pushCount].GetComponent<MeshRenderer>();
                meshRenderer.material = active;
                pushCount++;
                pushPerPoint++;
                score += fastGamePoints[pointSlots];
                displayScore.text = score + "";
                RevealPushScore();

            }
        }
                   
    }
    public void GameOver()
    {
        savedScore += score;
        displaySavedScore.text = "" + savedScore;
        
        Reveal();
        ResetGame();


    }

    public void Reveal()
    {
        for(int i = pointSlots; i < fastGamePoints.Length; i++)
        {
            if (pushPerPoint == 1)
            {
                reavealString += "<color=yellow>" + fastGamePoints[i] + "</color>\n";
                pushPerPoint = 0;
            }
            else if (pushPerPoint >= 2)
            {
                reavealString += "<color=green>" + fastGamePoints[i] + "</color>\n";
                pushPerPoint = 0;
            }
            else reavealString += "<color=red>" + fastGamePoints[i] + "</color>\n";
        }
     
        revealPoints.text = reavealString;
        revealPanel.SetActive(true);
    }
    public void ResetGame()
    {
        score = 0;
        displayScore.text = "" + score;
        pushCount = 0;
        pushPerPoint = 0;
        pointSlots = 0;
        timer = 0;
        gameOn = false;

        for (int i = 0; i < slots.Length; i++)
        {
            MeshRenderer resetSlots = slots[i].GetComponent<MeshRenderer>();
            resetSlots.material = groundMaterial;
        }

        for (int i = 0; i < bulbs.Length; i++)
        {
            MeshRenderer resetTry = bulbs[i].GetComponent<MeshRenderer>();
            resetTry.material = groundMaterial;
        }

        
        ChangeColor(green, startFastGame);



    }

    public void ChangeColor(Color color, GameObject button)
    {
        button.GetComponent<Image>().color = color;
    }

    public void RevealPushScore()
    {
        TempScore.text = "" + fastGamePoints[pointSlots];
        StartCoroutine(ClearTempPoint(2));
        
    }
    private IEnumerator ClearTempPoint(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        TempScore.text = "";

    }


}

