using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    [SerializeField] float timeToAnchor = 2f;
    [SerializeField] CollidableSpawner sideLeftSpawner;
    [SerializeField] CollidableSpawner sideRightSpawner;
    [SerializeField] CollidableSpawner centerTopLeftSpawner;
    [SerializeField] CollidableSpawner centerTopRightSpawner;
    [SerializeField] CollidableSpawner centerBottomLeftSpawner;
    [SerializeField] CollidableSpawner centerBottomRightSpawner;
    [SerializeField] GameObject[] rockPrefabs;
    [SerializeField] GameObject[] gemPrefabs;
    [SerializeField] GameObject collidableParent;

    // Start is called before the first frame update
    void Start()
    {
        sideLeftSpawner.timeToAnchor = timeToAnchor;
        sideRightSpawner.timeToAnchor = timeToAnchor;
        centerTopLeftSpawner.timeToAnchor = timeToAnchor;
        centerTopRightSpawner.timeToAnchor = timeToAnchor;
        centerBottomLeftSpawner.timeToAnchor = timeToAnchor;
        centerBottomRightSpawner.timeToAnchor = timeToAnchor;
        sideLeftSpawner.collidableParent = collidableParent;
        sideRightSpawner.collidableParent = collidableParent;
        centerTopLeftSpawner.collidableParent = collidableParent;
        centerTopRightSpawner.collidableParent = collidableParent;
        centerBottomLeftSpawner.collidableParent = collidableParent;
        centerBottomRightSpawner.collidableParent = collidableParent;
    }
    public void rockSideLeftSignal(){
        int index = Random.Range(0,rockPrefabs.Length);
        sideLeftSpawner.spawn(rockPrefabs[index]);
    }
    public void rockSideRightSignal(){
        int index = Random.Range(0,rockPrefabs.Length);
        sideRightSpawner.spawn(rockPrefabs[index]);
    }
    public void rockCenterTopLeftSignal(){
        int index = Random.Range(0,rockPrefabs.Length);
        centerTopLeftSpawner.spawn(rockPrefabs[index]);
    }
    public void rockCenterTopRightSignal(){
        int index = Random.Range(0,rockPrefabs.Length);
        centerTopRightSpawner.spawn(rockPrefabs[index]);
    }
    public void rockCenterBottomLeftSignal(){
        int index = Random.Range(0,rockPrefabs.Length);
        centerBottomLeftSpawner.spawn(rockPrefabs[index]);
    }
    public void rockCenterBottomRightSignal(){
        int index = Random.Range(0,rockPrefabs.Length);
        centerBottomRightSpawner.spawn(rockPrefabs[index]);
    }
    public void gemSideLeftSignal(){
        int index = Random.Range(0,gemPrefabs.Length);
        sideLeftSpawner.spawn(gemPrefabs[index]);
    }
    public void gemSideRightSignal(){
        int index = Random.Range(0,gemPrefabs.Length);
        sideRightSpawner.spawn(gemPrefabs[index]);
    }
    public void gemCenterTopLeftSignal(){
        int index = Random.Range(0,gemPrefabs.Length);
        centerTopLeftSpawner.spawn(gemPrefabs[index]);
    }
    public void gemCenterTopRightSignal(){
        int index = Random.Range(0,gemPrefabs.Length);
        centerTopRightSpawner.spawn(gemPrefabs[index]);
    }
    public void gemCenterBottomLeftSignal(){
        int index = Random.Range(0,gemPrefabs.Length);
        centerBottomLeftSpawner.spawn(gemPrefabs[index]);
    }
    public void gemCenterBottomRightSignal(){
        int index = Random.Range(0,gemPrefabs.Length);
        centerBottomRightSpawner.spawn(gemPrefabs[index]);
    }
}
