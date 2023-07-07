using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusButton : MonoBehaviour
{
    public GameObject butt;
    public BattleManager battleMan;
    public string[] Names;
    // Start is called before the first frame update
    void Start()
    {
        if (battleMan.player.Type == MonsterType.Good)
        {
            butt.GetComponent<TextMesh>().text = Names[0];
        }
        else if (battleMan.player.Type == MonsterType.Bad)
        {
            butt.GetComponent<TextMesh>().text = Names[1];
        }
        else if (battleMan.player.Type == MonsterType.Tricky)
        {
            butt.GetComponent<TextMesh>().text = Names[2];
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
