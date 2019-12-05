using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakKidsNew : MonoBehaviour
{
    [SerializeField]
    private Transform realRootParent;

    void OnJointBreak(float breakForce)
    {
        Debug.Log("A joint has just been broken!, force: " + breakForce);
        realRootParent.SetParent(null);
    }
}
