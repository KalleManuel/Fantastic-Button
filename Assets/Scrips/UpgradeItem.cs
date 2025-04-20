using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeItem : MonoBehaviour
{
    public bool inactivated;
    public bool owned;
    public Image itemImage;
    public string itemName;
    public int itemPrice;
    public string itemDescription;
    public Button button;
    public int itemCode;
    
    

    public SaveStats saveStats;

    public TextMeshProUGUI displayPrice;
    public TextMeshProUGUI displayName;
    public TextMeshProUGUI displayinfo;

    private void Start()
    {
        saveStats = GameObject.FindGameObjectWithTag("SaveStats").GetComponent<SaveStats>();
           
    }

    public void CheckStatus()
    {
        if (!owned)
        {
            if (!inactivated)
            {
                if (itemPrice <= saveStats.coins)
                {
                    displayName.text = itemName;
                    displayPrice.text = "" + itemPrice;
                    displayPrice.color = Color.black;
                    button.interactable = true;

                }
                else
                {
                    displayName.text = itemName;
                    displayPrice.text = "" + itemPrice;
                    displayPrice.color = Color.red;
                    button.interactable = false;
                }
            }
            else
            {
                displayName.text = itemName;
                displayPrice.text = "???";
                displayPrice.color = Color.yellow;
                button.interactable = false;

            }
        }
        else
        {
            displayName.text = itemName;
            displayPrice.text = "Owned";
            displayPrice.color = Color.green;
            button.interactable = false;
        }


    }

    public void ShowInfo()
    {
        displayinfo.text = itemDescription;

    }

    public void HideInfo()
    {

        displayinfo.text = string.Empty;

    }

    public void BuyUpgrade()
    {
        saveStats.coins -= itemPrice;
        owned = true;

        GameObject.FindGameObjectWithTag("GameController").GetComponent<WorkShop>().BuyItem();

    }
}
