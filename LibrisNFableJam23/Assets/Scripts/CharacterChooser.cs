using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterChooser : MonoBehaviour
{
    public Button goodButt;
    public Button badButt;
    public Button trickButt;
    public Monster playerMon;
    public Sprite goodSprite;
    public Sprite badSprite;
    public Sprite trickSprite;
    // Start is called before the first frame update
    void Start()
    {
        playerMon = GameObject.FindGameObjectWithTag("Player").GetComponent<Monster>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChooseGood()
    {
        playerMon.Type = MonsterType.Good;
        playerMon.superEfective = MonsterType.Bad;
        playerMon.reverseEffective = MonsterType.Tricky;
        playerMon.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = goodSprite;
        gameObject.SetActive(false);
    }

    public void ChooseBad()
    {
        playerMon.Type = MonsterType.Bad;
        playerMon.superEfective = MonsterType.Tricky;
        playerMon.reverseEffective = MonsterType.Good;
        playerMon.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = badSprite;
        gameObject.SetActive(false);
    }

    public void ChooseTrick()
    {
        playerMon.Type = MonsterType.Tricky;
        playerMon.superEfective = MonsterType.Good;
        playerMon.reverseEffective = MonsterType.Bad;
        playerMon.gameObject.transform.GetComponentInChildren<SpriteRenderer>().sprite = trickSprite;
        gameObject.SetActive(false);
    }
}
