using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class buyPopUP : MonoBehaviour {


	public GameObject carSelectionMenu,BuypopUpParent;

	public static int carCost;
 
	void Start () {
	
	}
	void OnEnable ()
	{


	}
	void OnDisable ()
	{

	}
	
	
	
	public void OnButtonClick (string ButtonName)
	{
		SoundController.Static.PlayClickSound ();
		switch(ButtonName)
			{
			case "YES":  
				 
				PlayerPrefs.SetInt("iscar"+carSelection.carIndex+"Purchased",1); // to save the car lock status
				Debug.Log(carSelection.carIndex);
				TotalCoins.staticInstance.deductCoins(carCost);
				 
				carSelectionMenu.SetActive(true);
			BuypopUpParent.SetActive(false);
		
				break;
			case "NO":

				carSelectionMenu.SetActive(true);
			BuypopUpParent.SetActive(false);

				break;
			 
				
			}
			
		}
		
	 
}
