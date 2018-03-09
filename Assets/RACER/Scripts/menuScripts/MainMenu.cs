using UnityEngine;
using System.Collections;
using System;
public class MainMenu : MonoBehaviour
{


	public GameObject exitButton;
	public GameObject CreditsObject, MainMenuParent;
	public GameObject carSelection;


	// Use this for initialization
	void Start ()
	{
		//Debug.Log ("MainMenu.cs is Attached to " + gameObject.name);
		
		#if UNITY_IPHONE
		// Apple won't allow quit button in their app submission guides  
		exitButton.setActive(false);
		#endif
	}
	void OnEnable ()
	{

	
	}
	void OnDisable ()
	{

	}

 
	public void OnButtonClick (string ButtonName)
	{

		switch (ButtonName) {
		case "Play":
			carSelection.SetActive (true);
			MainMenuParent.SetActive (false);
			SoundController.Static.PlayClickSound ();
			break;
		case "Credits":
			SoundController.Static.PlayClickSound ();
			CreditsObject.SetActive (true);
			MainMenuParent.SetActive (false);
			 
			break;
				
		case "More":
			string url = "https://play.google.com/store/apps/developer?id=Ace+Games";
				#if UNITY_ANDROID
			  url = "https://play.google.com/store/apps/developer?id=Ace+Games";
				#endif
				#if UNITY_IPHONE
			 	url = "https://itunes.apple.com/us/app/jet-boat-rush/id877610071?ls=1&mt=8";
				#endif
				#if UNITY_WP8
			  url ="http://www.windowsphone.com/en-in/store/app/jet-car-rush/b693c43c-dc64-4b03-b467-ee5821308fd3";
				#endif
				#if UNITY_WEBPLAYER
			  url = "https://www.assetstore.unity3d.com/#publisher/920";
				#endif
			Application.OpenURL (url);
			SoundController.Static.PlayClickSound ();
			break;
		case "RateUs":
			string rateurl = "https://play.google.com/store/apps/developer?id=Ace+Games";
				#if UNITY_ANDROID
			      rateurl = "https://play.google.com/store/apps/details?id=com.Acegames.racer";
				#endif
				#if UNITY_IPHONE
			  rateurl ="https://itunes.apple.com/us/app/f1-traffic-racer/id904284766?ls=1&mt=8";
				#endif
				#if UNITY_WP8
			  rateurl="http://www.windowsphone.com/en-in/store/app/jet-car-rush/b693c43c-dc64-4b03-b467-ee5821308fd3";
				#endif
				#if UNITY_WEBPLAYER
			  rateurl = "https://play.google.com/store/apps/details?id=com.Acegames.racer";
				#endif
			SoundController.Static.PlayClickSound ();
			Application.OpenURL (rateurl);
			break;
		case "Quit":
			SoundController.Static.PlayClickSound ();
			Application.Quit ();
			break;
				
		}

		
	}
	 
		
	 
}
