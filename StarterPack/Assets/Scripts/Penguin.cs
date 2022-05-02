using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penguin : MonoBehaviour
{

    public int playerNumber;
    public ParticleSystem explosionParticles;
    public ParticleSystem runningParticles;
    public ParticleSystem splashParticles;
    public SpriteRenderer playerSprite;

    

    private void Start()
    {
        playerNumber = GameManager.instance.AddPenguin(this);   
    }

 
    public void KillPenguin()
    {
        GameManager.instance.DeadPenguin(this);
        GetComponent<BasicMovement>().playerIsAlive = false;
        playerSprite.enabled = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            KillPenguin();
        }


        else if (other.gameObject.CompareTag("Water"))
        {
            splashParticles.Play();

        }
    }
}
