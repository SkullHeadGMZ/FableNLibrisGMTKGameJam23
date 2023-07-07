using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public MonsterType Type;
    public int attack;
    public int hp;
    public MonsterType superEfective;
    public MonsterType reverseEffective;

    private void Start()
    {
        if(Type == MonsterType.Good)
        {
            superEfective = MonsterType.Bad;
            reverseEffective = MonsterType.Tricky;
        }
        else if(Type == MonsterType.Bad){
            superEfective = MonsterType.Tricky;
            reverseEffective = MonsterType.Good;
        }
        else if (Type == MonsterType.Tricky)
        {
            superEfective = MonsterType.Good;
            superEfective = MonsterType.Bad;
        }
    }
}