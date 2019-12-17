using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class FloorPickup : MonoBehaviour
{
    [SerializeField]
    float radius, forceToAdd, curCD = 0, maxCD = 3;

    Collider[] closePickups;

    private void Update()
    {
        if (curCD < maxCD)
        {
            curCD += Time.deltaTime;
        }
        else if (CrossPlatformInputManager.GetAxis("Joy2L1") > 0 &&
                 CrossPlatformInputManager.GetAxis("Joy2R1") > 0)
        {
            curCD = 0;
            closePickups = Physics.OverlapSphere(transform.position, radius);
            Debug.Log(closePickups.Length);
            foreach (Collider col in closePickups)
            {
                if (col.gameObject.GetComponent<Pickup>() != null)
                {
                    col.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * forceToAdd, ForceMode.Force);
                }
            }
        }
    }
}
