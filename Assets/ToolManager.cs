using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;
using System;

[RequireComponent(typeof(XRGrabInteractable))]
public class ToolManager : MonoBehaviour
{
    [Header("Tool Identification")]
    [Tooltip("This needs to be unique.")]
    [SerializeField] string toolName;

    [Header("Tool Point Price")]
    [SerializeField] public int pointPrice = 100;
    Rigidbody rb;
    int ghostLayer;

    int toolLayer;

    bool startedUseThisSelectCycle = false;

    XRGrabInteractable xrGrabInteractable;

    public delegate void destroyAction();
    public event destroyAction onDestroy;

    public delegate void useExitAction(GameObject gameObject);
    public event useExitAction onExitUse;

    public delegate void useStartAction(GameObject gameObject);
    public event useStartAction onStartUse;
    public delegate void purchaseAction(GameObject gameObject);
    public event purchaseAction onPurchase;
    protected XRBaseController currentController;

    //opening up events to derived classes
    protected void callOnPurchase(){onPurchase(gameObject);}

    static Dictionary<string, ToolManager> activated = new Dictionary<string, ToolManager>();
    
    protected void Start()
    {
        ghostLayer = LayerMask.NameToLayer("Ghost");
        toolLayer = LayerMask.NameToLayer("Tools");
        xrGrabInteractable = GetComponent<XRGrabInteractable>();
        xrGrabInteractable.selectEntered.AddListener(onSelect);
        xrGrabInteractable.selectExited.AddListener(onDeselect);
        xrGrabInteractable.enabled = false;
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        changeLayer(gameObject, ghostLayer);
    }



    private void Update() {
        if(activated.ContainsKey(toolName) && activated[toolName] != this){
            xrGrabInteractable.enabled = false;
            return;
        }
        else{
            xrGrabInteractable.enabled = true;
        }
    }
    public void onSelect(SelectEnterEventArgs args){
        if(!activated.ContainsKey(toolName)) {
            activated.Add(toolName,this);
            if(onStartUse != null) onStartUse(gameObject);
            startedUseThisSelectCycle = true;
        }
        rb.isKinematic = false;
        changeLayer(gameObject, toolLayer);
        currentController = args.interactorObject.transform.gameObject.GetComponent<XRBaseController>();
    }
    public void onDeselect(SelectExitEventArgs args){
        if(startedUseThisSelectCycle && onExitUse != null) onExitUse(gameObject);
        startedUseThisSelectCycle = false;
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        changeLayer(gameObject, ghostLayer);
        currentController = null;
    }

    public void changeLayer(GameObject obj, int layer){
        obj.layer = layer;
        for(int i = 0; i < obj.transform.childCount; i++){
            changeLayer(obj.transform.GetChild(i).gameObject, layer);
        }
    }
    private void OnDestroy() {
        if(activated.ContainsKey(toolName) && activated[toolName] == this) activated.Remove(toolName);
        if(onDestroy != null) onDestroy();
    }
}
