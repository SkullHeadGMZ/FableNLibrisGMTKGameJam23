using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Choose how fast pc goes
    public float speed;
    //lets object reference itself
    public GameObject player;
    int newX;
    int newY;
    public Rigidbody2D rb;
    Vector2 movement;
    public bool canMove;
    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        /*newX = Mathf.FloorToInt(player.transform.position.x);
        newY = newY = Mathf.FloorToInt(player.transform.position.y);*/
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove == true)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }
        else
        {
            movement = Vector2.zero;
            return;
        }
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        /*
        //go up
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)){
            newY += 1;
        }

        //go down
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)){
            newY -= 1;
        }

        //go left
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)){
            newX -= 1;
        }

        //go right
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)){
            newX += 1;
        }
        if(player.transform.position.x > newX)
        {
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(-speed, 0));
        }
        else if(transform.position.x < newX)
        {
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed, 0));
        }
        else if(Mathf.Abs(transform.position.x - newX) <= .01)
        {
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, (player.GetComponent<Rigidbody2D>().velocity.y));
        }
        if (player.transform.position.y > newY)
        {
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -speed));
        }
        else if (transform.position.y < newY)
        {
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, speed));
        }
        else if (Mathf.Abs(transform.position.y - newY) <= .01)
        {
            player.GetComponent<Rigidbody2D>().velocity = new Vector2((player.GetComponent<Rigidbody2D>().velocity.x), 0);
        }
        */
    }
}

public enum MonsterType
{
   Good,
   Bad,
   Tricky
}
