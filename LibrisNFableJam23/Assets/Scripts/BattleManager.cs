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
        battleCam.gameObject.SetActive(true);
        print("battlecam on");
        mainCam.gameObject.SetActive(false);
        print("maincam off");
        battleTextUI.SetActive(true);
        battleButtons.SetActive(false);
        battleTxt.GetComponent<TextMesh>().text = "A TRAINER ambushued you! They sent out a " + opponent.Type.ToString() + "monster!";
        phase = battlePhase.startPhase;

    }

    public void EndBattle()
    {
        phase = battlePhase.endPhase;
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
