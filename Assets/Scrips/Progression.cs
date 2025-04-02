using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Progression : MonoBehaviour
{

    public GameObject[] parts;  

    public int[] scores;
    
    public Color inProgress, waiting, done, pushedOnce, pushedTwice;

    public GameController gameControll;

    private SaveStats saveStats;

    
    public int counter;
    

    public float secondsLit = 10f;
    
    private float progressTimer;

    

    [SerializeField, Range(0, 1.25f)]
    private float fillMeter = 0;



    // Start is called before the first frame update
    void Start()
    {
        saveStats = GameObject.FindGameObjectWithTag("SaveStats").GetComponent<SaveStats>();

        fillMeter = 0;
        progressTimer = secondsLit;
        counter = 0;

        for (int i = 0; i < parts.Length; i++)
        {
            parts[i].GetComponent<PartScript>().partImage.color = waiting;
        }

        parts[counter].GetComponent<PartScript>().partImage.color = inProgress;

        Shuffle(scores);

        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameControll.gamesOn)
        {
            if (progressTimer > 0)
            {
                progressTimer -= Time.deltaTime;

                float percentageCompleted = progressTimer / secondsLit;
                float scaleAmount = Mathf.Lerp(1.25f, 0f, percentageCompleted);

                parts[counter].GetComponent<PartScript>().fill.transform.localScale = new Vector3(scaleAmount, 1.25f, 0);

            }
            else
            {
                parts[counter].GetComponent<PartScript>().partImage.color = done;
                counter++;

                if (counter >= parts.Length)
                {
                    gameControll.gamesOn = false;
                    StartCoroutine(DisplayScores());
                    return;
   
                }

                parts[counter].GetComponent<PartScript>().partImage.color = inProgress;
                parts[counter].GetComponent<PartScript>().partImage.color = inProgress;
                progressTimer = secondsLit;
                gameControll.pushPerPart = 0;
                gameControll.mainButton.interactable = true;

                
            }
        }
        
    }

    void Shuffle(int[] a)
    {
        // Loops through array
        for (int i = a.Length - 1; i > 0; i--)
        {
            int rnd = Random.Range(0, i);

            int temp = a[i];

            a[i] = a[rnd];
            a[rnd] = temp;
        }

    }

    IEnumerator DisplayScores()
    {
        for (int i = 0; i < parts.Length; i++)
        {
            parts[i].GetComponent<PartScript>().text.text = "" + scores[i];
            yield return new WaitForSeconds(0.25f);
        }

        yield return new WaitForSeconds(2);

        saveStats.coins += gameControll.playerScore;

        GetComponent<SceneMan>().MainMenu();
    }

}
