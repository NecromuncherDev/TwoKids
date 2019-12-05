using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upDown : MonoBehaviour
{
    float myY;
    [SerializeField] float addNum = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        myY = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + addNum * Time.deltaTime);
        if(Time.time % 3 == 0)
        {
            addNum = -addNum;
        }
    }
}
