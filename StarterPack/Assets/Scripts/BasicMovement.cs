using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class BasicMovement : MonoBehaviour
{
    /// <summary>
    /// Movement of the player
    /// </summary>
    [SerializeField]
    private float movementSpeed = 0.0f;

    public bool player1;

    /// <summary>
    /// Sensibility of the camera, how fast it will move
    /// </summary>
    //[SerializeField]
    //private float camSensibility = 10f;

    [SerializeField]
    private float jumpForce = 10f;


    /// <summary>
    /// RigidBody of the player
    /// </summary>
    private Rigidbody loRigidBody;



    /// <summary>
    /// Game Camera to rotate
    /// </summary>
    [SerializeField]
    private Camera gameCamera;


    PlayerInputManager playerInputManager;

    private Vector2 movementInput = Vector2.zero;


    private void Start()
    {
        loRigidBody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        MoveCharacter();
        //RotateCharacter();
        //Jump();
    }


    public void Move(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();

    }

    public void Jump(InputAction.CallbackContext context)
    {
        loRigidBody.AddForce(new Vector3(0f, jumpForce, 0f));
    }

    /// <summary>
    /// Player movement handler.
    /// </summary>
    private void MoveCharacter()
    {
        loRigidBody.velocity = new Vector3(movementInput.x * movementSpeed, loRigidBody.velocity.y, movementInput.y * movementSpeed);
    }

    /// <summary>
    /// Rotates the character towards the mouse
    /// </summary>
    private void RotateCharacter()
    {
        ///Converting the mouse position to a point in 3D-space
        Vector3 point = gameCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
        // Using some math to calculate the point of intersection between the line going through the camera and the mouse position with the XZ-Plane
        float t = gameCamera.transform.position.y / (gameCamera.transform.position.y - point.y);
        Vector3 finalPoint = new Vector3(t * (point.x - gameCamera.transform.position.x) + gameCamera.transform.position.x, 1, t * (point.z - gameCamera.transform.position.z) + gameCamera.transform.position.z);
        //Rotating the object to that point
        transform.LookAt(finalPoint, Vector3.up);
        transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y, 0));
    }


}
