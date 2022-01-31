using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravity = 3.5f; //gravity force
    public float speed = 2f; //normal player movement speed
    public float jumpForce = 0.5f; //jump force

    private CharacterController controller;
    private Vector3 motion;
    private float currentspeed = 0;
    private float velocity = 0;
    // Awake is called before the start method
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        currentspeed = speed;
    }

    private void FixedUpdate()
    {
        motion = Vector3.zero;
        bool grounded = controller.isGrounded;

        if (grounded == true)

            velocity = -gravity * Time.deltaTime;

        else

            velocity -= gravity * Time.deltaTime;
    }
    // Update is called once per frame
    void Update()
    {

        if (controller.isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) == true)
            {
                velocity = jumpForce;
            }
        }
        ApplyMovement();
    }

    void ApplyMovement()
    {
        float inputX = Input.GetAxisRaw("Vertical") * currentspeed;
        float inputY = Input.GetAxisRaw("Horizontal") * currentspeed;
        motion += transform.forward * inputX * Time.deltaTime;
        motion += transform.right * inputY * Time.deltaTime; 
        motion.y += velocity * Time.deltaTime;
        controller.Move(motion);
    }
}
