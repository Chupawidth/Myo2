using UnityEngine;
using System.Collections;
using System;

public class ScoreDisplayer : MonoBehaviour
{

	public GameObject scoreDisplayer2d;

	void OnEnable ()
	{
		playerCarControl.DisplayScoreOnScreen += ShowScorePopUp;
	}

	void OnDisable ()
	{
		playerCarControl.DisplayScoreOnScreen -= ShowScorePopUp;
	}

	float lastTime;
	void ShowScorePopUp (System.Object obj, EventArgs args)
	{
		if (Time.timeSinceLevelLoad - lastTime < 0.1f)
			return;

		lastTime = Time.timeSinceLevelLoad;
		SoundController.Static.PlayPowerPickUp ();
		Vector3 pos = (Vector3)obj;
		GameObject score = GameObject.Instantiate (scoreDisplayer2d) as GameObject;
		score.transform.parent = this.transform;
		score.transform.position = RectTransformUtility.WorldToScreenPoint (Camera.main, pos);
		Destroy (score, 2);

	}
	// Use this for initialization
	 
}
