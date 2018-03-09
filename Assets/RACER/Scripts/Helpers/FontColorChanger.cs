using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class FontColorChanger : MonoBehaviour
{

	public Color[] colors;
	Text text;
	public bool canFadeOut = true ;
	void Start ()
	{
		text = GetComponent<Text> ();

		text.color = colors [Random.Range (0, colors.Length - 1)];

		if (canFadeOut)
			text.CrossFadeAlpha (0, 1.0f, false);
	}
	
	 
}
