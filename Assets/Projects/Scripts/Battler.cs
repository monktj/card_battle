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
    public Monster GetAttackMonster()
    {
        if (battleIndex >= monsterList.Count)
            battleIndex = 0;

        if (monsterList.Count == 0)
        {
            Debug.Log("GetAttackMonster == null");
            return null;
        }

       return  monsterList[battleIndex++];
    }

    public Monster GetDefenseMonst()
    {

        int DefenseMonsterIndex = 0;
        //현재는 일단 도발은무시 
        List<Monster> tauntMonsterlist = monsterList.FindAll(x => x.taunt == true);

        if(tauntMonsterlist.Count > 0)
        {
            DefenseMonsterIndex = Random.Range(0, tauntMonsterlist.Count);

            return tauntMonsterlist[DefenseMonsterIndex];
        }


        DefenseMonsterIndex = Random.Range(0, monsterList.Count);
        return monsterList[DefenseMonsterIndex];
    }

    public bool deathMonster(Monster monster)
    {
        Debug.Log(monster.name + "사망");
        
        monsterList.Remove(monster);

        monster.gameObject.SetActive(false);

        return true;
    }

    public void BattleReady()
    {
        foreach (var monster in monsterList)
            monster.BattleSet();

    }
}
