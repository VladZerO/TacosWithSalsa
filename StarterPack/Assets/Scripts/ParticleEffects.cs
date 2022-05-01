using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ParticleEffects : MonoBehaviour
{
   // public PlayerController playerController;
    public bool isGround;
    public ParticleSystem explosionParticles;
    public ParticleSystem runningParticles;
    public ParticleSystem splashParticles;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        runningParticle();
    }

    void runningParticle()
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
            explosionParticles.Play();
        }
        else if(other.gameObject.CompareTag("Water"))
        {
            splashParticles.Play();

        }
    }
}
