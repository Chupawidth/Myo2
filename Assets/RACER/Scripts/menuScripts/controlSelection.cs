using UnityEngine;
using System.Collections;

public enum controls
{

	tilt = 0,
	buttons
}

public class controlSelection : MonoBehaviour
{

	public GameObject ControlSelection, LevelSelection, LoadingMenu;
	public static controls selectedMode = controls.buttons;

	 

	public void OnButtonClick (string ButtonName)
	{
		SoundController.Static.PlayClickSound ();
		switch (ButtonName) {

		case "Back":
			 
			ControlSelection.SetActive (false);
			LevelSelection.SetActive (true);
			break;

		case "Accel":
			selectedMode = controls.tilt;
			LoadingMenu.SetActive (true);
			ControlSelection.SetActive (false);

			break;
		case "Button":
			selectedMode = controls.buttons;
			LoadingMenu.SetActive (true);
			ControlSelection.SetActive (false);
			break;

		}

	}
}
