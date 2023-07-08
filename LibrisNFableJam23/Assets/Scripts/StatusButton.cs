using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatusButton : MonoBehaviour
{
    public TextMeshProUGUI butt;
    public BattleManager battleMan;
    public string[] Names;
    public TextMeshProUGUI desc;
    public string[] descriptions;
    // Start is called before the first frame update
    void Start()
    {
        if (battleMan.player.Type == MonsterType.Good)
        {
            print(battleMan.player.Type);
            butt.text = Names[0];
            desc.text = descriptions[0];
        }
        else if (battleMan.player.Type == MonsterType.Bad)
        {
            butt.text = Names[1];
            desc.text = descriptions[1];
        }
        else if (battleMan.player.Type == MonsterType.Tricky)
        {
            butt.text = Names[2];
            desc.text = descriptions[2];
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Status()
    {
        battleMan.playerMove = moveType.status;
        battleMan.Battle();
    }
}
