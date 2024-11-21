using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeHandler : MonoBehaviour
{
    public GameObject upgradePanel;
    public GameObject GameController;
    public Game gameScript;
    public string[] upgrades;
    public Text[] buttonText;
    public int amountButtons = 6;
    public bool dealUpgrades;

    public int price = 500;

    
    public enum UpgradesAmount {None,One,Two,Three}
    UpgradesAmount wichUpgrade;


    // Start is called before the first frame update
    void Start()
    {
        
        wichUpgrade = UpgradesAmount.None;

        gameScript = GameController.GetComponent<Game>();
        
        dealUpgrades = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (!gameScript.gameOn && dealUpgrades)
        {
            upgradePanel.SetActive(true);
            DealUpgrades();
           
        } else if (gameScript.gameOn)
        {
            upgradePanel.SetActive(false);
        }

    }

    public void DealUpgrades()
    {
        //shuffle
        for (int i = 0; i < upgrades.Length; i++)
        {
            string temp = upgrades[i];
            int random = Random.Range(0, i);
            upgrades[i] = upgrades[random];
            upgrades[random] = temp;
        }

        for (int i = 0; i < amountButtons; i++)
        {
            buttonText[i].text = upgrades[i];
        }
        dealUpgrades = false;
    }

    public void BuyUpgrade()
    {
        if (wichUpgrade == UpgradesAmount.None)
        {
            if(gameScript.savedScore >= price)
            {
                wichUpgrade = UpgradesAmount.One;
            }
            
        }
        else if (wichUpgrade == UpgradesAmount.One)
        {
            if (gameScript.savedScore >= price)
            {
                wichUpgrade = UpgradesAmount.Two;
            }

        } else if (wichUpgrade == UpgradesAmount.Two)
            {
                if (gameScript.savedScore >= price)
                {
                    wichUpgrade = UpgradesAmount.Three;
                }

            }
    }
}

