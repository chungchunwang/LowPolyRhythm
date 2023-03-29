using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    void Update()
    {
        transform.forward = -Camera.main.transform.forward;
        transform.rotation = Camera.main.transform.rotation;
    }
}
