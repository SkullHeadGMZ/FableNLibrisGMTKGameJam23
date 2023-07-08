using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string nextLevel;
    public Vector2 newLocation;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = PlayerMovement.instance.gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.transform.position = newLocation;
        SceneManager.LoadScene(nextLevel);
    }
}
