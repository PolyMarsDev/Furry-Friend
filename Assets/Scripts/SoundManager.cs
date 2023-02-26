using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioClip[] consume;

    // Music player components
    [SerializeField] AudioSource MusicSource;

	// Random pitch adjustment range.
	[SerializeField] float LowPitchRange = .95f;
	[SerializeField] float HighPitchRange = 1.05f;

	// Singleton instance.
	public static SoundManager Instance = null;
	
	// Initialize the singleton instance.
	private void Awake()
	{
		// If there is not already an instance of SoundManager, set it to this.
		if (Instance == null)
		{
			Instance = this;
		}
		//If an instance already exists, destroy whatever this object is to enforce the singleton.
		else if (Instance != this)
		{
			Destroy(gameObject);
		}
	}

	// Play a single clip through the sound effects source.
	public void Play(AudioClip clip)
	{
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.clip = clip;
		audioSource.Play();
        Destroy(audioSource, audioSource.clip.length);
	}

	// Play a single clip through the music source.
	public void PlayMusic(AudioClip clip)
	{
		MusicSource.clip = clip;
		MusicSource.Play();
	}

	// Play a random clip from an array, and randomize the pitch slightly.
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

    public void PlayConsume()
	{
        RandomSoundEffect(consume);
    }


	
}