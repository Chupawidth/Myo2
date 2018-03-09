using UnityEngine;
using System.Collections;
using System;

public class coinControl : MonoBehaviour
{

		// Use this for initialization
		float coinSpeed = 1.0f;
		Transform coinTrans ;
		public static int  turnCount;
		public BoxCollider box ;
		Vector3 originalScale;
		public static bool isONMagetPower ;
		public bool moveToPlayer = false ;
		public bool moveToCoinTarget =false;
		Transform thisTrans;

		void OnEnable ()
		{
				thisTrans = transform;
				box = GetComponent<BoxCollider> () as BoxCollider;
				originalScale = box.size;
				playerCarControl.switchOnMagnetPower += onMagenetPower;
				playerCarControl.switchOFFMagnetPower += offMagenetPower;
				playerCarControl.gameEnded += onGameEnd;
				if (isONMagetPower)
						onMagenetPower (null, null);
		}

		void OnDisable ()
		{
				playerCarControl.switchOnMagnetPower -= onMagenetPower;
				playerCarControl.switchOFFMagnetPower -= offMagenetPower;
				playerCarControl.gameEnded -= onGameEnd;
		}

		void onGameEnd (System.Object obj, EventArgs args)
		{
				Destroy (gameObject);
		}

		void onMagenetPower (System.Object obj, EventArgs args)
		{
				isONMagetPower = true;
		
				if(box != null) box.size = new Vector3 (9, 9, 9);
		}

		public void resetSize ()
		{
			if(box !=null)	box.size = originalScale;
		}

		void offMagenetPower (System.Object obj, EventArgs args)
		{
				isONMagetPower = false;
				resetSize ();
		}

		void Start ()
		{

				coinTrans = transform;
			//	coinTrans.Rotate (0, 0, turnCount);
				turnCount += 4;
		}
	
		// Update is called once per frame
	bool isAwaredNitrous = false;
	bool reduceTozero=false;
	public Vector3 coinTarget ;
		void Update ()
		{
		if (moveToPlayer) {
			thisTrans.position = Vector3.MoveTowards (thisTrans.position, playerCarControl.thisPosition  , 2.0f*playerCarControl.isDoubleSpeed);
			if(thisTrans.position.z < playerCarControl.thisPosition.z ) {
				moveToPlayer=false;
//				if(NitrousIndicator.Static.NitrousBar.fillAmount < 1)  NitrousIndicator.Static.NitrousBar.fillAmount+=0.01f;
//				NitrousIndicator.Static.UpdateNitrousDisplay();

				SoundController.Static.playCoinHit();
				moveToCoinTarget = true;
				Destroy(gameObject,2);
				 
			}
		}
		else if ( moveToCoinTarget ) {

			//Vector3 coinRelativetoPlayer = new Vector3(-10,20,playerCarControl.thisPosition.z+40);
			thisTrans.position = Vector3.MoveTowards (thisTrans.position, coinTarget,  playerCarControl.isDoubleSpeed*700.0f * Time.deltaTime);
			 

			}
		}
				//coinTrans.Rotate (0, 0, coinSpeed * Time.timeScale);

	
		
}
