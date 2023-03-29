using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;

public class CollidableSpawner : MonoBehaviour
{
    [HideInInspector] public GameObject collidableParent;
    [SerializeField] Transform spawnTransform;
    [SerializeField] Transform anchorTransform;
    Vector3 movementVelocity;
    [HideInInspector] public float timeToAnchor;
    void Start(){
        movementVelocity = (anchorTransform.transform.position - spawnTransform.position)/timeToAnchor;
    }

    public void spawn(GameObject collidablePrefab){
        GameObject rock =  Instantiate(collidablePrefab,spawnTransform.position, spawnTransform.rotation);
        rock.transform.SetParent(collidableParent.transform);
        rock.GetComponent<Rigidbody>().velocity = movementVelocity;
    }
}
