using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class EndScoreDisplayer : MonoBehaviour
{

	// Use this for initialization

	public Text coinsText, distancetext, BestDistanceText, score;
	private float coins, distance;
	//public GameObject playAgainButton, mainMenuButton;
	public Vector3[] originalPositions;

	public static event EventHandler showFullScreenAd;

	public GameObject NewSticker, Buttons;

	public GameObject coinMenu, ScoreMenu, DistanceMenu, BestDistanceMenu;


	void OnEnable ()
	{//to stop bgsounds on GameoVer
		SoundController.Static.BgSoundsObj.SetActive (false);
		SoundController.Static.PlayCarCrashSound ();
		Invoke ("LateStart", 1);
		SoundController.Static.PlaySlider ();
	}

	void LateStart ()
	{
		coinsText.text = "0";
		distancetext.text = "0";
		coinMenu.SetActive (true);
		iTween.ValueTo (gameObject, iTween.Hash ("from", coins, "to", GamePlayController.collectedCoinsCounts, "time", 1, "easetype", iTween.EaseType.easeInOutCubic,
			"onupdate", "changeCoinText", "delay", 1.2f, "oncomplete", "startScoreCount"));

		PlayerPrefs.SetInt ("TotalCoins", PlayerPrefs.GetInt ("TotalCoins", 0) + GamePlayController.collectedCoinsCounts);
		SoundController.Static.PlaySlider ();
		Buttons.SetActive (false);

	}

	void Update ()
	{
		#if UNITY_EDITOR
		if (Input.GetKey (KeyCode.R)) {
			UnityEngine.SceneManagement.SceneManager.LoadScene (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().name);

		}
		#endif
	}

	void changeCoinText (float newValue)
	{
		coinsText.text = "" + Mathf.RoundToInt (newValue);
		SoundController.Static.playCoinHit ();
	}

	void changeScoreText (float newValue)
	{
		score.text = "" + Mathf.RoundToInt (newValue);
		SoundController.Static.playCoinHit ();
	}


	void startScoreCount ()
	{
		ScoreMenu.SetActive (true);
		iTween.ValueTo (gameObject, iTween.Hash ("from", 0, "to", GamePlayController.Static.ingameScoreCount, "time", 1, "easetype", iTween.EaseType.easeInOutCubic,
			"onupdate", "changeScoreText", "oncomplete", "startDistanceCount"));
		SoundController.Static.PlaySlider ();
		
		 
	}

	void startDistanceCount ()
	{

		DistanceMenu.SetActive (true);
		iTween.ValueTo (gameObject, iTween.Hash ("from", 0, "to", GamePlayController.distanceTravelled, "time", 1, "easetype", iTween.EaseType.easeInOutCubic,
			"onupdate", "changeDistanceText", "oncomplete", "BestDistance"));
		SoundController.Static.PlaySlider ();

	 
	}

	void changeDistanceText (float newValue)
	{
		SoundController.Static.playCoinHit ();
		distancetext.text = "" + Mathf.RoundToInt (newValue) + "m";
	}

	void BestDistance ()
	{
		SoundController.Static.PlaySlider ();
		BestDistanceMenu.SetActive (true);
		if (PlayerPrefs.GetInt ("bestDistance") < GamePlayController.distanceTravelled) {
			NewSticker.SetActive (true);

			PlayerPrefs.SetInt ("bestDistance", Mathf.RoundToInt (GamePlayController.distanceTravelled));

		 

		}
		BestDistanceText.text = "" + PlayerPrefs.GetInt ("bestDistance") + "M";

		Invoke ("showButtons", 1.0f);

	}

	void showButtons ()
	{
		SoundController.Static.PlaySlider2 ();
		//adManagerUnity.Static.showAD();
		//raise an adevent here 
		Invoke ("showAd", 1.55f);
		Buttons.SetActive (true);
	}

	public void showAd ()
	{
		if (showFullScreenAd != null)
			showFullScreenAd (null, null); 
	
	}
	
	 
}
