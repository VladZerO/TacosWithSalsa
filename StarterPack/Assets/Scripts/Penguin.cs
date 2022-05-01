using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penguin : MonoBehaviour
{

    public int playerNumber;


    private void Start()
    {
        playerNumber = GameManager.instance.AddPenguin(this);   
    }

 
    public void KillPenguin(int i)
    {
        if (i == playerNumber)
        {
            GameManager.instance.DeadPenguin(this);
            Destroy(this.gameObject);
        }
       
    }
}
