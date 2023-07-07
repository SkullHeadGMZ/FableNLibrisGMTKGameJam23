using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButton : MonoBehaviour
{
    public GameObject atkButt;
    public BattleManager battleMan;
    public string[] atkNames;
    // Start is called before the first frame update
    void Start()
    {
        if(battleMan.player.Type == MonsterType.Good)
        {
            atkButt.GetComponent<TextMesh>().text = atkNames[0];
        }
        else if (battleMan.player.Type == MonsterType.Bad)
        {
            atkButt.GetComponent<TextMesh>().text = atkNames[1];
        }
        else if (battleMan.player.Type == MonsterType.Tricky)
        {
            atkButt.GetComponent<TextMesh>().text = atkNames[2];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
    {
        battleMan.playerMove = moveType.attack;
        battleMan.Battle();
    }
}
