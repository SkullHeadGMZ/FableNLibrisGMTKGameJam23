using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.FindGameObjectsWithTag("Player").Length != 0)
        {
            Destroy(PlayerMovement.instance.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
