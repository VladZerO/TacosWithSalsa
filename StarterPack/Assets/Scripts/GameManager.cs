using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private int currentAmountOfPenguins;

    [SerializeField] private GameObject twoPlayerLines;

    [SerializeField] private GameObject fourPlayerLines;


    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private TextMeshProUGUI playerWonText;



    //<< Change for player or something later
    [SerializeField] private List<Penguin> currentPenguins;


    private void Awake()
    {
        instance = this;
    }

    public int AddPenguin(Penguin loPenguin)
    {
        currentAmountOfPenguins++;
        if (currentAmountOfPenguins >= 2)
        {
            twoPlayerLines.SetActive(true);
        }
        if (currentAmountOfPenguins > 2)
        {
            fourPlayerLines.SetActive(true);
        }

        currentPenguins.Add(loPenguin);

        return currentAmountOfPenguins;
    }


    public void DeadPenguin(Penguin loPenguin)
    {
        if (currentAmountOfPenguins == 1)
            return;

        currentAmountOfPenguins--;
        currentPenguins.Remove(loPenguin);

        if (currentAmountOfPenguins == 1)
        {
            gameOverUI.SetActive(true);
            playerWonText.text = "Player " + currentPenguins[0].playerNumber + " won!"; 
        }
    }
    

}
