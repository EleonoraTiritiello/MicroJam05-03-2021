using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;
    public float movementSpeed = 1;
    public float gravity = 9.8f;
    private float velocity = 0;

    public float jumpPower = 15.0f;
    private bool isJumping = false;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
    }

    void Movement()
    {
        // player movement - forward, backward, left, right
        float horizontal = Input.GetAxis("Horizontal") * movementSpeed;
        float vertical = Input.GetAxis("Vertical") * movementSpeed;
        Input.GetKeyDown(KeyCode.Space);
        characterController.Move((Vector3.right * horizontal + Vector3.forward * vertical) * Time.deltaTime);

        // Gravity
        if (characterController.isGrounded)
        {
            velocity = 0;
        }
        else
        {
            velocity -= gravity * Time.deltaTime;
            characterController.Move(new Vector3(0, velocity, 0));
        }
    }

    void Jump()
    {
        //If character isn’t jumping
        if (!isJumping)
        {
            //Jump
            if (Input.GetButton("Jump"))
            {
                isJumping = true;
                
            }
        }
    }
}
