using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ToolSystemManager : MonoBehaviour
{
    [Header("The two arrays must match!")]
    [SerializeField]ToolManager[] toolManagers;
    [SerializeField]Transform[] anchors;
    GameObject[] objects;
    
    [SerializeField] Transform toolParent;
    [SerializeField] Transform toolkitToolParent;
    [SerializeField] GameObject toolkit;
    [SerializeField] InputActionReference xButton;

    PointSystem pointSystem;

    bool applicationQuitting = false;
    bool objectDestroyed = false;
    float toolkitForwardMultiplier=.5f;
    // Start is called before the first frame update
    void Start()
    {
        objects = new GameObject[toolManagers.Length];
        for(int i = 0; i < toolManagers.Length; i++){
            createTool(i);
        }
        
        toolkit.SetActive(false);
        pointSystem = GameObject.FindGameObjectWithTag("Point System").GetComponent<PointSystem>();
    }
    void OnEnable(){
        xButton.action.performed += enableButtonPressed;
    }
    void OnDisable(){
        xButton.action.performed -= enableButtonPressed;
    }
    private void enableButtonPressed(InputAction.CallbackContext obj)
    {
        toolkit.SetActive(!toolkit.activeSelf);
        toolkit.transform.position = Camera.main.transform.position + Camera.main.transform.forward*toolkitForwardMultiplier;
        toolkit.transform.LookAt(Camera.main.transform.position, transform.up);
    }

    void createTool(int i){
        if(applicationQuitting) return;
        if(objectDestroyed) return;
        GameObject obj = toolManagers[i].gameObject;
        Vector3 pos = anchors[i].position;
        Quaternion rot = anchors[i].rotation;
        int index = i;
        GameObject newTool = Instantiate<GameObject>(obj, pos, rot);
        newTool.transform.SetParent(toolkitToolParent);
        objects[i] = newTool;
        ToolManager toolManager = newTool.GetComponent<ToolManager>();
        toolManager.onDestroy += delegate{createTool(index);}; 
        toolManager.onStartUse += onStartUse;
        toolManager.onExitUse += onExitUse;
        toolManager.onPurchase += onPurchase;
    }
    private void OnDestroy() {
        objectDestroyed = true;
    }

    private void onStartUse(GameObject obj)
    {
        pointSystem.removePoints(obj.GetComponent<ToolManager>().pointPrice);
    }
    private void onPurchase(GameObject obj)
    {
        pointSystem.removePoints(obj.GetComponent<ToolManager>().pointPrice);
    }
    void onExitUse(GameObject obj){
        obj.transform.SetParent(toolParent);
    }
    private void OnApplicationQuit() {
        applicationQuitting = true;
    }
    
}

