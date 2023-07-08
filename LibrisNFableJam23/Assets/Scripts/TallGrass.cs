using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TallGrass : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.gameObject.layer = 2;
            print(gameObject.layer + " is now pc's layer");
        }
        else
        {
            print("You don't belong in the grass");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.gameObject.layer = 0;
        }
        else
        {
            print("I'm glad you're gone");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(collision.gameObject.layer != 2)
            {
                collision.gameObject.layer = 2;
            }
        }
        else
        {
            return;
        }
    }
}
