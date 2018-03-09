using System;
using UnityEngine;
using System.Collections;
using System.IO;
using System.Linq;
using System.Collections.Generic;

public class GetFilePath : MonoBehaviour {
    

    public static char SubfolderSign = Path.DirectorySeparatorChar;

    
    private float countdownTime = 5f;
	// Use this for initialization
	void Start () {
	    ReCreateModel();
	}
	
	// Update is called once per frame
	void Update () {
	    if (countdownTime<=0f)
	    {
            ReCreateModel();
	        countdownTime = 5f;
	    }
	    else
	    {
	        countdownTime -= Time.deltaTime;
	    }
	}

    void ReCreateModel() 
    {
        
        #if UNITY_EDITOR
        string path = Application.streamingAssetsPath + SubfolderSign + "ImagePath_Editor.txt";
        #else
        string path = Application.streamingAssetsPath + SubfolderSign + "ImagePath.txt";
        #endif
        
        string[] textStrings = System.IO.File.ReadAllLines(path);
        Debug.Log(textStrings[0]);
        DirectoryInfo d = new DirectoryInfo(textStrings[0]); //Assuming Test is your Folder
        FileInfo[] files = d.GetFiles("*.png"); //Getting Text files
        string str = "";
        IOrderedEnumerable<FileInfo> newfileinfos = files.OrderByDescending(f => f.CreationTimeUtc);
        foreach (var newfileinfo in newfileinfos)
        {
            
            int type = (int)Char.GetNumericValue (newfileinfo.Name[0]);

            Texture2D tex = null;
            byte[] fileData;
            if (File.Exists (newfileinfo.DirectoryName + SubfolderSign + newfileinfo.Name))
            {
                string filepath = newfileinfo.DirectoryName + SubfolderSign + newfileinfo.Name;
                DebugLog.Add("Texture : " + filepath);
                fileData = File.ReadAllBytes (filepath);
                tex = new Texture2D (2, 2);
                tex.LoadImage (fileData); //..this will auto-resize the texture dimensions.
            }

            //SystemController.instance.CreateModel (type-1, tex);
            ApplicationManager.instance.CreateModel(type - 1, tex);
            newfileinfo.MoveTo(textStrings[1]+newfileinfo.Name+"_Loaded.png");
        }
    }
}
