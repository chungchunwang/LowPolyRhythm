using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCollisionManager : MonoBehaviour
{
    int noCollisionZoneLayer;
    int handsLayer;
    int toolsLayer;
    int worldBorderLayer;
    int collidablesLayer;
    [SerializeField] ParticleSystem explosionParticleSystem;
    [SerializeField] ParticleSystem disappearParticleSystem;
    [SerializeField] ParticleSystem noCollisionZoneParticleSystem;
    [SerializeField] GameObject healthCanvas;
    [SerializeField] int initialHealth = 2;
    [SerializeField] int points = 5;
    PointSystem pointSystem;
    int currentHealth;

    HealthCanvasManager healthCanvasManager;

    void setHealth(int health){
        currentHealth = health;
        healthCanvasManager.setHealth(currentHealth);
    }
    void decrementHealth(int decrementAmount){
        currentHealth -= decrementAmount;
        healthCanvasManager.setHealth(currentHealth);
    }
    // Start is called before the first frame update
    void Start()
    {
        noCollisionZoneLayer = LayerMask.NameToLayer("No Collision Zone");
        handsLayer = LayerMask.NameToLayer("Hands");
        toolsLayer = LayerMask.NameToLayer("Tools");
        worldBorderLayer = LayerMask.NameToLayer("World Boundary");
        collidablesLayer = LayerMask.NameToLayer("Collidables");

        GameObject canvas = Instantiate(healthCanvas, transform.position, transform.rotation);
        canvas.transform.SetParent(this.transform);
        healthCanvasManager = canvas.GetComponent<HealthCanvasManager>();
        setHealth(initialHealth);

        pointSystem = GameObject.FindGameObjectWithTag("Point System").GetComponent<PointSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.layer == handsLayer || other.gameObject.layer == toolsLayer){
            decrementHealth(other.gameObject.GetComponent<DamageManager>().damage);
            if(currentHealth <= 0) {
                pointSystem.addPoints(points);
                ExplosionDestroySelf();
            }
            return;
        }
        if(other.gameObject.layer == collidablesLayer){
            //ExplosionDestroySelf();
            return;
        }
        if(other.gameObject.layer == worldBorderLayer){
            DisappearDestroySelf();
            return;
        }
        if(other.gameObject.layer == noCollisionZoneLayer){
            pointSystem.removePoints(200);
            NoCollisionZoneDestroySelf();
            return;
        }
        
    }

    private void NoCollisionZoneDestroySelf()
    {
        Instantiate(noCollisionZoneParticleSystem, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    void ExplosionDestroySelf(){
        Instantiate(explosionParticleSystem, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    void DisappearDestroySelf(){
        Instantiate(disappearParticleSystem, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
