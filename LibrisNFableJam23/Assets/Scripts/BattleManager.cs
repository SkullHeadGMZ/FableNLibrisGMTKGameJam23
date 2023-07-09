using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    public Camera battleCam;
    public Camera mainCam;
    public GameObject battleTextUI;
    public GameObject battleButtons;
    public GameObject attackButt;
    public GameObject defButt;
    public GameObject statButt;
    public TextMeshProUGUI battleTxt;
    public Monster player;
    public moveType playerMove;
    public Monster opponent;
    public moveType oppMove;
    public battlePhase phase;
    public Sprite[] battleSprites;
    public GameObject playerSprite;
    public GameObject oppSprite;
    public Image playerHpBar;
    public Image oppHpBar;
    public bool inBattle;
    public Image playerDef;
    public Image oppDef;
    public GameObject[] playerDmg;
    public GameObject[] oppDmg;
    public GameObject inverseSymbol;
    public GameObject stopButt;
    public GameObject startButt;
    bool hasHappened;
    //keeps track of whetehr tricky is active
    bool typesInversed;
    // Start is called before the first frame update
    /*void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Monster>();
        if (player != null)
        {
            print("Found Player");

        }
        mainCam.gameObject.SetActive(true);
        battleCam.gameObject.SetActive(false);
    }*/

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Monster>();
        if (player != null)
        {
            print("Found Player");
        }
        mainCam.gameObject.SetActive(true);
        battleCam.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartBattle ()
    {
        phase = battlePhase.startPhase;
        if(player.Type == MonsterType.Good)
        {
            playerSprite.GetComponent<SpriteRenderer>().sprite = battleSprites[0];
        }
        else if(player.Type == MonsterType.Bad)
        {
            playerSprite.GetComponent<SpriteRenderer>().sprite = battleSprites[1];
        }
        else if(player.Type == MonsterType.Tricky)
        {
            playerSprite.GetComponent<SpriteRenderer>().sprite = battleSprites[2];
        }
        else
        {
            playerSprite.GetComponent<SpriteRenderer>().sprite = null;
        }
        if(opponent.Type == MonsterType.Good)
        {
            oppSprite.GetComponent<SpriteRenderer>().sprite = battleSprites[0];
        }
        else if (opponent.Type == MonsterType.Bad)
        {
            oppSprite.GetComponent<SpriteRenderer>().sprite = battleSprites[1];
        }
        else if (opponent.Type == MonsterType.Tricky)
        {
            oppSprite.GetComponent<SpriteRenderer>().sprite = battleSprites[2];
        }
        else
        {
            oppSprite = null;
        }
        battleCam.gameObject.SetActive(true);
        print("battlecam on");
        mainCam.gameObject.SetActive(false);
        print("maincam off");
        battleTextUI.SetActive(true);
        playerHpBar.fillAmount = player.hp / player.maxHP;
        oppHpBar.fillAmount = opponent.hp / opponent.maxHP;
        battleButtons.SetActive(false);
        battleTxt.text = "A collector spotted you!\r\nThey sent out a " + opponent.Type.ToString() + " monster!";
        startButt.SetActive(true);
        stopButt.SetActive(false);
        playerDef.gameObject.SetActive(false);
        oppDef.gameObject.SetActive(false);
        playerDmg[0].gameObject.SetActive(false);
        playerDmg[1].gameObject.SetActive(false);
        playerDmg[2].gameObject.SetActive(false);
        inverseSymbol.SetActive(false);
        oppDmg[0].gameObject.SetActive(false);
        oppDmg[1].gameObject.SetActive(false);
        oppDmg[2].gameObject.SetActive(false);
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
            SceneManager.LoadScene("GameOverLoss");
        }
        else if (opponent.hp <= 0)
        {
            print("opp losses");
            mainCam.gameObject.SetActive(true);
            battleCam.gameObject.SetActive(false);
            playerSprite.GetComponent<SpriteRenderer>().sprite = null;
            oppSprite.GetComponent<SpriteRenderer>().sprite = null;
            opponent.gameObject.SetActive(false);
            inBattle = false;
            player.gameObject.GetComponent<PlayerMovement>().canMove = true;
        }
    }

    public void Battle()
    {
        battleButtons.SetActive(false);
        battleTextUI.SetActive(true);
        phase = battlePhase.battlePhase;
        battleTextUI.SetActive(true);
        battleButtons.SetActive(false);
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
            playerMoveText = "You attacked! ";
        }
        else if (playerMove == moveType.defense)
        {
            playerMoveText = "You defended! ";
        }
        else if (playerMove == moveType.status && player.Type == MonsterType.Good)
        {
            playerMoveText = "You restored health! ";
        }
        else if (playerMove == moveType.status && player.Type == MonsterType.Bad)
        {
            playerMoveText = "You increased your damage rate! ";
        }
        else if (playerMove == moveType.status && player.Type == MonsterType.Tricky)
        {
            playerMoveText = "You reversed type effectivenss! ";
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
            oppMoveText = "Your opponent restored health!";
        }
        else if (oppMove == moveType.status && opponent.Type == MonsterType.Bad)
        {
            oppMoveText = "Your opponent increased their damage rate!";
        }
        else if (oppMove == moveType.status && opponent.Type == MonsterType.Tricky)
        {
            oppMoveText = "Your opponent reversed type effectivenss!";
        }
        battleTxt.text = playerMoveText + "\r\n" + oppMoveText;

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
                oppDef.gameObject.SetActive(true);
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
                    opponent.extraDmg += 2;
                    DamageCalc(player, opponent);
                    for(int q = 0; q < 3; q++)
                    {
                        if (q < (opponent.extraDmg/2))
                        {
                            oppDmg[q].SetActive(true);
                        }
                    }
                }
                else if (opponent.Type == MonsterType.Tricky)
                {
                    typesInversed = !typesInversed;
                    inverseSymbol.SetActive(typesInversed);
                    DamageCalc(player, opponent);
                }
            }
        }
       else if(playerMove == moveType.defense)
        {
            if(oppMove == moveType.attack)
            {
                player.defTurns += 2;
                playerDef.gameObject.SetActive(true);
                DamageCalc(opponent, player);
            }
            else if (oppMove == moveType.defense)
            {
                player.defTurns += 2;
                playerDef.gameObject.SetActive(true);
                opponent.defTurns += 2;
                oppDef.gameObject.SetActive(true);
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
                    playerDef.gameObject.SetActive(true);
                }
                else if (opponent.Type == MonsterType.Bad)
                {
                    opponent.extraDmg += 2;
                    for (int q = 0; q < 3; q++)
                    {
                        if (q < (opponent.extraDmg / 2))
                        {
                            oppDmg[q].SetActive(true);
                        }
                    }
                    player.defTurns += 2;
                    playerDef.gameObject.SetActive(true);
                }
                else if (opponent.Type == MonsterType.Tricky)
                {
                    typesInversed = !typesInversed;
                    inverseSymbol.SetActive(typesInversed);
                    player.defTurns += 2;
                    playerDef.gameObject.SetActive(true);
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
                player.extraDmg += 2;
                for (int q = 0; q < 3; q++)
                {
                    if(q < (player.extraDmg / 2)) 
                    {
                    playerDmg[q].SetActive(true);
                    }
                }
            }
            else if (player.Type == MonsterType.Tricky)
            {
                typesInversed = !typesInversed;
                inverseSymbol.SetActive(typesInversed);
            }

            if(oppMove == moveType.attack)
            {
                DamageCalc(opponent, player);
            }
            else if (oppMove == moveType.defense)
            {
                opponent.defTurns += 2;
                oppDef.gameObject.SetActive(true);
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
                    opponent.extraDmg += 2;
                    for (int q = 0; q < 3; q++)
                    {
                        if (q < (opponent.extraDmg / 2))
                        {
                            oppDmg[q].SetActive(true);
                        }
                    }

                }
                else if (opponent.Type == MonsterType.Tricky)
                {
                    typesInversed = !typesInversed;
                    inverseSymbol.SetActive(typesInversed);
                }
            }
        }
        playerHpBar.fillAmount = player.hp / player.maxHP;
        oppHpBar.fillAmount = opponent.hp / opponent.maxHP;

        if ((player.hp <=0) || (opponent.hp <= 0)) {
            //EndBattle();
            stopButt.SetActive(true);
            startButt.SetActive(false);
            if(player.hp <= 0)
            {
                battleTxt.text = "Your opponent defeated you…";
            }
            else if(opponent.hp <= 0)
            {
                battleTxt.text = "Congratulations!\r\nYou bested your opponent and escaped!";
            }
        }
        else
        {
            return;
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
            if(monA.defTurns == 0)
            {
                if(monA.gameObject.tag == "Player")
                {
                    playerDef.gameObject.SetActive(false);
                }
                else
                {
                    oppDef.gameObject.SetActive(false);
                }
            }
        }
        if(monB.defTurns > 0)
        {
            monB.defTurns -= 1;
            if (monB.defTurns == 0)
            {
                if (monB.gameObject.tag == "Player")
                {
                    playerDef.gameObject.SetActive(false);
                }
                else
                {
                    oppDef.gameObject.SetActive(false);
                }
            }
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
