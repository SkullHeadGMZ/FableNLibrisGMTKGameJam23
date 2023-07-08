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
    public Animator anim;

    public static PlayerMovement instance;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject); 
        canMove = true;
        /*newX = Mathf.FloorToInt(player.transform.position.x);
        newY = newY = Mathf.FloorToInt(player.transform.position.y);*/
    }
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else { 
            if(instance != this)
            {
                Destroy(gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove == true)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            if (Mathf.Abs(movement.y) > Mathf.Abs(movement.x))
            {
                movement.x = 0;
            }
            else
            {
                movement.y = 0;
            }
        }
        else
        {
            movement = Vector2.zero;
            return;
        }
        if (movement.y > 0)
        {
            anim.SetInteger("animNum", 1);
        }
        else if (movement.y < 0)
        {
            anim.SetInteger("animNum", 3);
        }
        else if (movement.x > 0)
        {
            anim.SetInteger("animNum", 2);
        }
        else if (movement.x < 0)
        {
            anim.SetInteger("animNum", 4);
        }
        else
        {
            anim.SetInteger("animNum", 0);
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
