using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour
{


	public GameObject[] trafficCars, roadBlocks, vlcCans, sideTres, coinsParent, powerPickups, playerCars;
	public static GamePlayController Static;
	public static int collectedCoinsCounts, distanceTravelled;
	public static bool isGameEnded = false;
	public GameObject playerObj1;
	public GameObject playerObj2;
	public GameObject playerObj3;
	public GameObject[] carTemplate;
	public GameObject gameEndMenu;
	public Text coinsText, distanceText, ScoreText;
    public Material[] materialTemplates;
	float startPlayerCarPositionZ;
	public carCamera camScript;
	public float trafficStartingPoint;
	public float trafficCarDistance;
	public int ingameScoreCount;
	   
	
	// Use this for initialization
	void OnEnable ()
	{
		isGameEnded = false;
		playerCarControl.gameEnded += onGameEnd;
		coinControl.isONMagetPower = false;



	}

	void OnDisable ()
	{
		playerCarControl.gameEnded -= onGameEnd;
	}

	void onGameEnd (System.Object obj, System.EventArgs args)
	{
		CancelInvoke ();
		gameEndMenu.SetActive (true);
		this.enabled = false;
	}

	void Start ()
	{
		Static = this;
		//RenderSettings.fog = true;
		//for traffic cars

		collectedCoinsCounts = 0;

		if (camScript == null)
			camScript = Camera.main.GetComponent<carCamera> ();


		SpawnPlayer(0);
        //gameObject.SendMessage("OnGameStart", SendMessageOptions.DontRequireReceiver);
        OnGameStart();
	}

	public void OnGameStart ()
	{

	 
//		InvokeRepeating ("generateTrafficCars", 2, 1.0f);
//		InvokeRepeating ("generateTrafficCars", 60, 2.0f);
		InvokeRepeating ("generatePowerups", 15, 15);
		
		//for sideObject trees
		//and we don't need tree and rock in city
		if (!Application.loadedLevelName.Contains ("city")) {
			InvokeRepeating ("generateSideTress", 0, 2.0f);
		}
		
		InvokeRepeating ("generateCoins", 0, 2);
	}

	void LateUpdate ()
	{
	
		coinsText.text = "" + collectedCoinsCounts;
		ScoreText.text = "" + ingameScoreCount;
//		distanceText.text = "" + GamePlayController.distanceTravelled + " m";
		if (isGameEnded) {
			coinsText.text = "";
			distanceText.text = "";
			ScoreText.text = "";
			//gameOverTxt.text = "GAME OVER :(";
		} else {
			distanceTravelled = Mathf.RoundToInt ((playerCarControl.thisPosition.z + (1104f)) / 10);
		}

		#if UNITY_EDITOR
//		if (Input.GetKey (KeyCode.R)) {
//			UnityEngine.SceneManagement.SceneManager.LoadScene (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().name);
//
//		}

		#endif
	}

	float trafficCarCount = 5;

	void SpawnPlayer(int playerIndex){

		switch(playerIndex){
		case 0:
    			playerObj1 = GameObject.FindGameObjectWithTag ("Player1");

    			if (playerObj1 == null){
    				playerObj1 = GameObject.Instantiate (playerCars [carSelection.carIndex]) as GameObject;
    				playerObj1 = GameObject.Instantiate (playerCars [carSelection.carIndex]) as GameObject;
    				playerObj1 = GameObject.Instantiate (playerCars [carSelection.carIndex]) as GameObject;

    			}
                playerObj1 = CreateNewMaterial(0,playerObj1);
                startPlayerCarPositionZ = playerObj1.transform.position.z;
    			camScript.targetTrans = playerObj1.transform;
    			break;
		case 1: 
    			playerObj2 = GameObject.FindGameObjectWithTag ("Player2");

    			if (playerObj2 == null){
    				playerObj2 = GameObject.Instantiate (playerCars [carSelection.carIndex]) as GameObject;
    				playerObj2 = GameObject.Instantiate (playerCars [carSelection.carIndex]) as GameObject;
    				playerObj2 = GameObject.Instantiate (playerCars [carSelection.carIndex]) as GameObject;

    			}
                playerObj2 = CreateNewMaterial(1, playerObj2);
    			startPlayerCarPositionZ = playerObj2.transform.position.z;
    			camScript.targetTrans = playerObj2.transform;
    			break;
		case 2:
    			playerObj3 = GameObject.FindGameObjectWithTag ("Player3");

    			if (playerObj3 == null){
    				playerObj3 = GameObject.Instantiate (playerCars [carSelection.carIndex]) as GameObject;
    				playerObj3 = GameObject.Instantiate (playerCars [carSelection.carIndex]) as GameObject;
    				playerObj3 = GameObject.Instantiate (playerCars [carSelection.carIndex]) as GameObject;

                }
                playerObj3 = CreateNewMaterial(2, playerObj3);
    			startPlayerCarPositionZ = playerObj3.transform.position.z;
    			camScript.targetTrans = playerObj3.transform;
    			break;
		}




	}

    GameObject CreateNewMaterial(int modelIndex,GameObject model){
        if (ApplicationManager.instance.painterImageDataList != null && ApplicationManager.instance.painterImageDataList.Count != 0)
        {
            Material newMaterial = new Material(materialTemplates[ApplicationManager.instance.painterImageDataList[modelIndex].imageIndex]);
            newMaterial.name = "ship" + modelIndex;
            newMaterial.mainTexture = ApplicationManager.instance.painterImageDataList[modelIndex].texture;
            newMaterial.SetTexture("_DetailAlbedoMap", ApplicationManager.instance.painterImageDataList[modelIndex].texture);

            MeshRenderer[] modelMeshRenderers = model.GetComponentsInChildren<MeshRenderer>();
            foreach (var mesh in modelMeshRenderers)
            {
                if (mesh.name != "B_Body Material 3")
                    mesh.material = newMaterial;
            }
        }
        return model;
    }

	void generateTrafficCars ()
	{
		int randomNumber = Random.Range (0, trafficCars.Length);
		GameObject trafficObj = GameObject.Instantiate (trafficCars [randomNumber]) as GameObject;
		
		trafficObj.transform.position = new Vector3 (Random.Range (-6f, 6f) * 4.5f, 0, playerObj1.transform.position.z + (trafficCarDistance));


		
		trafficObj.transform.position = new Vector3 (Random.Range (-6f, 6f) * 4.5f, 0, playerObj1.transform.position.z + 500);

		trafficCarCount++;

		AceHelper.randomizeArray (trafficCars);
	}

	void generatePowerups ()
	{
		
		GameObject pickupObj = GameObject.Instantiate (powerPickups [Random.Range (0, powerPickups.Length - 1)]) as GameObject;
		
		pickupObj.transform.position = new Vector3 (Random.Range (-10, 10), 5, playerObj1.transform.position.z + 400 + (Random.Range (1, 10) * 10));
	}

	void generateSideTress ()
	{

		//left side
		GameObject treeObj = GameObject.Instantiate (sideTres [Random.Range (0, sideTres.Length - 1)]) as GameObject;
		treeObj.transform.position = new Vector3 (Random.Range (-80, -60), 0, playerObj1.transform.position.z + 780);
		treeObj.transform.Rotate (0, Random.Range (0, 36) * 10, 0);

		treeObj = GameObject.Instantiate (sideTres [Random.Range (0, sideTres.Length - 1)]) as GameObject;
		treeObj.transform.position = new Vector3 (Random.Range (-90, -60), 0, playerObj1.transform.position.z + 1230);
		treeObj.transform.Rotate (0, Random.Range (0, 36) * 10, 0);
		//rightside
		treeObj = GameObject.Instantiate (sideTres [Random.Range (0, sideTres.Length - 1)]) as GameObject;
		treeObj.transform.position = new Vector3 (Random.Range (60, 80), 0, playerObj1.transform.position.z + 820);
		treeObj.transform.Rotate (0, Random.Range (0, 36) * 10, 0);

		treeObj = GameObject.Instantiate (sideTres [Random.Range (0, sideTres.Length - 1)]) as GameObject;
		treeObj.transform.position = new Vector3 (Random.Range (60, 90), 0, playerObj1.transform.position.z + 1320);
		treeObj.transform.Rotate (0, Random.Range (0, 36) * 10, 0);
	}

	void generateCoins ()
	{
		//left side
		GameObject coin = GameObject.Instantiate (coinsParent [Random.Range (0, coinsParent.Length - 1)]) as GameObject;
		coin.transform.position = new Vector3 (Random.Range (-14, 6), 2, playerObj1.transform.position.z + 400);
		
		Destroy (coin, 10);
		 
	}
}
