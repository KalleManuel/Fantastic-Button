using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveStats : MonoBehaviour
{
    public int coins;

    public bool hasRegret, hasAnticipate, has1Up, hasEndurence, hasReveal, hasStrenght, hasStealDefence;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

}
