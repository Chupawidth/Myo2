using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour
{

	// Use this for initialization

	public AudioClip Slider, Slider2, clickSound, CarCrashSound;
	public AudioClip coinHitSound;
	public AudioClip pickUpSound;
	 
	public static SoundController Static;
	public AudioSource[] audioSources;
	public AudioSource boostAudioControl;
	public GameObject BgSoundsObj;
	public AudioSource carEngine;

	public AudioListener listner;

	void Start ()
	{
		Static = this;
		//toStop bg music on mainMenu and Splash Screen
		 
		listner = GetComponent<AudioListener> ();
	}

	 
	public void PlayCarCrashSound ()
	{
		carEngine.enabled = false;
		swithAudioSources (CarCrashSound);
		StartCoroutine(RePlayCarEngineSound(0.5f));
	}

	IEnumerator RePlayCarEngineSound(float delaySound){
		yield return new WaitForSeconds(delaySound);
		carEngine.enabled = true;
	}

	public void PlayClickSound ()
	{
	
		swithAudioSources (clickSound);
	}

	public void playCoinHit ()
	{
		 
		audioSources [0].PlayOneShot (coinHitSound);
	}

	public void PlayPowerPickUp ()
	{
		 
		swithAudioSources (pickUpSound);
	}

	public void PlaySlider ()
	{
		 
		swithAudioSources (Slider);

	}

	public void PlaySlider2 ()
	{

		swithAudioSources (Slider2);

	}



	void swithAudioSources (AudioClip clip)
	{
		if (audioSources [0].isPlaying) {
			audioSources [1].PlayOneShot (clip);
		} else
			audioSources [0].PlayOneShot (clip);

	}
}
