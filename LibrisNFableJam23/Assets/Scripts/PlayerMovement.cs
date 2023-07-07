using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Choose how fast pc goes
    public float speed;
    //lets object reference itself
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //go up
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)){
            player.transform.position = new Vector2 (player.transform.position.x, player.transform.position.y + speed);
        }

        //go down
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)){
            player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y - speed);
        }

        //go left
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.RightArrow)){
            player.transform.position = new Vector2(player.transform.position.x - speed, player.transform.position.y);
        }

        //go right
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow)){
            player.transform.position = new Vector2(player.transform.position.x + speed, player.transform.position.y);
        }
    }
}
