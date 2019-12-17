using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class Balance : MonoBehaviour
{
    [SerializeField]
    Transform rHand, lHand, center;

    Vector3 rFlat, lFlat, cFlat;

    [SerializeField]
    Image meter;

    [SerializeField]
    Rigidbody botKid, topKid;

    int playerNumber = 1;
    float balance;
    float r, g, b;

    private void Start()
    {
        meter = FindObjectOfType<Image>();
        balance = findBalanceDist();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.E))
        {
            balance = findBalanceDist();
            Debug.Log("b: " + balance);
            Debug.Log(meter.color);
        }

        if (findBalanceDist() > 0.55f)
        {
            topKid.GetComponent<Joint>().breakForce = 0;
        }

        r = findBalanceDist();
        g = b = 1 - findBalanceDist();

        meter.GetComponent<Image>().color = new Color(r, g, b, 255);


    }

    float findBalanceDist()
    {
        cFlat = new Vector3(center.position.x, 0, center.position.z);
        rFlat = new Vector3(rHand.position.x, 0, rHand.position.z);
        lFlat = new Vector3(lHand.position.x, 0, lHand.position.z);
        float h = CrossPlatformInputManager.GetAxis("Joy" + (playerNumber + 1) + "XR");
        float v = CrossPlatformInputManager.GetAxis("Joy" + (playerNumber + 1) + "YR");
        Vector3 input = new Vector3(h, 0, v);
        Vector3 balance = ((rFlat - cFlat) + (lFlat - cFlat) + input) / 3;
        meter.transform.localPosition = new Vector3(-balance.z, balance.x, 0) * 10;
        
        return (balance).magnitude;
    }
}
