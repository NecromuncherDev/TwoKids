using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class baseMovement : MonoBehaviour
{
    public float fBaseForce = 10.0f;

    public void move(Vector2 value)
    {
        GetComponent<Rigidbody2D>().AddForce(value * fBaseForce);
    }

}
