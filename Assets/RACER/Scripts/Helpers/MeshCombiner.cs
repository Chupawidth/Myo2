using UnityEngine;
using System.Collections;

public class MeshCombiner : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
		StaticBatchingUtility.Combine (gameObject);
	}
	
	 
}
