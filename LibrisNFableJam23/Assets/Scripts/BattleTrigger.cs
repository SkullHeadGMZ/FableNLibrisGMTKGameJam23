using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTrigger : MonoBehaviour
{
    public BattleManager battleMan;
    // Start is called before the first frame update
    void Start()
    {
        battleMan = GameObject.FindGameObjectWithTag("BattleManager").GetComponent<BattleManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        print("You have entered a battle");
        battleMan.opponent = gameObject.GetComponent<Monster>();
        battleMan.StartBattle();
    }
}
