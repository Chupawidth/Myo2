using UnityEngine;
using System.Collections;
using System;
using UnityStandardAssets.CrossPlatformInput;

public class playerCarControl : MonoBehaviour
{
	public enum VehicleType{
		Car,Plane
	}

	public VehicleType vehicleType;
	public float turnSpeed;
	public float maxSpeed = 12;
	public float carSpeed;

	public float[] limits;
	public Transform carBody;
	public Transform[] wheelObjs;
	public float wheelSpeed;

	public static event EventHandler gameEnded;
	public static event EventHandler switchOnMagnetPower;
	public static event EventHandler switchOFFMagnetPower;
	public static event EventHandler DisplayScoreOnScreen;

	public float magnetPowerTime = 3.0f;
	private float nextFire;
	public static float isDoubleSpeed = 1;
	public Transform thisTrans;
	public GameObject particleParent;
	public static Vector3 thisPosition;
	public float brakeSpeed = 0;
	carCamera camScript;
	Camera mainCamera;

    public bool isMyoControl;
    public float myoValue;


	void OnEnable ()
	{
		
		thisTrans = transform;
		mainCamera = Camera.main;
		foreach (Transform t in gameObject.GetComponentsInChildren<Transform>()) {
			if (t.name.Contains ("Effect")) {
				particleParent = t.gameObject;
			}
		}

		isDoubleSpeed = 1;
		camScript = Camera.main.GetComponent<carCamera> ();
		camScript.targetTrans = thisTrans;

		#if UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8
		  
		foreach (Transform t in transform.GetComponentsInChildren<Transform>()) {
			if (t.name.Contains ("Shadow")) {
				Debug.Log (t.name);
				Destroy (t.gameObject);
			}
		}
		#endif

		#if !UNITY_EDITOR
		ignoreCollision = false;
		#endif
	}

 
  
	public bool ignoreCollision = false;

	void OnTriggerEnter (Collider incoming)
	{
		if (incoming.tag.Contains ("coin")) {
			 
			coinControl coinScript = incoming.gameObject.GetComponent<coinControl> () as coinControl;
			coinScript.moveToPlayer = true;
			coinScript.coinTarget = thisTrans.position + new Vector3 (-160, 50, 250);
			Destroy (incoming);
			  
			GamePlayController.collectedCoinsCounts++;

		} else if (incoming.GetComponent<Collider> ().name.Contains ("Magnet")) {
			Destroy (incoming.gameObject);
			if (switchOnMagnetPower != null)
				switchOnMagnetPower (null, null);
			Invoke ("EndMagnetPower", magnetPowerTime);
		} else if (incoming.GetComponent<Collider> ().name.Contains ("InstantNitrous")) {
			Destroy (incoming.gameObject);

//			NitrousIndicator.NitrousCount = 100; // set to nitrous    
//			NitrousIndicator.Static.UpdateNitrousDisplay ();
		}
		if (isGameEnded || ignoreCollision)
			return;
		string incTag = incoming.tag;

		if (incTag.Contains ("trafficCar")) {
//			carSpeed = 0;
//			maxSpeed = 0;
//			wheelSpeed = 0;
//			isDoubleSpeed = 0;
//			turnSpeed = 0;
//			GetComponent<Rigidbody> ().velocity = Vector3.zero;
//			isDoubleSpeed = 1;
//			GamePlayController.isGameEnded = true;
//			if (gameEnded != null)
//				gameEnded (null, null);
//			iTween.ShakePosition (Camera.main.gameObject, new Vector3 (1, 1, 1), 0.6f);
//			//Debug.Log("traffic collision detected " );
//			GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
//			isGameEnded = true;
//			GameObject trafficCar = incoming.gameObject; 
//
//			trafficCar.SendMessage ("StopCar", SendMessageOptions.DontRequireReceiver);//to stop the car
//			iTween.RotateTo (trafficCar, new Vector3 (0, UnityEngine.Random.Range (-1, 2) * 25, 0), 1.0f);

			SoundController.Static.PlayCarCrashSound ();
			SoundController.Static.carEngine.pitch = Mathf.Clamp ((moveHorizontal * moveHorizontal) / 10 + isDoubleSpeed, 1.0f, 1.1f);

		}

	}

	void EndMagnetPower ()
	{
		if (switchOFFMagnetPower != null)
			switchOFFMagnetPower (null, null);
	}

