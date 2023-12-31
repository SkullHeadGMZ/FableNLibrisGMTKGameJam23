using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTrigger : MonoBehaviour
{
    public BattleManager battleMan;
    public Rigidbody2D rb2D;
    public LookDirection looking;
    public Animator anim;
    RaycastHit2D hit;
    public Sprite[] owSprites;
    SpriteRenderer mySprite;
    public GameObject exclamation;
    //public int raycDist;
    // Start is called before the first frame update
    void Start()
    {
        battleMan = GameObject.FindGameObjectWithTag("BattleManager").GetComponent<BattleManager>();
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        mySprite = GetComponentInChildren<SpriteRenderer>();
        if (looking == LookDirection.Up)
        {
            mySprite.sprite = owSprites[0];
        }
        else if (looking == LookDirection.Right)
        {
            mySprite.sprite = owSprites[1];
        }
        else if (looking == LookDirection.Down)
        {
            mySprite.sprite = owSprites[2];
        }
        else if (looking == LookDirection.Left)
        {
            mySprite.sprite = owSprites[3];
        }
    }

    private void FixedUpdate()
    {
        if (looking == LookDirection.Up)
        {
            hit = Physics2D.Raycast(transform.position, Vector2.up, Mathf.Infinity);
            //Debug.DrawRay(transform.position, Vector2.up * Mathf.Infinity, Color.black, 100);
            //print(gameObject.name + " hit " + hit.collider.name);
        }
        else if (looking == LookDirection.Right)
        {
            hit = Physics2D.Raycast(transform.position, Vector2.right, Mathf.Infinity);
            //Debug.DrawRay(transform.position, Vector2.right * Mathf.Infinity, Color.black, 100);
            //print(gameObject.name + " hit " + hit.collider.name);
        }
        else if (looking == LookDirection.Left)
        {
            hit = Physics2D.Raycast(transform.position, Vector2.left, Mathf.Infinity);
            //Debug.DrawRay(transform.position, Vector2.left * Mathf.Infinity, Color.black, 100);
            //print(gameObject.name + " hit " + hit.collider.name);
        }
        else if (looking == LookDirection.Down)
        {
            hit = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity);
            //Debug.DrawRay(transform.position, Vector2.down * Mathf.Infinity, Color.black, 100);
            //print(gameObject.name + " hit " + hit.collider.name);
        }
        if (hit.collider != null)
        {
            if (hit.collider.tag == "Player" && battleMan.inBattle == false)
            {
                StartCoroutine("PlayerFound");
            }
            else
            {
               // print("Hit " + hit.collider.name + " but they aren't a monster");
                return;
            }
        }
        //Physics.IgnoreCollision(gameObject.GetComponent<BoxCollider2D>(), gameObject.GetComponent<BoxCollider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            print("You have entered a battle");
            battleMan.opponent = gameObject.GetComponent<Monster>();
            collision.gameObject.GetComponent<PlayerMovement>().canMove = false;
            battleMan.StartBattle();
        }
        else
        {
            print("Hit " + collision.name + " but they aren't a monster");
            return;
        }
    }*/

    IEnumerator PlayerFound()
    {
      exclamation.SetActive(true);
        PlayerMovement.instance.canMove = false;
      yield return new WaitForSeconds(1);
      print("You have entered a battle");
      battleMan.opponent = gameObject.GetComponent<Monster>();
      battleMan.inBattle = true;
      battleMan.StartBattle();
    }
}

public enum LookDirection
{
    Up,
    Right,
    Left,
    Down
}
