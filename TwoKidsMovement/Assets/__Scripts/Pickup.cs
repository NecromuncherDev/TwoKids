using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Pickup : MonoBehaviour
{
    private void Awake()
    {
        //GetComponent<Rigidbody>().isKinematic = true;
    }
}