	bool isGameEnded = false;

	 

	float timeTicks;

	void OnTriggerStay (Collider collisionInfo)
	{

		string incname = collisionInfo.name;
		
		if (incname.Contains ("Reward_Trigger")) {
			timeTicks = Time.timeScale;
			timeTicks++;

		}

	}

	int CollidedObjId;

	void OnTriggerExit (Collider collisionInfo)
	{
		if (GamePlayController.isGameEnded)
			return;
		

		string incname = collisionInfo.name;
		
		if (incname.Contains ("Reward_Trigger")) {
			if (timeTicks >= 1 && collisionInfo.GetInstanceID () != CollidedObjId) {
			

				if (DisplayScoreOnScreen != null)
					DisplayScoreOnScreen (collisionInfo.transform.position + new  Vector3 (0, 0, 40), null);
				CollidedObjId = collisionInfo.GetInstanceID ();
				GamePlayController.Static.ingameScoreCount += 25;
				timeTicks = 0;

//				NitrousIndicator.NitrousCount += 10; // set to nitrous    
//				NitrousIndicator.Static.UpdateNitrousDisplay ();
			}
		}
	
	}

	float carAudioPitchEngine = 1;
    public float moveHorizontal = 0;

    public float turnValueHorizontal;
    public float turnValueVertical;
	public Vector3 movement;

	void Update ()
	{
		thisPosition = thisTrans.position;

		if (UIControl.isBrakesOn == true) {
			brakeSpeed = 0.5f;
		} else {
			brakeSpeed = 1;
		}

		foreach (Transform t in wheelObjs) {

			t.Rotate (wheelSpeed * Time.deltaTime, 0, 0);
		}
        if(isMyoControl){
            moveHorizontal = myoValue*2f;
        }else{
            moveHorizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        }

        turnValueHorizontal = moveHorizontal * Time.deltaTime * turnSpeed;
        //turnValueVertical = 1f - moveVertical * Time.deltaTime * turnSpeed;

		movement = new Vector3 (turnValueHorizontal, 0.0f, carSpeed * isDoubleSpeed * brakeSpeed * Time.deltaTime);

		thisTrans.position = new Vector3 (
			Mathf.Clamp (thisTrans.position.x, limits [0], limits [1]),
			0.0f, thisTrans.position.z
		);

		if ((thisTrans.position.x > limits [0] || thisTrans.position.x < limits [1])) {
			thisTrans.Translate (movement);
		}
		  
		if (isDoubleSpeed == 1) {
			hideNitrousParticle ();
		} else {
			showNitrousParticle ();
		}

		if (GamePlayController.isGameEnded)
			return;
		 
		if (carSpeed < maxSpeed)
			carSpeed += Time.deltaTime / 3;
		SoundController.Static.carEngine.pitch = Mathf.Clamp ((moveHorizontal * moveHorizontal) / 10 + isDoubleSpeed, 1.0f, 1.1f);

		if ((thisTrans.position.x <= limits [0] || thisTrans.position.x >= limits [1])) {
			thisTrans.rotation = Quaternion.Lerp (thisTrans.rotation, Quaternion.Euler (0, 0, 0), Time.deltaTime * 5);
 			 
		} else {
			if(vehicleType== VehicleType.Car){
				thisTrans.rotation = Quaternion.Slerp (thisTrans.rotation, Quaternion.Euler (0, moveHorizontal * 1000 * Time.deltaTime, 0f), Time.deltaTime * 4);
			}else if(vehicleType == VehicleType.Plane){

				thisTrans.rotation = Quaternion.Slerp (thisTrans.rotation, Quaternion.Euler (0, 0f, -moveHorizontal * 1000 * Time.deltaTime/3f), Time.deltaTime * 4);
			}
			  
		}

	}



	public void switchoffmagnet ()
	{
		if (switchOFFMagnetPower != null) {
			switchOFFMagnetPower (null, null);
		}
	}

	void showNitrousParticle ()
	{
		if (particleParent != null)
			particleParent.SetActive (true);

		SoundController.Static.boostAudioControl.enabled = true;
	}

	void hideNitrousParticle ()
	{
		if (particleParent != null)
			particleParent.SetActive (false);
		SoundController.Static.boostAudioControl.enabled = false;
	}

	bool checkRange (float value, float min, float max)
	{

		return value > min && value < max;
	}
}
 
