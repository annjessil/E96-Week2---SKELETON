using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


// TODO: import UnityEngine.InputSystem and UnityEngine.SceneManagement


public class PlayerController : MonoBehaviour
{
    // TODO: add component references
    Rigidbody rb;
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpHeight = 5f;
    bool isFlattened = false; //for onFlatten() function
    bool isGrounded = false;

    Vector2 moveValue = Vector2.zero;

    // TODO: add variables for speed, jumpHeight, and respawnHeight


    // TODO: add variable to check if we're on the ground


    // Start is called before the first frame update


    void Start()
    {
        // TODO: Get references to the components attached to the current GameObject
        rb = GetComponent<Rigidbody>(); 

    }

    // Update is called once per frame
    void Update()
    {
        // TODO: check if player is under respawnHeight and call Respawn()

    }

    void OnJump()
    {
        // TODO: check if player is on the ground, and call Jump()
        if (isGrounded)
        {
            Jump();
        }
        


    }

    private void Jump()
    {
        // TODO: Set the y velocity to some positive value while keeping the x and z whatever they were originally

        rb.velocity = new Vector3(rb.velocity.x, jumpHeight, rb.velocity.z);



    }

    void OnMove(InputValue moveVal)
    {
        //TODO: store input as a 2D vector and call Move()
        Vector2 direction = moveVal.Get<Vector2>();
        Debug.Log(direction);
        moveValue = direction;
        //Move(direction.x, direction.y);
        Move(moveValue.x, moveValue.y); 


    }

    private void Move(float x, float z)
    {
        // TODO: Set the x & z velocity of the Rigidbody to correspond with our inputs while keeping the y velocity what it originally is.
        rb.velocity = new Vector3(x*speed, rb.velocity.y ,z*speed); 
    }


    void OnFlatten(){

        if (isFlattened == false) //checks if player has been flattended before
        {
            transform.localScale = new Vector3(transform.localScale.x * 2, transform.localScale.y * 0.5f, transform.localScale.z * 2);
            isFlattened = true; // updates isFlattened
        }

    }

    private void OnCollisionEnter(Collision collision) //called when a collision is registered
    {
        // This function is commonly useful, but for our current implementation we don't need it
        isGrounded = true; 


    }

    private void OnCollisionStay(Collision collision)
    {
        // TODO: Check if we are in contact with the ground. If we are, note that we are grounded

    }

    private void OnCollisionExit(Collision collision)
    {
        // TODO: When we leave the ground, we are no longer grounded
        isGrounded = false;

    }

    private void Respawn()
    {
        // TODO: reload current scene

    }
}
