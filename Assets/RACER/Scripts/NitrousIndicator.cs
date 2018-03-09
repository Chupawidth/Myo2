using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
public class NitrousIndicator : MonoBehaviour
{

		// Use this for initialization

		//public Material progress;
		public Text   countDown, tittleText;
		public static NitrousIndicator Static;
		//public Color startColor, endColor;
		//public GameObject scaler;
		public static float  NitrousCount ;
		public float nitrousDecrementSpeed ;
		public   bool isNitrousOn = false ;
		//public Transform barScaler ;
	    public  Image NitrousBar;
		void OnEnable ()
		{
		       
		NitrousBar.fillAmount = 0;
				Static = this;
				UpdateNitrousDisplay ();
				
	 
		}

		void OnDisable ()
		{
	 

		}

		void destroyTimer (System.Object obj, EventArgs args)
		{
				Destroy (gameObject);
		}
 
	
		// Update is called once per frame
 
		public void UpdateNitrousDisplay ()
		{
		float power = 1 - (float)(((float)1.0f + (float)NitrousBar.fillAmount) / (float)100.0f);
				power = Mathf.Clamp (power, 0.01f, 0.99f);
		     
					 
		if (NitrousBar.fillAmount <= 0) {
			        isNitrousOn = false;
					playerCarControl.isDoubleSpeed = 1;
				}

		}
 
		public void Update ()
		{

		       if (isNitrousOn) {
					playerCarControl.isDoubleSpeed = 1.5f;
			NitrousBar.fillAmount -= nitrousDecrementSpeed * Time.deltaTime;
			NitrousBar.fillAmount = Mathf.Clamp (NitrousBar.fillAmount, 0, 100); //to avoid minus 
						UpdateNitrousDisplay ();
				}
		}

		void ChangeTextValue (float countNumber)
		{
				countDown.text = "" + Mathf.RoundToInt (countNumber);
		}

		void timerDone ()
		{
				//iTween.RotateTo (scaler, new Vector3 (0, 0, 180), 0.3f);
				iTween.MoveTo (gameObject, iTween.Hash ("position", new Vector3 (-20, 0, 0), "time", 1.0f, "easetype", iTween.EaseType.easeInOutBack, "delay", 0.0f));
		}
}
