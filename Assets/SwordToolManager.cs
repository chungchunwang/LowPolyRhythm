using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;
using System;

[RequireComponent(typeof(AudioSource))]
public class SwordToolManager : ToolManager

{
    [SerializeField] int initialSwordHealth = 50;
    int currentSwordHealth;
    TMP_Text swordHealthIndicator;

    [SerializeField]float maxVelocityMagnitudeToTriggerSwooshSound = 10;
    [SerializeField]float swooshSoundMinimumInterval = .5f;

    Rigidbody rb;
    AudioSource audioSource;
    [SerializeField]AudioClip swooshAudio;
    [SerializeField]AudioClip nearDeathAudio;
    [SerializeField]AudioClip purchaseAudio;
    XRGrabInteractable xrGrabInteractable;
    

    void setSwordHealth(int health){
        currentSwordHealth = health;
        swordHealthIndicator.text = currentSwordHealth.ToString();
        if(currentSwordHealth <= 0) Destroy(gameObject);
    }
    void incrementSwordHealthBy(int amount){
        currentSwordHealth+=amount;
        swordHealthIndicator.text = currentSwordHealth.ToString();
    }
    void decrementSwordHealth(){
        currentSwordHealth--;
        swordHealthIndicator.text = currentSwordHealth.ToString();
        if(currentSwordHealth <= 5){
            nearDeath(currentController);
        }
        if(currentSwordHealth <= 0){
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        xrGrabInteractable = GetComponent<XRGrabInteractable>();
        xrGrabInteractable.activated.AddListener(onActivated);
        swordHealthIndicator = GetComponentInChildren<TMP_Text>();
        setSwordHealth(initialSwordHealth);
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        StartCoroutine(checkForSwooshSpeed());
    }

    private void onActivated(ActivateEventArgs arg0)
    {
        StartCoroutine(reloadCoroutine(currentController));
        incrementSwordHealthBy(initialSwordHealth);
        callOnPurchase();
    }
    IEnumerator reloadCoroutine(XRBaseController controller){
        audioSource.PlayOneShot(purchaseAudio);
        controller.SendHapticImpulse(1,1);
        yield return new WaitForSeconds(0.1f);
        controller.SendHapticImpulse(1,1);
        yield return new WaitForSeconds(0.1f);
        controller.SendHapticImpulse(1,1);
    }
    void nearDeath(XRBaseController controller){
        controller.SendHapticImpulse(1,1);
        audioSource.PlayOneShot(nearDeathAudio);
    }


    IEnumerator checkForSwooshSpeed(){
        while(true){
            yield return new WaitUntil(()=>rb.velocity.magnitude >= maxVelocityMagnitudeToTriggerSwooshSound);
            audioSource.PlayOneShot(swooshAudio);
            yield return new WaitForSeconds(swooshSoundMinimumInterval);
        }
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.layer == LayerMask.NameToLayer("Collidables")){
            decrementSwordHealth();
            if(currentController != null) currentController.SendHapticImpulse(.5f,1);
        } 
    }

}
