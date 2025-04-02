using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PartScript : MonoBehaviour
{
    public Image partImage;
    public GameObject fill;
    public TextMeshProUGUI text;
    public GameObject pushOne, pushTwo;

    
    // Start is called before the first frame update
    void Start()
    {
        pushOne.SetActive(false);
        pushTwo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
