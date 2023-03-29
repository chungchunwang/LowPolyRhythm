using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

[RequireComponent(typeof(XRGrabInteractable))]
[RequireComponent(typeof(AudioSource))]
public class GunToolManager : ToolManager
{
    
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletForce = 5f;
    [SerializeField] float bulletOffset = .5f;
    [SerializeField] AudioClip gunShotSound;
    [SerializeField] int initialBulletCount = 20;

    int currentBulletCount;
    AudioSource audioSource;

    TMP_Text bulletCountIndicator;

    private void setBulletCount(int count){
        currentBulletCount = count;
        bulletCountIndicator.text = currentBulletCount.ToString();
        if(currentBulletCount <= 0) destroySelf();
    }
    private void decrementBulletCount(){
        currentBulletCount--;
        bulletCountIndicator.text = currentBulletCount.ToString();
        if(currentBulletCount <= 0) destroySelf();
    }

    new protected void Start() {
        base.Start();
        XRGrabInteractable xrGrabInteractable = GetComponent<XRGrabInteractable>();
        xrGrabInteractable.activated.AddListener(onActivate);

        audioSource = GetComponent<AudioSource>();
        audioSource.spatialBlend = 1;
        audioSource.clip = gunShotSound;
        audioSource.playOnAwake = false;

        bulletCountIndicator = GetComponentInChildren<TMP_Text>();

        setBulletCount(initialBulletCount);
    }
    public void onActivate(ActivateEventArgs args){
        GameObject bullet = Instantiate(bulletPrefab,this.transform.position + this.transform.forward*bulletOffset,this.transform.rotation);
        bullet.AddComponent<Rigidbody>();
        Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
        bulletRB.useGravity = false;
        bulletRB.AddForce(this.transform.forward * bulletForce);
        audioSource.Play();

        decrementBulletCount();
        
    }
    void destroySelf(){
        Destroy(gameObject);
    }
}
