using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AttackButton : MonoBehaviour
{
    public GameObject atkButt;
    public BattleManager battleMan;
    public string[] atkNames;
    public TextMeshProUGUI desc;
    public string[] descriptions;
    // Start is called before the first frame update
    void Start() { 

    }
    void Awake()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        if(battleMan.player.Type == MonsterType.Good)
        {
            atkButt.GetComponent<TextMeshProUGUI>().text = atkNames[0];
            desc.text = descriptions[0];
        }
        else if (battleMan.player.Type == MonsterType.Bad)
        {
            atkButt.GetComponent<TextMeshProUGUI>().text = atkNames[1];
            desc.text = descriptions[1];
        }
        else if (battleMan.player.Type == MonsterType.Tricky)
        {
            atkButt.GetComponent<TextMeshProUGUI>().text = atkNames[2];
            desc.text = descriptions[2];
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
