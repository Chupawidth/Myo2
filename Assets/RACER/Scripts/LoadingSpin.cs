using UnityEngine;
using System.Collections;

public class LoadingSpin : MonoBehaviour
{

	// Use this for initialization
	public Transform loading;
	public Vector3 rotationDirection;

	IEnumerator Start ()
	{
	
		yield return new WaitForSeconds (1);
		//Application.LoadLevelAsync(levelSelection.levelName);

		UnityEngine.SceneManagement.SceneManager.LoadSceneAsync (levelSelection.levelName);


		#if UNITY_WEBGL

		controlSelection.selectedMode = controls.buttons;
		#endif
	}
	
	// Update is called once per frame
	void Update ()
	{
	   
		loading.Rotate (rotationDirection * Time.deltaTime);
	}
}
