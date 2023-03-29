using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCollisionManager : MonoBehaviour
{
    [SerializeField] ParticleSystem collectionParticleSystem;
    [SerializeField] ParticleSystem disappearParticleSystem;
    [SerializeField] ParticleSystem noCollisionZoneParticleSystem;
    [SerializeField] ParticleSystem explosionParticleSystem;
    [SerializeField] int points = 500;
    PointSystem pointSystem;
    int noCollisionZoneLayer;
    int handsLayer;
    int toolsLayer;
    int worldBorderLayer;
    int collidablesLayer;

    void Start()
    {
        noCollisionZoneLayer = LayerMask.NameToLayer("No Collision Zone");
        handsLayer = LayerMask.NameToLayer("Hands");
        toolsLayer = LayerMask.NameToLayer("Tools");
        worldBorderLayer = LayerMask.NameToLayer("World Boundary");
        collidablesLayer = LayerMask.NameToLayer("Collidables");
        pointSystem = GameObject.FindGameObjectWithTag("Point System").GetComponent<PointSystem>();
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.layer == handsLayer){
            CollectDestroySelf();
            pointSystem.addPoints(points);
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
            NoCollisionZoneDestroySelf();
            return;
        }
        
    }
    
    private void NoCollisionZoneDestroySelf()
    {
        Instantiate(noCollisionZoneParticleSystem, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    void CollectDestroySelf(){
        Instantiate(collectionParticleSystem, transform.position, transform.rotation);
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
