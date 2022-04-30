using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O_JumpPads : MonoBehaviour
{
    [Range(10, 1000)]
    public float bounceHeight;


    private void OnCollisionEnter(Collision collision)
    {
        GameObject jumpPad = collision.gameObject;
        Rigidbody rb = jumpPad.GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * bounceHeight);

    }
}
