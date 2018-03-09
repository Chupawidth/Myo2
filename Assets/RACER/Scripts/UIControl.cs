using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{


	public enum UiState
	{
		pause,
		resume,
		gameOver,
		empty
	}

	public static float ShieldTime = 10;
	public static float MagnetTime = 15;
	public GameObject pauseMenu, gameOverMenu, HudParent;
	public RaycastHit hit;

	public static bool isBrakesOn = false;
	public Sprite BreakOn, BreakOff, NitOn, NitOff;
	public Image BreakButton, NitButton;
	 
	public GameObject buttonMode, AccelMode;

	void OnEnable ()
	{
	 

		UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.UnRegisterVirtualAxis ("Tilt");
		UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.UnRegisterVirtualAxis ("Horizontal");
		playerCarControl.gameEnded += onGameEnd;

		if (controlSelection.selectedMode == controls.tilt) { //accel
			AccelMode.SetActive (true);

		} else {
			buttonMode.SetActive (true);
		}
	}

	void OnDisable ()
	{
		playerCarControl.gameEnded -= onGameEnd;
		 
	}

	void onGameEnd (System.Object obj, System.EventArgs args)
	{
		pauseMenu.SetActive (false);
		HudParent.SetActive (false);

	}

	public	void OnButtonClick (string ButtonName)
	{
	

	
		switch (ButtonName) {
		case "PlayAgain":
			GamePlayController.isGameEnded = false;
			UnityEngine.SceneManagement.SceneManager.LoadScene (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().name);
			break;
		case "mainmenu":
			UnityEngine.SceneManagement.SceneManager.LoadScene ("MainMenu");
			break;

		case "resume":
			Time.timeScale = 1;
			pauseMenu.SetActive (false);
			HudParent.SetActive (true);
			SoundController.Static.listner.enabled = true;
				 
			break;
		case "pauseIngame":
			 
			Time.timeScale = 0;
			pauseMenu.SetActive (true);
			HudParent.SetActive (false);
			SoundController.Static.listner.enabled = false;
				 
			break;
		case "NitrousButton":
//			if (NitrousIndicator.Static.isNitrousOn) {
//				NitrousIndicator.Static.isNitrousOn = false;
//				playerCarControl.isDoubleSpeed = 1.0f;	
//				 
//			} else if (NitrousIndicator.NitrousCount > 1) {
//
//				NitrousIndicator.Static.isNitrousOn = true;
//				playerCarControl.isDoubleSpeed = 2.0f;
//			 
//			}
			break;

		case "BreakButton":
			 
			isBrakesOn = !isBrakesOn;

			 
			break;
		}
	}



 
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		#if UNITY_EDITOR
//		if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.RightControl)) {
//			if (NitrousIndicator.NitrousCount > 1) {
//				NitrousIndicator.Static.isNitrousOn = true;
//			}
//		}

		if (Input.GetKeyDown (KeyCode.DownArrow) || Input.GetKeyDown (KeyCode.Space)) {
			isBrakesOn = true;

		}
		if (Input.GetKeyUp (KeyCode.DownArrow) || Input.GetKeyUp (KeyCode.Space)) {
			isBrakesOn = false;

		}

		#endif
//		if (NitrousIndicator.NitrousCount < 1) {
//			NitrousIndicator.Static.isNitrousOn = false;
//		 
//		}  

//		if (NitrousIndicator.Static.isNitrousOn) {
//			
//			NitButton.sprite = NitOn;
//		} else {
//			
//			NitButton.sprite = NitOff;
//		}


		if (isBrakesOn) {
			BreakButton.sprite = BreakOn;
		} else {
			BreakButton.sprite = BreakOff;
		}


		if (Input.GetKeyDown (KeyCode.P)) {
			OnButtonClick ("pauseIngame");

		}
		if (Input.GetKeyDown (KeyCode.O)) {
			OnButtonClick ("resume");

		}
	}
}
