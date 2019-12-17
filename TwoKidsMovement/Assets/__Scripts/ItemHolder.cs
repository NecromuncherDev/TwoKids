using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ItemHolder : MonoBehaviour
{
    public string input;
    private Transform currentItem;

    private void Update()
    {
        if (CrossPlatformInputManager.GetAxis(input) > 0 && currentItem != null)
        {
            if (currentItem.parent == transform)
            {
                currentItem.GetComponent<Rigidbody>().isKinematic = false;
                currentItem.GetComponent<Collider>().isTrigger = false;
                currentItem.SetParent(null);
            }
            else
            {
                currentItem.GetComponent<Rigidbody>().isKinematic = true;
                currentItem.GetComponent<Collider>().isTrigger = true;
                currentItem.transform.SetParent(transform);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (currentItem == null && other.TryGetComponent(out Pickup pickup))
        {
            currentItem = pickup.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == currentItem)
        {
            currentItem = null;
        }
    }
}
