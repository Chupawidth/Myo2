using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour
{

	#region PlayerPref

	public static int levelToload {
		get {
			return PlayerPrefs.GetInt ("levelToload", SceneManager.sceneCountInBuildSettings - 1);
		}
		set {
			PlayerPrefs.SetInt ("levelToload", value);
		}
	}

	public static string AssetBundleServerURL {
		get { 
			return PlayerPrefs.GetString ("AssetBundleServerURL", "http://192.168.62.120/bossup/AssetBundles/"); 
		}
		set { 
			PlayerPrefs.SetString ("AssetBundleServerURL", value); 
		}
	}

    public static int layerModel1
    {
        get
        {
            return PlayerPrefs.GetInt("layerModel1", 10);
        }
        set
        {
            PlayerPrefs.SetInt("layerModel1", value);
        }
    }

    public static int layerModel2
    {
        get
        {
            return PlayerPrefs.GetInt("layerModel2", 11);
        }
        set
        {
            PlayerPrefs.SetInt("layerModel2", value);
        }
    }

    public static int layerModel3
    {
        get
        {
            return PlayerPrefs.GetInt("layerModel3", 12);
        }
        set
        {
            PlayerPrefs.SetInt("layerModel3", value);
        }
    }


	#endregion


}
