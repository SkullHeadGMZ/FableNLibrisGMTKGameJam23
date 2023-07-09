using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterChooser : MonoBehaviour
{
    public Button goodButt;
    public Button badButt;
    public Button trickButt;
    public GameObject goodPrefab;
    public GameObject badPrefab;
    public GameObject trickPrefab;
    Monster playerMon;
    public Sprite goodSprite;
    public Sprite badSprite;
    public Sprite trickSprite;
    public GameObject exit;
    public GameObject gTrain;
    public GameObject bTrain;
    public GameObject tTrain;
    public GameObject battleMan;
    // Start is called before the first frame update
    void Start()
    {
        //playerMon = GameObject.FindGameObjectWithTag("Player").GetComponent<Monster>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChooseGood()
    {
        GameObject playerClone = Instantiate(goodPrefab, Vector3.zero, Quaternion.identity);
        playerMon = playerClone.GetComponent<Monster>();
        playerMon.Type = MonsterType.Good;
        playerMon.superEfective = MonsterType.Bad;
        playerMon.reverseEffective = MonsterType.Tricky;
        playerMon.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = goodSprite;
        GameObject firstEnemy = Instantiate(bTrain, new Vector3(0,10,0), Quaternion.identity);
        firstEnemy.GetComponent<BattleTrigger>().looking = LookDirection.Down;
        battleMan.SetActive(true);
        exit.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ChooseBad()
    {
        GameObject playerClone = Instantiate(badPrefab, Vector3.zero, Quaternion.identity);
        playerMon = playerClone.GetComponent<Monster>();
        playerMon.Type = MonsterType.Bad;
        playerMon.superEfective = MonsterType.Tricky;
        playerMon.reverseEffective = MonsterType.Good;
        playerMon.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = badSprite;
        GameObject firstEnemy = Instantiate(tTrain, new Vector3(0, 10, 0), Quaternion.identity);
        firstEnemy.GetComponent<BattleTrigger>().looking = LookDirection.Down;
        battleMan.SetActive(true);
        exit.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ChooseTrick()
    {
        GameObject playerClone = Instantiate(trickPrefab, Vector3.zero, Quaternion.identity);
        playerMon = playerClone.GetComponent<Monster>();
        playerMon.Type = MonsterType.Tricky;
        playerMon.superEfective = MonsterType.Good;
        playerMon.reverseEffective = MonsterType.Bad;
        playerMon.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = trickSprite;
        GameObject firstEnemy = Instantiate(gTrain, new Vector3(0, 10, 0), Quaternion.identity);
        firstEnemy.GetComponent<BattleTrigger>().looking = LookDirection.Down;
        battleMan.SetActive(true);
        exit.SetActive(true);
        gameObject.SetActive(false);
    }
}
