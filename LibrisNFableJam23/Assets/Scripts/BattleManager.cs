using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public Camera battleCam;
    public Camera mainCam;
    public GameObject battleTextUI;
    public GameObject battleButtons;
    public GameObject attackButt;
    public GameObject defButt;
    public GameObject statButt;
    public GameObject battleTxt;
    public Monster player;
    public moveType playerMove;
    public Monster opponent;
    public moveType oppMove;
    public battlePhase phase;
    //keeps track of whetehr tricky is active
    bool typesInversed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Monster>();
        if (player != null)
        {
            print("Found Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartBattle ()
    {
        phase = battlePhase.startPhase;
        battleCam.gameObject.SetActive(true);
        print("battlecam on");
        mainCam.gameObject.SetActive(false);
        print("maincam off");
        battleTextUI.SetActive(true);
        battleButtons.SetActive(false);
        battleTxt.GetComponent<TextMesh>().text = "A TRAINER ambushued you! They sent out a " + opponent.Type.ToString() + "monster!";
        player.extraDmg = 0;
        player.defTurns = 0;
        opponent.extraDmg = 0;
        opponent.defTurns = 0;


    }

    public void EndBattle()
    {
        phase = battlePhase.endPhase;
        player.extraDmg = 0;
        player.defTurns = 0;
        if(player.hp <= 0)
        {
            print("player loses");
            //loadscene.gameover
        }
        else if (opponent.hp <= 0)
        {
            print("opp losses");
            mainCam.gameObject.SetActive(true);
            battleCam.gameObject.SetActive(false);
        }
    }

    public void Battle()
    {
        battleButtons.SetActive(false);
        battleTextUI.SetActive(true);
        phase = battlePhase.battlePhase;
        int i = Random.Range(0, 3);
        print (i);
        if (i == 0)
        {
            oppMove = moveType.attack;
        }
        else if (i == 1)
        {
            oppMove = moveType.defense;
        }
        else if (i == 2)
        {
            oppMove = moveType.status;
        }
        else
        {
            oppMove = moveType.attack;
        }
        string playerMoveText = " ";
        string oppMoveText = " ";
        if(playerMove == moveType.attack)
        {
            playerMoveText = "You attacked!";
        }
        else if (playerMove == moveType.defense)
        {
            playerMoveText = "You defended!";
        }
        else if (playerMove == moveType.status && player.Type == MonsterType.Good)
        {
            playerMoveText = "You restored health!";
        }
        else if (playerMove == moveType.status && player.Type == MonsterType.Bad)
        {
            playerMoveText = "You've increased your damage rate!";
        }
        else if (playerMove == moveType.status && player.Type == MonsterType.Tricky)
        {
            playerMoveText = "You reversed type effectivenss!";
        }

        if (oppMove == moveType.attack)
        {
           oppMoveText = "Your opponent attacked!";
        }
        else if (oppMove == moveType.defense)
        {
            oppMoveText = "Your opponent defended!";
        }
        else if (oppMove == moveType.status && opponent.Type == MonsterType.Good)
        {
            oppMoveText = "You restored health!";
        }
        else if (oppMove == moveType.status && opponent.Type == MonsterType.Bad)
        {
            oppMoveText = "You've increased your damage rate!";
        }
        else if (oppMove == moveType.status && opponent.Type == MonsterType.Tricky)
        {
            oppMoveText = "You reversed type effectivenss!";
        }
        battleTxt.GetComponent<TextMesh>().text = playerMoveText + oppMoveText;

        //figure out how the battle goes
       if(playerMove == moveType.attack)
        {
            if(oppMove == moveType.attack)
            {
                DamageCalc(player, opponent);
                DamageCalc(opponent, player);
            }
            else if(oppMove == moveType.defense)
            {
                opponent.defTurns += 2;
                DamageCalc(player, opponent);
            }
            else if(oppMove == moveType.status)
            {
                if(opponent.Type == MonsterType.Good)
                {
                    opponent.hp += 10;
                    if(opponent.hp > opponent.maxHP) {
                        opponent.hp = opponent.maxHP;
                    }
                    DamageCalc(player, opponent);
                }
                else if(opponent.Type == MonsterType.Bad) {
                    opponent.extraDmg += 1;
                    DamageCalc(player, opponent);
                }
                else if (opponent.Type == MonsterType.Tricky)
                {
                    typesInversed = !typesInversed;
                    DamageCalc(player, opponent);
                }
            }
        }
       else if(playerMove == moveType.defense)
        {
            if(oppMove == moveType.attack)
            {
                player.defTurns += 2;
                DamageCalc(opponent, player);
            }
            else if (oppMove == moveType.defense)
            {
                player.defTurns += 2;
                opponent.defTurns += 2;
            }
            else if (oppMove == moveType.status)
            {
                if (opponent.Type == MonsterType.Good)
                {
                    opponent.hp += 10;
                    if (opponent.hp > opponent.maxHP)
                    {
                        opponent.hp = opponent.maxHP;
                    }
                    player.defTurns += 2;
                }
                else if (opponent.Type == MonsterType.Bad)
                {
                    opponent.extraDmg += 1;
                    player.defTurns += 2;
                }
                else if (opponent.Type == MonsterType.Tricky)
                {
                    typesInversed = !typesInversed;
                    player.defTurns += 2;
                }
            }
        }
       else if(playerMove == moveType.status)
        {
            if(player.Type == MonsterType.Good)
            {
                player.hp += 10;
                if(player.hp > player.maxHP)
                {
                    player.hp = player.maxHP;
                }
            }
            else if (player.Type == MonsterType.Bad)
            {
                player.extraDmg += 1;
            }
            else if (player.Type == MonsterType.Tricky)
            {
                typesInversed = !typesInversed;
            }

            if(oppMove == moveType.attack)
            {
                DamageCalc(opponent, player);
            }
            else if (oppMove == moveType.defense)
            {
                opponent.defTurns += 2;
            }
            else if (oppMove == moveType.status)
            {
                if (opponent.Type == MonsterType.Good)
                {
                    opponent.hp += 10;
                    if (opponent.hp > opponent.maxHP)
                    {
                        opponent.hp = opponent.maxHP;
                    }
                }
                else if (opponent.Type == MonsterType.Bad)
                {
                    opponent.extraDmg += 1;
                }
                else if (opponent.Type == MonsterType.Tricky)
                {
                    typesInversed = !typesInversed;
                }
            }
        }

        if ((player.hp <=0) || (opponent.hp <= 0)) {
            EndBattle();
        }
        else
        {
            StartChoosePhase();
        }
    }

    public void StartChoosePhase()
    {
        phase = battlePhase.choosePhase;
        battleTextUI.gameObject.SetActive(false);
        battleButtons.gameObject.SetActive(true);
    }

    public void DamageCalc(Monster monA, Monster monB)
    {
        int damage = monA.attack;
        if (typesInversed == true)
        {
            if (monA.reverseEffective == monB.Type)
            {
                {
                    damage = Mathf.FloorToInt(monA.attack + monA.extraDmg + (monA.attack + monA.extraDmg / 2));
                }
            }
            else
            {
                damage = monA.attack + monA.extraDmg;
            }
        }
        else
        {
            if (monA.superEfective == monB.Type) {
                {
                    damage = Mathf.FloorToInt(monA.attack + monA.extraDmg + (monA.attack + monA.extraDmg / 2));
                }
            }
            else
            {
                damage = monA.attack + monA.extraDmg;
            }
        }
        if (monB.defTurns > 0)
        {
            damage = damage / 2;
        }
        monB.hp -= damage;
        if(monB.hp < 0)
        {
            monB.hp = 0;
        }
        if(monA.defTurns > 0)
        {
            monA.defTurns -= 1;
        }
        if(monB.defTurns > 0)
        {
            monB.defTurns -= 1;
        }
    }


}

public enum moveType
{
    attack,
    defense,
    status
}

public enum battlePhase
{
    startPhase,
    choosePhase,
    battlePhase,
    endPhase
}
