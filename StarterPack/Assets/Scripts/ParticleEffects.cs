using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ParticleEffects : MonoBehaviour
{
    public PlayerController playerController;
    public bool isGround;
    public ParticleSystem explosionParticle;
    public ParticleSystem runningParticles;
    // Start is called before the first frame update
    void Start()
    {
        isGround = playerController.isGrounded;
    }

    // Update is called once per frame
    void Update()
    {
        InWater();
        runningparticle();
    }

    void InWater()
    {
        
    }

    void runningparticle()
    {
        if(Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.D)||Input.GetKeyDown(KeyCode.S))
            {
                if(!runningParticles.isPlaying)
                runningParticles.Play();
            }
            else
            {
                runningParticles.Stop();
            }
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            explosionParticle.Play();
        }
    }
}
