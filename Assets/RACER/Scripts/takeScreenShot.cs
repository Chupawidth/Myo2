using UnityEngine;
using System.Collections;

public class takeScreenShot : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		//DontDestroyOnLoad (gameObject);
	}

	string resolution;
	// Update is called once per frame
	void Update ()
	{

		if (Input.GetKeyDown (KeyCode.G)) {

						 
			resolution = "" + Screen.width + "X" + Screen.height;
			ScreenCapture.CaptureScreenshot ("ScreenShot-" + resolution + "-" + PlayerPrefs.GetInt ("number", 0) + ".png", 2);
			PlayerPrefs.SetInt ("number", PlayerPrefs.GetInt ("number", 0) + 1);
			//Debug.Log ("takenShot with " + resolution);

		}
	
	}
}
