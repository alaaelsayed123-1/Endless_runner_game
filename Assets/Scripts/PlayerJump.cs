using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 17f;
    public float gravity = 30f;
    public float groundY = 0f;
    
    private float verticalVelocity = 0f;
    private bool isGrounded;
    
    void Start()
    {
        groundY = transform.position.y;
    }
    
    void Update()
    {
        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            verticalVelocity = jumpForce;
            isGrounded = false;
        }
        
        // Apply gravity
        verticalVelocity -= gravity * Time.deltaTime;
        
        // Move
        float newY = transform.position.y + (verticalVelocity * Time.deltaTime);
        
        // Ground check
        if (newY <= groundY)
        {
            newY = groundY;
            verticalVelocity = 0f;
            isGrounded = true;
        }
        
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}