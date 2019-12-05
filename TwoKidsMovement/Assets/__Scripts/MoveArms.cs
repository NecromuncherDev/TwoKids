using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArms : MonoBehaviour
{
    [SerializeField]
    Rigidbody lShoulder, lArm, rShoulder, rArm;
    

    [SerializeField]
    float moveSpeed, maxRot = 50, minRot =-50;

    private void Start()
    {
        if (lShoulder == null ||
            lArm == null ||
            rShoulder == null ||
            rArm == null)
        {
            Debug.LogError("Unassignd shoulder or arm");
            throw new System.Exception("Unassignd shoulder or arm");
        }
    }

    // Update is called once per frame
    void Update()
    {
        #region Right arm
        if (Input.GetKey(KeyCode.I))
        {
            rShoulder.transform.RotateAroundLocal(Vector3.forward, moveSpeed * Time.deltaTime);
            if (rShoulder.transform.localRotation.z > Mathf.Deg2Rad * maxRot)
            {
                Debug.Log("rShoulder has turned beyond " + maxRot + " degrees!");
                rShoulder.transform.RotateAroundLocal(Vector3.forward, -moveSpeed * Time.deltaTime);
            }
        } 
        if (Input.GetKey(KeyCode.K))
        {
            rShoulder.transform.RotateAroundLocal(Vector3.forward, -moveSpeed * Time.deltaTime);
            if (rShoulder.transform.localRotation.z < Mathf.Deg2Rad * minRot)
            {
                Debug.Log("rShoulder has turned beyond " + minRot + " degrees!");
                rShoulder.transform.RotateAroundLocal(Vector3.forward, moveSpeed * Time.deltaTime);
            }
        }
        if (Input.GetKey(KeyCode.L))
        {
            rArm.transform.RotateAroundLocal(Vector3.up, moveSpeed * Time.deltaTime);
            if (rArm.transform.localRotation.y > Mathf.Deg2Rad * maxRot)
            {
                Debug.Log("rArm has turned beyond " + maxRot + " degrees!");
                rArm.transform.RotateAroundLocal(Vector3.up, -moveSpeed * Time.deltaTime);
            }
        }
        if (Input.GetKey(KeyCode.J))
        {
            rArm.transform.RotateAroundLocal(Vector3.up, -moveSpeed * Time.deltaTime);
            if (rArm.transform.localRotation.y < Mathf.Deg2Rad * minRot)
            {
                Debug.Log("rArm has turned beyond " + minRot + " degrees!");
                rArm.transform.RotateAroundLocal(Vector3.up, moveSpeed * Time.deltaTime);
            }
        }
        #endregion

        #region Left arm
        if (Input.GetKey(KeyCode.T))
        {
            lShoulder.transform.RotateAroundLocal(Vector3.forward, -moveSpeed * Time.deltaTime);
            if (lShoulder.transform.localRotation.z < Mathf.Deg2Rad * minRot)
            {
                Debug.Log("lShoulder has turned beyond " + maxRot + " degrees!");
                lShoulder.transform.RotateAroundLocal(Vector3.forward, moveSpeed * Time.deltaTime);
            }
        }
        if (Input.GetKey(KeyCode.G))
        {
            lShoulder.transform.RotateAroundLocal(Vector3.forward, moveSpeed * Time.deltaTime);
            if (lShoulder.transform.localRotation.z > Mathf.Deg2Rad * maxRot)
            {
                Debug.Log("lShoulder has turned beyond " + minRot + " degrees!");
                lShoulder.transform.RotateAroundLocal(Vector3.forward, -moveSpeed * Time.deltaTime);
            }
        }
        if (Input.GetKey(KeyCode.F))
        {
            lArm.transform.RotateAroundLocal(Vector3.up, -moveSpeed * Time.deltaTime);
            if (lArm.transform.localRotation.y < Mathf.Deg2Rad * minRot)
            {
                Debug.Log("lArm has turned beyond " + maxRot + " degrees!");
                lArm.transform.RotateAroundLocal(Vector3.up, moveSpeed * Time.deltaTime);
            }
        }
        if (Input.GetKey(KeyCode.H))
        {
            lArm.transform.RotateAroundLocal(Vector3.up, moveSpeed * Time.deltaTime);
            if (lArm.transform.localRotation.y > Mathf.Deg2Rad * maxRot)
            {
                Debug.Log("lArm has turned beyond " + minRot + " degrees!");
                lArm.transform.RotateAroundLocal(Vector3.up, -moveSpeed * Time.deltaTime);
            }
        }
        #endregion
    }
}
