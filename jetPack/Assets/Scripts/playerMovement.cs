using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : baseMovement
{
    public Vector2 leftThruster;
    public Vector2 rightThruster;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 force = Vector2.zero;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            force += leftThruster;
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
            force += rightThruster;
        }

        move(force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collided with object: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("good"))
        {
            Debug.Log("Hit a good object!");
            Destroy(collision.gameObject);
        }

        else if (collision.gameObject.CompareTag("bad"))
        {
            Debug.Log("Hit a bad object!");
            SceneManager.LoadScene(0);
        }
    }
}
