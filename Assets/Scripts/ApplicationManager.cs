using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;

public class ApplicationManager : SingletonBehaviour<ApplicationManager>
{

    #region PublicParameter

    public class PainterImageData
    {
        public PainterImageData(Texture2D newTexture, int textureIndex)
        {
            texture = newTexture;
            imageIndex = textureIndex;
        }
        public Texture2D texture;
        public int imageIndex;
    }

    public List<string[]> tempData = new List<string[]>();
    public List<PainterImageData> painterImageDataList;
    #endregion

    #region PrivateParameter
    private string[] rowDataTemp = new string[2];
    private bool objCreate = false;
    private int index = 0;

    #endregion

    #region LifeCycle
    private void OnEnable()
    {
        EventManager.OnStatusChange += EventManager_OnStatusChange;
    }

    private void OnDisable()
    {
        EventManager.OnStatusChange -= EventManager_OnStatusChange;
    }
    // Use this for initialization
    void Start()
    {
        if (!objCreate)
        {
            objCreate = true;
            _instance = this;
            DontDestroyOnLoad(instance);
            Init();
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    private void Init()
    {
        if (painterImageDataList == null)
        {
            painterImageDataList = new List<PainterImageData>();
        }
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.DeleteAll();
        }
#endif
    }

    #endregion

    #region PublicMethod

    public void Reset()
    {
        painterImageDataList.RemoveRange(0, painterImageDataList.Count);
    }

    public void CreateModel(int modelIndex, Texture2D texture2d)
    {
        PainterImageData painterImageData = new PainterImageData(texture2d, modelIndex);
        painterImageDataList.Add(painterImageData);
        EventManager.instance.ChangeStatus("On" + "CreateModel" + (painterImageDataList.Count - 1));
    }


    public void ClearTempData()
    {
        tempData.RemoveRange(0, tempData.Count);
    }



    #endregion

    #region PrivateMethod
    void EventManager_OnStatusChange(string message)
    { 
        switch(message){
            case "OnStartButtonClick":
                SceneManager.LoadScene(1);
                break;
        }
    }
    #endregion

}
