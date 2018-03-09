using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialGenerater : MonoBehaviour
{

    #region PublicParameter
    public enum ModelLayer{
        Model1,Model2,Model3
    }

    public Material[] materialTemplates;
    public GameObject[] modelTemplates;
    public Texture scntxt;
    public GameObject spawnPosition;
    public ModelLayer modelLayer;
    #endregion

    #region PrivateParameter
    [SerializeField]
    private Material newMaterial;
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

    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {

    }
    #endregion

    #region PublicMethod
    void EventManager_OnStatusChange(string message)
    {
        ApplicationManager.PainterImageData painterImageData = ApplicationManager.instance.painterImageDataList[0];
        switch (message)
        {
            case "OnCreateModel0":
                if(modelLayer==ModelLayer.Model1){
                    CreateNewMaterial(ApplicationManager.instance.painterImageDataList[0].imageIndex, ApplicationManager.instance.painterImageDataList[0].texture);
                }
                break;
            case "OnCreateModel1":
                if (modelLayer == ModelLayer.Model2)
                {
                    CreateNewMaterial(ApplicationManager.instance.painterImageDataList[1].imageIndex, ApplicationManager.instance.painterImageDataList[1].texture);
                }
                break;
            case "OnCreateModel2":
                if (modelLayer == ModelLayer.Model3)
                {
                    CreateNewMaterial(ApplicationManager.instance.painterImageDataList[2].imageIndex, ApplicationManager.instance.painterImageDataList[2].texture);
                }
                break;
        }
    }

    public void CreateNewMaterial(int index,Texture scanTexture)
    {

        ActiveModelList(true);
        newMaterial = new Material(materialTemplates[index]);
        newMaterial.name = "ship1";
        newMaterial.mainTexture = scanTexture;
        newMaterial.SetTexture("_DetailAlbedoMap", scanTexture);

        ////////////

        GameObject newModel = Instantiate(modelTemplates[index], spawnPosition.transform);
        int layer = 0;
        switch(modelLayer){
            case ModelLayer.Model1 :
                layer = PlayerPrefsManager.layerModel1;
                break;
            case ModelLayer.Model2 :
                layer = PlayerPrefsManager.layerModel2;
                break;
            case ModelLayer.Model3 :
                layer = PlayerPrefsManager.layerModel3;
                break;
        }
        ChangeModelLayer(newModel,layer);
        newModel.gameObject.transform.localPosition = Vector3.zero;
        //newModel.gameObject.transform.rotation.eulerAngles = Vector3.zero;

        MeshRenderer[] modelMeshRenderers = newModel.GetComponentsInChildren<MeshRenderer>();
        foreach (var mesh in modelMeshRenderers)
        {
            if (mesh.name != "B_Body Material 3")
                mesh.material = newMaterial;

        }

        ActiveModelList(false);
    }

    #endregion

    #region PrivateMethod

    private GameObject ChangeModelLayer(GameObject model,int layerIndex){

        foreach(var subModel in model.GetComponentsInChildren<Transform>()){
            subModel.gameObject.layer = layerIndex;
        }

        return model;

    }

    private void ActiveModelList(bool active)
    {
        foreach (var model in modelTemplates)
        {
            model.SetActive(active);
        }
    }
    #endregion

}
