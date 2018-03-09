using UnityEngine;
using System.Collections;

public class freeCoinsADpromotion : MonoBehaviour {
 
	// Use this for initialization
	public GameObject showCointainer,notAvailContainer,carSelectionMenu;
	public Camera uiCamera;
	void OnEnable () {
	

 
 			//showCointainer.SetActive(false);
     //		notAvailContainer.SetActive(true);
 

	}
	
	void Update () {
		if( Input.GetKeyUp(KeyCode.Mouse0) )
		{
			
			MouseUp(Input.mousePosition );
		}
		
	}
	//this static bool will give coins only once  per game session.
	public static bool alreadyGiveFreeCoins=false;
	void MouseUp(Vector3 a )
	{
		Ray ray = uiCamera.ScreenPointToRay(a);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 500))
		{
			SoundController.Static.PlayClickSound();
			Debug.Log(gameObject.name + "    " + hit.collider.name);
			switch(hit.collider.name)
			{
			case "Download":
 //
				break;
			case "BACK":
				carSelectionMenu.SetActive(true);
				gameObject.SetActive(false);
				 
				break;
				
				
			}
			
		}
		
	}
	 
}
