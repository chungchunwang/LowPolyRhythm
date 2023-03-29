using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowController : MonoBehaviour
{
    [SerializeField] private GameObject followObject;
    [SerializeField] private int velocityMultiplier = 1;
    private Transform followTarget;
    private Rigidbody rigidBody;
    

    // Start is called before the first frame update
    void Start()
    {
        followTarget = followObject.transform;
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.position = followTarget.position;
        rigidBody.rotation = followTarget.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        var diff = followTarget.position - rigidBody.position;
        rigidBody.position = followTarget.position;
        rigidBody.rotation = followTarget.rotation;
        rigidBody.velocity = diff * velocityMultiplier * Time.deltaTime;
    }
}
