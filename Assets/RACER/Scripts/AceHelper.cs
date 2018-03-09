using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class AceHelper  {

 
	public static void randomizeList( List<GameObject> AllObjects)
	{
		for (int i = 0; i < AllObjects.Count; i++) {
			GameObject temp = AllObjects[i];
			int randomIndex = Random.Range(i, AllObjects.Count);
			AllObjects[i] = AllObjects[randomIndex];
			AllObjects[randomIndex] = temp;
		}
	}
	public static void randomizeArray( GameObject[] AllObjects)
	{
		for (int i = 0; i < AllObjects.Length; i++) {
			GameObject temp = AllObjects[i];
			int randomIndex = Random.Range(i, AllObjects.Length);
			AllObjects[i] = AllObjects[randomIndex];
			AllObjects[randomIndex] = temp;
		}
	}
	 
	public static Vector3 GetRandomPointInBoxCollider(BoxCollider box) 
	{ 
		Vector3 bLocalScale = box.transform.localScale; 
		Vector3 boxPosition = box.transform.position; 
		boxPosition += new Vector3 (bLocalScale.x * box.center.x, bLocalScale.y * box.center.y, bLocalScale.z * box.center.z); 
		
		Vector3 dimensions = new Vector3(bLocalScale.x * box.size.x, 
		                                 bLocalScale.y * box.size.y, 
		                                 bLocalScale.z * box.size.z); 
		
		Vector3 newPos = new Vector3 (UnityEngine.Random.Range (boxPosition.x - (dimensions.x / 2), boxPosition.x + (dimensions.x / 2)), 
		                              UnityEngine.Random.Range (boxPosition.y - (dimensions.y / 2), boxPosition.y + (dimensions.y / 2)), 
		                              UnityEngine.Random.Range (boxPosition.z - (dimensions.z / 2), boxPosition.z + (dimensions.z / 2))); 
		return newPos; 
	}
}
