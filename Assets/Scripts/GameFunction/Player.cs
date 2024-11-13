using UnityEngine;
using UnityEngine.UI;

public class JumpButtonController : MonoBehaviour
{
    public CharacterController controller;
    public Button jumpButton;
    public float jumpHeight = 3f;
    public float gravity = -9.81f;
    public GameObject collection;
    public static int HP = 3;
    private Vector3 velocity;
    private bool isGrounded;
    public float walkSpeed = 5f;  // Normal walking speed
    public float slowSpeed = 2f;  // Speed when walking on quicksand
    private Vector3 lastCheckpoint;
    private CharacterController characterController;
    private float currentSpeed;
    private Vector3 respawnPosition;


    void Start()
    {
        // Add a listener to the button to call the Jump method when pressed
        jumpButton.onClick.AddListener(Jump);
        characterController = GetComponent<CharacterController>();
        lastCheckpoint = transform.position;
        respawnPosition = Checkpoint.checkpointPosition;
    }

    void Update()
    {
        Move();
        ApplyGravity();

        if (characterController.isGrounded)
        {
            velocity.y = 0f; // Reset vertical velocity if grounded
        }
        velocity.y += gravity * Time.deltaTime;  // Apply gravity
        characterController.Move(velocity * Time.deltaTime); // Apply movement
        
    }

    private void Move()
    {
        isGrounded = controller.isGrounded;

        // Reset vertical velocity when grounded
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * Time.deltaTime);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    private void ApplyGravity()
    {
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "date")
        {
            Debug.Log("collide");

            if (HP < 3)
            {
                Destroy(other.gameObject);
                HP++;
            }

        }
        if (other.gameObject.tag == "Trap")
        {
            HP--;
            if (HP == 0)
            {
                Destroy(gameObject);
                Application.LoadLevel("MainMenu");
                HP++;
                HP++;
                
            }
        }
        if (other.gameObject.tag == "collecter")
        {
            Destroy(other.gameObject);
            collection.SetActive(true);
            Debug.Log("coo");

        }


    }
    public void SetCheckpoint(Vector3 checkpointPosition)
    {
        lastCheckpoint = checkpointPosition;
    }

    // Respawn the player at the last checkpoint
    void Respawn()
    {
        transform.position = lastCheckpoint;
        Debug.Log("Player respawned at checkpoint!");
    }
    public void xbutton()
    {
        collection.SetActive(false);
    }
    public void RespawnAtCheckpoint()
    {
        if (Checkpoint.checkpointActivated)
        {
            transform.position = respawnPosition;  // Respawn player at the last checkpoint
              // Reduce health by 1 on respawn (this is the core part)

            // Ensure that the player doesn't respawn with negative hearts
            if (HP < 0) HP = 0;
        }
    }

}
