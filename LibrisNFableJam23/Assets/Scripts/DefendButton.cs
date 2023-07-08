using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DefendButton : MonoBehaviour
{
    public TextMeshProUGUI butt;
    public BattleManager battleMan;
    public string[] Names;
    // Start is called before the first frame update
    void Start()
    {
        if (battleMan.player.Type == MonsterType.Good)
        {
            butt.text = Names[0];
        }
        else if (battleMan.player.Type == MonsterType.Bad)
        {
            butt.text = Names[1];
        }
        else if (battleMan.player.Type == MonsterType.Tricky)
        {
            butt.text = Names[2];
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Defend()
    {
        battleMan.playerMove = moveType.defense;
        battleMan.Battle();
    }
}
