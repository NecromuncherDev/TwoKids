using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    public float Springiness = 3.0f;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        if (Target == null)
        {
            Debug.Log("no target set for camera follow script!");
            return;
        }

        offset = transform.position - Target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = Target.transform.position + offset;

        transform.position = Vector3.Lerp(transform.position, newPos, Springiness * Time.deltaTime);
    }
}
