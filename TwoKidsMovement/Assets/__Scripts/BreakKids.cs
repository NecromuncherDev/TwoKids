using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class BreakKids: MonoBehaviour
{
    //bool isBroken = false;

    [SerializeField]
    private Transform realRootParent;

    [SerializeField]
    GameObject botKidPrefab, twoKidsPrefab;

    void OnJointBreak(float breakForce)
    {
        Debug.Log("A joint has just been broken!, force: " + breakForce);
        realRootParent.SetParent(null);
        GameObject newKid = Instantiate(botKidPrefab, Vector3.zero, Quaternion.identity);
        newKid.GetComponent<ThirdPersonUserControl>().playerNumber = 0;
        Destroy(realRootParent.gameObject);
        JoinKids.Instance.ActivateCheck(newKid);
    }
}
