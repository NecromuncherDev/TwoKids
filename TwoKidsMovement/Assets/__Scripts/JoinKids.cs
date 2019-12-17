using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class JoinKids : MonoBehaviour
{
    public static JoinKids Instance;

    public GameObject twoKidsPrefab;
    public GameObject firstKid;

    private const int cooldownSeconds = 2;
    private const float minDistance = 2;

    private GameObject secondKid;
    private bool isChecking;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (isChecking && JoinKidsInput() && AreKidsClose())
        {
            GameObject newKid = Instantiate(twoKidsPrefab, firstKid.transform.position, Quaternion.identity);
            Destroy(firstKid);
            Destroy(secondKid);
            firstKid = newKid;
            isChecking = false;
            AdultsController.Instance.ToggleFollow();
        }
    }

    private bool JoinKidsInput()
    {
        return (CrossPlatformInputManager.GetAxis("Joy1L1") > 0 &&
                CrossPlatformInputManager.GetAxis("Joy1R1") > 0 &&
                CrossPlatformInputManager.GetAxis("Joy2L1") > 0 &&
                CrossPlatformInputManager.GetAxis("Joy2R1") > 0);
    }

    public void ActivateCheck(GameObject secondKid)
    {
        this.secondKid = secondKid;
        StartCoroutine(JoinCooldown());
    }

    private IEnumerator JoinCooldown()
    {
        yield return new WaitForSeconds(5);
        isChecking = true;
    }

    private bool AreKidsClose()
    {
        return Vector3.Distance(firstKid.transform.position, secondKid.transform.position) < minDistance;
    }
}
