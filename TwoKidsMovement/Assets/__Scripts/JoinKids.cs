using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinKids : MonoBehaviour
{
    public static JoinKids Instance;

    public GameObject twoKidsPrefab;
    public GameObject firstKid;

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
        if (isChecking && Input.GetKeyDown(KeyCode.R))
        {
            GameObject newKid = Instantiate(twoKidsPrefab, firstKid.transform.position, Quaternion.identity);
            Destroy(firstKid);
            Destroy(secondKid);
            firstKid = newKid;
            isChecking = false;
        }
    }

    public void ActivateCheck(GameObject secondKid)
    {
        this.secondKid = secondKid;
        isChecking = true;
    }
}
