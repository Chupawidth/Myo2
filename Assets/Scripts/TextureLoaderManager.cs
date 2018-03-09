using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextureLoaderManager : MonoBehaviour
{
    #region PublicParameter
    public Sprite waitingBGImage;
    public Sprite loadedBGImage;
    public Image[] bgImages;
    public GameObject[] spawnPositions;

    #endregion

    #region PrivateParameter
    GameObject[] loadedModel;
    #endregion

    #region LifeCycle
    // Use this for initialization

    private void OnEnable()
    {
        EventManager.OnStatusChange += EventManager_OnStatusChange;
    }

    private void OnDisable()
    {
        EventManager.OnStatusChange -= EventManager_OnStatusChange;
    }

    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {

    }
    #endregion

    #region PublicMethod
    public void Init(){
        foreach(var bgImage in bgImages){
            bgImage.sprite = waitingBGImage;
        }
    }

    void EventManager_OnStatusChange(string message)
    {
        switch (message)
        {
            case "OnCreateModel0":
                bgImages[0].sprite = loadedBGImage;
                break;
            case "OnCreateModel1":
                bgImages[0].sprite = loadedBGImage;
                break;
            case "OnCreateModel2":
                bgImages[0].sprite = loadedBGImage;
                break;
        }
    }

    #endregion
}
