using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // set variables
    [Header("References")]
    public CharacterController controller;
    public AudioSource source;

    [Header("Movement")]
    public float speed = 5f;
    public float gravity = -9.8f;
    public float jumpHeight = 2f;

    [Header("Ground")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        // Check if gounded by making a sphere with a radius from the value of groundDistance at the position of groundCheck that is in the layer mask of groundMask
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // ensures that player object is firmly on the ground
        if (isGrounded && velocity.y < 0f)
        {
            velocity.y = -2f;
        }

        // Setup Input variables using old input system
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // assigns a value to a vector 3 variable that tells the movement on the z and x axis
        Vector3 move = transform.right * x + transform.forward * z;

        // moves the player according to the value of move through the Move function in the character controller
        // It also uses the speed variable for the movement speed
        controller.Move(move * speed * Time.deltaTime);

        if (!playingFootsteps && move != Vector3.zero)
        {
            StartCoroutine(PlayFootSteps());
        }
        

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // gives a downward velocity to the player on the y axis for gravity
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    private bool playingFootsteps;
    public IEnumerator PlayFootSteps()
    {
        playingFootsteps = true;
        while (controller.velocity.magnitude > 1f)
        {
            source.Play();
            yield return new WaitForSeconds(0.5f);
        }
        source.Stop();
        playingFootsteps = false;
    }
}
