using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private Vector2 movment;
    [SerializeField] float forceSide;
    [SerializeField] float forceJump;
    Rigidbody2D rb;
    [SerializeField] bool isInAir;

    // Start is called before the first frame update
    void Start()
    {
     
  
        rb = this.GetComponent<Rigidbody2D>();
        isInAir = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Move horizontal
        float x = Input.GetAxis("Horizontal");
        Vector2 horizontal = new Vector2(x, 0);

        rb.AddForce(horizontal * forceSide);

        // Jump vertical
        if(Input.GetKeyDown(KeyCode.Space) && (!isInAir))
        {
            Debug.Log("im jumping");
            Vector2 vertical = new Vector2(0, 1);
            rb.AddForce(vertical * forceJump);
            isInAir = true;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("im here");
        if (collision.tag == "floor")
        {
            Debug.Log("im here22222");
            isInAir = false;
        }

        if (collision.tag == "enemy")
        {
            this.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
}
