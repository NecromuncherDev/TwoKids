using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : MonoBehaviour
{
    public string input;
    private Transform currentItem;

    private void Update()
    {
        if (Input.GetButtonDown(input) && currentItem != null)
        {
            if (currentItem.parent == transform)
            {
                currentItem.GetComponent<Rigidbody>().isKinematic = false;
                currentItem.SetParent(null);
            }
            else
            {
                currentItem.GetComponent<Rigidbody>().isKinematic = true;
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
