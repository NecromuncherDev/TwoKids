using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Balance : MonoBehaviour
{
    [SerializeField]
    Transform rHand, lHand, center;

    [SerializeField]
    Image meter;

    [SerializeField]
    Rigidbody botKid, topKid;

    float balance;
    byte r, g, b;
    private void Start()
    {
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

        if (findBalanceDist() > 250)
        {
            topKid.GetComponent<Joint>().breakForce = 0;
        }

        r = byte.Parse(Mathf.RoundToInt(findBalanceDist()).ToString());
        g = b = byte.Parse((255 - int.Parse(r.ToString())).ToString());

        meter.GetComponent<Image>().color = new Color32(r, g, b, 255);


    }

    float findBalanceDist()
    {
        return  Mathf.Clamp(((( rHand.position - center.position ) + ( lHand.position - center.position)/2).magnitude * 255 + botKid.velocity.magnitude * 10),0f,255f);
    }
}
