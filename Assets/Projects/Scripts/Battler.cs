using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//MonsterManager 필요 
//현재는 디폴트로 합시다.

public class Battler : MonoBehaviour
{
    // Use this for initialization
    public int Life;    // 생명력
    public int Level;   // 레벨 
    public int mana;    // 상점구매 마나? 골드 

    public int battleIndex;  //전투시 순서

    public List<Monster> monsterList = new List<Monster>();

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public bool addMonster(int card)
    {
        return true;
    }

    public bool deathMonster(Monster monster)
    {
        Debug.Log(monster.name + "사망");
        
        monsterList.Remove(monster);

        monster.gameObject.SetActive(false);

        return true;
    }
}
