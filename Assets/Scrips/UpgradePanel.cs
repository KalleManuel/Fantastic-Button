using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePanel : MonoBehaviour
{
    public GameObject[] upgrades;
    public List <GameObject> slots;
    public GameObject emptySlot;
    public Transform spawnPosition;

    public SaveStats saveStats;

    // Start is called before the first frame update
    void Start()
    {
        saveStats = GameObject.FindGameObjectWithTag("SaveStats").GetComponent<SaveStats>();

        for (int i = 0; i < saveStats.owned.Length; i++)
        {
            if (saveStats.owned[i])
            {
                Instantiate(upgrades[i], spawnPosition);
            }
            else Instantiate(emptySlot, spawnPosition);
        }

        

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
