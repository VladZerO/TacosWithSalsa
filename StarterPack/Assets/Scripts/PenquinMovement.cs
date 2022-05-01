using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenquinMovement : MonoBehaviour
{
       
    public float gravityModifier = 2.0f;

    public Rigidbody rb;
    [SerializeField] public float moveSpeed = 5.0f;
    [SerializeField] public float jumpForce = 5.0f;
    private Vector2 moveInput;

    public LayerMask whatIsGround;
    public Transform groundPoint;
    private bool isGrounded;

    [SerializeField] ParticleSystem runningParticles;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       movePlayer();
       jumpPlayer();
       //slidePlayer();
    }

    void movePlayer()
        {
            moveInput.x=Input.GetAxis("Horizontal");
            moveInput.y=Input.GetAxis("Vertical");
            moveInput.Normalize();

            rb.velocity=new Vector3(moveInput.x*moveSpeed, rb.velocity.y, moveInput.y*moveSpeed);

            //running particle system
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
    void jumpPlayer()
    {
        RaycastHit hit;
        if(Physics.Raycast(groundPoint.position, Vector3.down, out hit, .3f, whatIsGround))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded=false;
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity += new Vector3(0f, jumpForce, 0f);
            if(rb.velocity.y < 0.0f)
             {
             rb.velocity = new Vector3(rb.velocity.x, 9.8f* gravityModifier, rb.velocity.z);
            } 
        } 
    }

   /* void slidePlayer()
    {
         

    }*/
}