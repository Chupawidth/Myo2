using UnityEngine;
using System.Collections;
using System;
public class carCamera : MonoBehaviour
{

	// Use this for initialization

	public Transform targetTrans, thisTransform ;
	public Vector3 offset;
	Vector3 targetOffset;
	 
	// Update is called once per frame
	bool justOnce = false;
	float speed = 0.2f;

	void Start ()
	{
		speed = 0.2f;
		 
		targetOffset = offset;
		offset = new Vector3 (targetOffset.x, targetOffset.y, 0);

	}
	void LateUpdate ()
	{
		if (!GamePlayController.isGameEnded && targetTrans != null) {

			offset = Vector3.MoveTowards (offset, targetOffset, Time.deltaTime * 20);
			thisTransform.position = new Vector3 (offset.x + ((targetTrans.position.x * -1) / 16), offset.y, targetTrans.position.z + offset.z);
		} else {
		 
			thisTransform.Translate (Vector3.forward * speed * 4, Space.World);
			if (!justOnce) {
				justOnce = true;
				Invoke ("disableScript", 8f);
			}
		}
	
	}

	void disableScript ()
	{
		speed = 0;

	}
}
