using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WorkShop : MonoBehaviour
{
    public UpgradeItem[] items;
    

    public SaveStats saveStats;

    public TextMeshProUGUI coinDisplay;

    // Start is called before the first frame update
    void Start()
    {
        saveStats = GameObject.FindGameObjectWithTag("SaveStats").GetComponent<SaveStats>();

        coinDisplay.text = "= " + saveStats.coins;

        for (int i = 0; i < saveStats.owned.Length; i++)
        {
            if (saveStats.owned[i])
            {
                items[i].owned = true;
                items[i].CheckStatus();
            }

            else
            {
                items[i].owned = false;
                items[i].CheckStatus();
            }


        }
        
    }

    public void BuyItem()
    {
        coinDisplay.text = "= " + saveStats.coins;

        for (int i = 0; i < saveStats.owned.Length; i++)
        {
            items[i].CheckStatus();

            if (items[i].owned)
            {
                saveStats.owned[i] = true;
            }
            

        }
    }
}
