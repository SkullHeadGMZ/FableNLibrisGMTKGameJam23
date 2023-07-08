using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteOrganizer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        int playerSort = 0;
        for(int i = 0; i < walls.Length; i++)
        {
            walls[i].GetComponentInChildren<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(walls[i].transform.position.y) * -1;
            if(Mathf.RoundToInt(walls[i].transform.position.y) * -1 < playerSort)
            {
                playerSort = (Mathf.RoundToInt(walls[i].transform.position.y) * -1) -1 ;
            }
        }
        if(PlayerMovement.instance != null)
        {
            PlayerMovement.instance.gameObject.GetComponentInChildren<SpriteRenderer>().sortingOrder = playerSort;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
