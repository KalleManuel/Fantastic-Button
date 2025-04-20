using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Strength : MonoBehaviour
{
    public Button strengthButton;
    public GameController gameController;


    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    public void UseStrenght()
    {
        gameController.strength = true;
        strengthButton.interactable = false;
    }
}