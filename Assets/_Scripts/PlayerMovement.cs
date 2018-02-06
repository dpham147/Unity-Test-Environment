using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 10f;             // Allow for speed to be edited in Unity Inspector
    public float runSpeed = 1.5f;         // Allow for runspeed to be edited

    public float yMin = 0f;         // Minimum y translation

    private Rigidbody playerRB;     // Reference the player model's rigidbody
    private Vector3 movement;       // Movement vector referencable
    public float jumpForce = 1.0f;  // Allow for jump force to be edited

    private bool isGrounded = false;
    //private bool isWalled = false;
    

	// Use this for initialization
	void Start () {

        playerRB = GetComponent<Rigidbody>();

	}

    private void OnCollisionStay(Collision collision)
    {
        
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Barrier"))
        {
           // isWalled = true;
        }
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Barrier"))
        {
            //isWalled = false;
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }

    void FixedUpdate () {           // Use FixedUpdate for physics implementations

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        
        Move(h, v);
        Turning();
	}

    private void Move(float h, float v)
    {

        movement.Set(h, 0.0f, v);
        movement = movement * speed * Time.deltaTime;

        if (Input.GetButton("Run"))
        {
            movement *= runSpeed;
        }

        movement += transform.position;
        if (movement.y < yMin)
        {
            movement.y = yMin;
        }

        playerRB.transform.position = movement;

        Jump();

    }

    private void Turning()
    {
        if (movement != Vector3.zero) {
            Quaternion newRotate = Quaternion.LookRotation(movement);
            playerRB.transform.rotation = newRotate;
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            playerRB.velocity = Vector3.up * jumpForce;
            
        }
    }
}
