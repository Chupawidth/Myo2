using UnityEngine;
using System.Collections;
using System;
public class RoadGenerator : MonoBehaviour
{

	// Use this for initialization
 
	bool justOnce = false;
	static  int roadBlockCount = 1;
	public float distance = 2825.2f;
	public GameObject otherRoadBlock;
//	public static GameObject OtherStaticBlock;
	void OnEnable ()
	{
		playerCarControl.gameEnded += cancelSwitch;
	}
	void OnDisable ()
	{
		playerCarControl.gameEnded -= cancelSwitch;
	}
	void cancelSwitch (System.Object obj, EventArgs args)
	{
		CancelInvoke ("SwitchRoadBlocks");
	}
	              

 
	void OnTriggerEnter (Collider inc)
	{
		 
		if (inc.tag.Contains ("Player") && justOnce == false) {
			GameObject newBlock = otherRoadBlock;//GameObject.Instantiate(this.gameObject) as GameObject;
			newBlock.name = "road" + roadBlockCount;
			roadBlockCount++;
			//229
			otherRoadBlock.transform.Translate (0, 0, distance * 2); //road tile width
			justOnce = true;
			//Destroy(this.gameObject,20);
			Invoke ("SwitchRoadBlocks", 4);
		}

	}

	void SwitchRoadBlocks ()
	{
		justOnce = false;
	}
}
