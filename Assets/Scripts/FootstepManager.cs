using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepManager : MonoBehaviour
{
    [SerializeField] float sprintStepSpeed;
    
    [SerializeField] float stepSpeed;

    [SerializeField] float interval;

    [SerializeField] Rigidbody playerRb;

    [SerializeField] PlayerController playerController;

    [SerializeField] float LowPitchRange = .95f;
	[SerializeField] float HighPitchRange = 1.05f;

    [SerializeField] AudioClip[] footsteps;

    float globalTimer;
    void Update()
    {
        globalTimer += Time.deltaTime*(playerController.sprint ? sprintStepSpeed : stepSpeed);
    }

    void LateUpdate()
    {
        Vector3 playerVelocity = new Vector3(playerRb.velocity.x, 0, playerRb.velocity.z);

        if (playerController.IsGrounded() && playerVelocity.magnitude > 1 && globalTimer > interval)
        {
            RandomSoundEffect(footsteps);
            globalTimer = 0;
        }
    }

    public void RandomSoundEffect(params AudioClip[] clips)
	{
		int randomIndex = Random.Range(0, clips.Length);
		float randomPitch = Random.Range(LowPitchRange, HighPitchRange);

        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.pitch = randomPitch;
		audioSource.clip = clips[randomIndex];
		audioSource.Play();
        Destroy(audioSource, audioSource.clip.length);
    }
}
