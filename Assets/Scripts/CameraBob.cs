using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBob : MonoBehaviour
{
    [SerializeField] float sprintBobSpeed;
    
    [SerializeField] float bobSpeed;

    [SerializeField] float bobIntensity;

    [SerializeField] Rigidbody playerRb;

    [SerializeField] PlayerController playerController;
    float globalTimer;
    void Update()
    {
        globalTimer += Time.deltaTime;
    }
    void LateUpdate()
    {
        Vector3 playerVelocity = new Vector3(playerRb.velocity.x, 0, playerRb.velocity.z);
        if (playerVelocity.magnitude > 0.1)
        {
            transform.position = new Vector3(transform.position.x, transform.parent.position.y + Mathf.Sin(globalTimer * (Mathf.PI * 2) / (playerController.sprint ? sprintBobSpeed : bobSpeed)) * bobIntensity  * playerVelocity.magnitude, transform.position.z);
        }
    }
}
