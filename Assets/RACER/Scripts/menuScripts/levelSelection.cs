using UnityEngine;
using System.Collections;

public class levelSelection : MonoBehaviour
{



	public static string levelName;

	public GameObject ControlSelection, LevelSelection, carSelectionParent, CarMeshparent;

	void Start ()
	{
	
	}

	public void OnButtonClick (string ButtonName)
	{
		SoundController.Static.PlayClickSound ();
		switch (ButtonName) {

		case "Back":
			carSelectionParent.SetActive (true);
			LevelSelection.SetActive (false);
			CarMeshparent.SetActive (true);
			break;
			
		case "highway":
				 
			levelName = "highWayGameplay";
			ControlSelection.SetActive (true);
			LevelSelection.SetActive (false);
				 
			break;
		case "city":
				 
			levelName = "cityGameplay";
			ControlSelection.SetActive (true);
			LevelSelection.SetActive (false);
			break;
				
		}
			
	}
		


}
