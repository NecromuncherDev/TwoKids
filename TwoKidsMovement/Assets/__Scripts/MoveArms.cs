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

    [SerializeField]
    int topKidControler;

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
        #region Arms

        rh = CrossPlatformInputManager.GetAxis("Joy" + topKidControler + "XR");
        rv = CrossPlatformInputManager.GetAxis("Joy" + topKidControler + "YR");
        lh = CrossPlatformInputManager.GetAxis("Joy" + topKidControler + "XL");
        lv = -CrossPlatformInputManager.GetAxis("Joy" + topKidControler + "YL");

        rh = (rh == 0) ? rShoulder.transform.localRotation.normalized.y : rh;
        rv = (rv == 0) ? rShoulder.transform.localRotation.normalized.z : rv;
        lh = (lh == 0) ? lShoulder.transform.localRotation.normalized.y : lh;
        lv = (lv == 0) ? lShoulder.transform.localRotation.normalized.z : lv;

        //Debug.Log("rh: " + rh + ", rv: " + rv);
        //Debug.Log("lh: " + lh + ", lv: " + lv);

        Quaternion rotX = Quaternion.AngleAxis(0f, new Vector3(1, 0, 0));
        Quaternion rotYR = Quaternion.AngleAxis(rh * moveSpeed, new Vector3(0, 1, 0));
        Quaternion rotZR = Quaternion.AngleAxis(rv * moveSpeed, new Vector3(0, 0, 1));
        Quaternion rotYL = Quaternion.AngleAxis(lh * moveSpeed, new Vector3(0, 1, 0));
        Quaternion rotZL = Quaternion.AngleAxis(lv * moveSpeed, new Vector3(0, 0, 1));

        rShoulder.transform.localRotation = rShoulder.transform.localRotation * rotX * rotYR * rotZR;
        lShoulder.transform.localRotation = lShoulder.transform.localRotation * rotX * rotYL * rotZL;

        #endregion 
    }
}
