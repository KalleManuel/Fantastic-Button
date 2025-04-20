using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveStats : MonoBehaviour
{
    public static SaveStats Instance;

    public int coins;

   // public bool regret, anticipate, oneUp, endurence, reveal, strenght, attackOrDefence, wheelOfFortune;
    
    public bool[] owned;

    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

}
