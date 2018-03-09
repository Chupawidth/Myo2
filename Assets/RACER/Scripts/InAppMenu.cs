using UnityEngine;
using System.Collections;

public class InAppMenu : MonoBehaviour {

	public GameObject InAppMenuParent,MainMenuParent;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnButtonClicked(string ButtonName){
		SoundController.Static.PlayClickSound ();
		switch (ButtonName){
		case "Buy1":
			Debug.Log("button1 is Clicked");
			//SoundController.Static.PlayClickSound();
			break;
		case "Buy2":
			Debug.Log("button2 is Clicked");
			//SoundController.Static.PlayClickSound();
			break;
		case "Buy3":
			Debug.Log("button3 is Clicked");
			//SoundController.Static.PlayClickSound();
			break;
		case "Back":
			InAppMenuParent.SetActive(false);
			MainMenuParent.SetActive(true);
			//SoundController.Static.PlayClickSound();
			break;

		}

	}
}
