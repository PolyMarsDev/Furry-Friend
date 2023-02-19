using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float acceleration;
    [SerializeField] float drag;
    [SerializeField] float jumpForce;

    [SerializeField] float gravity;

    [SerializeField] Transform orientation;

    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance;
    [SerializeField] LayerMask groundLayer;

    private Rigidbody rb;
    

    private float xInput, zInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        zInput = Input.GetAxisRaw("Vertical");
    }
    void FixedUpdate()
    {
        Vector3 direction = new Vector3(xInput, 0, zInput);
        direction = orientation.TransformDirection(direction).normalized;
        direction.y = 0;

        rb.velocity = Accelerate(rb.velocity, direction);
        rb.velocity = Gravity(rb.velocity);

        if (Input.GetKey(KeyCode.Space) && IsGrounded())
            rb.velocity = Jump(rb.velocity);
    }

    Vector3 Jump(Vector3 velocity)
    {
        velocity.y = 0;
        return velocity + Vector3.up * jumpForce;
    }
    Vector3 Accelerate(Vector3 velocity, Vector3 direction)
    {
        return velocity + (direction * acceleration * Time.fixedDeltaTime) - (velocity*drag);
    }

    Vector3 Gravity(Vector3 velocity)
    {
        return velocity + Vector3.up*gravity*Time.fixedDeltaTime;
    }
    
    bool IsGrounded() => Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);
    void OnDrawGizmos()
    {
        Color col = IsGrounded() ? Color.green : Color.red;
        Gizmos.color = col;
        Gizmos.DrawWireSphere(groundCheck.position, groundDistance);
    }
}
