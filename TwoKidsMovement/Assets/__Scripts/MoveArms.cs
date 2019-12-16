using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MoveArms : MonoBehaviour
{
    [SerializeField]
    Rigidbody lShoulder, lArm, rShoulder, rArm;

    [SerializeField]
    float moveSpeed, maxRot = 50, minRot =-50;

    float rh, rhRot, rv, rvRot, lh, lhRot, lv, lvRot;

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

        minRot *= Mathf.Deg2Rad;
        maxRot *= Mathf.Deg2Rad;
    }

    // Update is called once per frame
    void Update()
    {
        #region Right arm

        rh = CrossPlatformInputManager.GetAxis("Joy2XR");
        rv = CrossPlatformInputManager.GetAxis("Joy2YR");

        Debug.Log(rh + ", " + rv);

        rhRot = rh * Time.deltaTime * moveSpeed;
        rShoulder.transform.SetPositionAndRotation(rShoulder.transform.position,
                                               new Quaternion(rShoulder.transform.rotation.x,
                                                              Mathf.Clamp(rShoulder.transform.rotation.y + rhRot, minRot, maxRot),
                                                              rShoulder.transform.rotation.z,
                                                              rShoulder.transform.rotation.w));

        rvRot = rv * Time.deltaTime * -moveSpeed;
        rArm.transform.SetPositionAndRotation(rArm.transform.position,
                                               new Quaternion(rArm.transform.rotation.x, 
                                                              rArm.transform.rotation.y,
                                                              Mathf.Clamp(rArm.transform.rotation.z + rvRot, minRot,maxRot),
                                                              rArm.transform.rotation.w));

        #endregion

        #region Left arm

        lh = CrossPlatformInputManager.GetAxis("Joy2XL");
        lv = CrossPlatformInputManager.GetAxis("Joy2YL");

        Debug.Log(rh + ", " + rv);

        lhRot = lh * Time.deltaTime * moveSpeed;
        lShoulder.transform.SetPositionAndRotation(lShoulder.transform.position,
                                               new Quaternion(lShoulder.transform.rotation.x,
                                                              Mathf.Clamp(lShoulder.transform.rotation.y + lhRot, minRot, maxRot),
                                                              lShoulder.transform.rotation.z,
                                                              lShoulder.transform.rotation.w));

        lvRot = lv * Time.deltaTime * -moveSpeed;
        lArm.transform.SetPositionAndRotation(lArm.transform.position,
                                               new Quaternion(lArm.transform.rotation.x,
                                                              lArm.transform.rotation.y,
                                                              Mathf.Clamp(lArm.transform.rotation.z + lvRot, minRot, maxRot),
                                                              lArm.transform.rotation.w));
        #endregion
    }
}
