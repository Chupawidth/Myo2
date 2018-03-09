using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class carSelection : MonoBehaviour {

	// Use this for initialization

 
 
	public GameObject buyButton,playButton,MainMenu,Carselectionmenu;
	public GameObject buyPopUp,InAPPMenu;
	public GameObject loadingLevelObj;

	void Start () 
	{
		//Debug.Log( "carSelection.cs is Attached to " + gameObject.name );

#if UNITY_EDITOR || UNITY_WEBPLAYER
		//TotalCoins.staticInstance.AddCoins(1000); //allot some coins to test it 
#endif

	}
	public GameObject menuObj;
	void Update () {
	 
		showcarINFO();
		if( Input.GetKeyUp(KeyCode.Escape) )
		{
			menuObj.SetActive(true);
			gameObject.SetActive(false);
		}

		if( Input.GetKeyUp(KeyCode.P) )
		{
			TotalCoins.staticInstance.AddCoins(999999);
		}
		if( Input.GetKeyUp(KeyCode.Q) )
		{
			TotalCoins.staticInstance.ClearCoins();
		}
	}

	void OnEnable ()
	{
		if(carIndex ==0 ) return;
		if( PlayerPrefs.GetInt("iscar"+carIndex+"Purchased",0) == 1 )
		{
			playButton.SetActive(true);
			buyButton.SetActive(false);
		}
		else{
			buyButton.SetActive(true);
			playButton.SetActive(false);
		}

		//AceButton.buttonDown += OnButtonClick;
	}
	void OnDisable ()
	{
		//AceButton.buttonDown -= OnButtonClick;
	}
	

	public void OnButtonClick (string ButtonName)
	{
		SoundController.Static.PlayClickSound ();	 
		switch(ButtonName)
			{
			case "next":
				showNextcar();
				break;
			case "previous":
				showPreviouscar();
				break;
				
			case "play":
				 
				loadingLevelObj.SetActive(true);
			Carselectionmenu.SetActive(false);
		
				 
				break;
			case "buycar" :
				purchasecars();

				break;
		case "Back" :
			
			MainMenu.SetActive(true);
			Carselectionmenu.SetActive(false);
		
			break;

			}

	 
		
	}

	public static int carIndex=0;
	public GameObject[] carMeshObjs;
	public Text carSpeedDisplayText,carPriceDisplayText,headingText;
	void showNextcar()
	{
		carIndex++;
		if( carIndex > carMeshObjs.Length-1 ) carIndex=0;
		for( int carCount=0 ; carCount<= carMeshObjs.Length-1; carCount ++ )
		{
			carMeshObjs[carCount].SetActive(false);
			
		}
		carMeshObjs[carIndex].SetActive(true);
		showcarINFO();
	}
	void showPreviouscar()
	{
		carIndex--;
		if( carIndex < 0 ) carIndex=carMeshObjs.Length-1;
		for( int carCount=0 ; carCount<= carMeshObjs.Length-1; carCount ++ )
		{
			carMeshObjs[carCount].SetActive(false);
			
		}
		carMeshObjs[carIndex].SetActive(true);
		showcarINFO();
	}
	 
	void showcarINFO()
	{

		switch(carIndex)
		{
		case 0:
			headingText.text="MODEL : Hunter ";
			carSpeedDisplayText.text ="Top speed : 180 kmh";
			carPriceDisplayText.text = "PRice  :    FREE ";
			playButton.SetActive(true);
			buyButton.SetActive(false);
			break;
		case 1:
			headingText.text="MODEL : Eagle";
			carSpeedDisplayText.text ="Top speed : 220 kmh";
			carPriceDisplayText.text = "PRice  :     1000 ";
			if(PlayerPrefs.GetInt("iscar1Purchased",0) == 1 )
			{
				playButton.SetActive(true);
				buyButton.SetActive(false);
			}
			else{
				buyButton.SetActive(true);
				playButton.SetActive(false);
			}
			break;
		case 2:
			headingText.text="MODEL : Racer ";
			carSpeedDisplayText.text ="Top speed : 230 kmh";
			carPriceDisplayText.text = "PRice  :     3000 ";
			
			if(PlayerPrefs.GetInt("iscar2Purchased",0) == 1 )
			{
				playButton.SetActive(true);
				buyButton.SetActive(false);
			}
			else{
				buyButton.SetActive(true);
				playButton.SetActive(false);
			}
			break;
		case 3:
			headingText.text="MODEL : Racer-X";
			carSpeedDisplayText.text ="Top speed : 240 kmh";
			carPriceDisplayText.text = "PRice  :     4000 ";
			
			if(PlayerPrefs.GetInt("iscar3Purchased",0) == 1 )
			{
				playButton.SetActive(true);
				buyButton.SetActive(false);
			}
			else{
				buyButton.SetActive(true);
				playButton.SetActive(false);
			}
			break;
		case 4:
			headingText.text="MODEL : F3-Car";
			carSpeedDisplayText.text ="Top speed : 260 kmh";
			carPriceDisplayText.text = "PRice  :     5000 ";
			
			if(PlayerPrefs.GetInt("iscar4Purchased",0) == 1 )
			{
				playButton.SetActive(true);
				buyButton.SetActive(false);
			}
			else{
				buyButton.SetActive(true);
				playButton.SetActive(false);
			}
			break;
		case 5:
			headingText.text="MODEL : Truck";
			carSpeedDisplayText.text ="Top speed : 280 kmh";
			carPriceDisplayText.text = "PRice  :     7000 ";
			
			if(PlayerPrefs.GetInt("iscar5Purchased",0) == 1 )
			{
				playButton.SetActive(true);
				buyButton.SetActive(false);
			}
			else{
				buyButton.SetActive(true);
				playButton.SetActive(false);
			}
			break;
		}

	}

	void purchasecars()
	{

		switch(carIndex)
		{
		case 1:

			if( TotalCoins.staticInstance.totalCoins >= 1000 )
			{
				buyPopUP.carCost=1000;//to set the cost in buyPopUpScript
				buyPopUp.SetActive(true);
				Carselectionmenu.SetActive(false);
			}
			else {
				InAPPMenu.SetActive(true);
				Carselectionmenu.SetActive(false);

			}
			 
			break;
		case 2:
			if( TotalCoins.staticInstance.totalCoins >= 3000 )
			{
				buyPopUP.carCost=3000;
				buyPopUp.SetActive(true);
				Carselectionmenu.SetActive(false);
			}
			else {
				InAPPMenu.SetActive(true);
				Carselectionmenu.SetActive(false);

			}
			
			break;
		case 3:
			if( TotalCoins.staticInstance.totalCoins >= 4000 )
			{
				buyPopUP.carCost=4000;
				buyPopUp.SetActive(true);
				Carselectionmenu.SetActive(false);
			}
			else {
				InAPPMenu.SetActive(true);
				Carselectionmenu.SetActive(false);

			}
			
			break;
		case 4:
			if( TotalCoins.staticInstance.totalCoins >= 5000 )
			{
				buyPopUP.carCost=5000;
				buyPopUp.SetActive(true);
				Carselectionmenu.SetActive(false);
			}
			else {
				InAPPMenu.SetActive(true);
				Carselectionmenu.SetActive(false);

			}
			
			break;
		case 5:
			if( TotalCoins.staticInstance.totalCoins >= 6000 )
			{
				buyPopUP.carCost=6000;
				buyPopUp.SetActive(true);
				Carselectionmenu.SetActive(false);
			}
			else {
				InAPPMenu.SetActive(true);
				Carselectionmenu.SetActive(false);

			}
			
			break;
		}

	}
}
