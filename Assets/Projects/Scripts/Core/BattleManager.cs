using UnityEngine;
using System.Collections;


//전투 관련 부부만 처리할지 
//선턴 후턴 
// 

public class BattleManager : MonoBehaviour
{
    public Battler player, enemy;
    bool playBattle = true;
    Battler attacker, defenser;

    // Use this for initialization
    void Start()
    {
        attacker = player;
        defenser = enemy;

    }

    // Update is called once per frame
    float Timetick;
    void Update()
    {
        
        if (playBattle)
        {
            Timetick += Time.deltaTime;

            if (Timetick > 1f)
            {
                Timetick = 0;
                playBattle = Battle(attacker, defenser);
                Battler temp = attacker;
                attacker = defenser;
                defenser = temp;
            }            
        }
        

        //while (playBattle)
        //{
            


        //}        
    }
    
    private bool Battle(Battler attack,Battler Defense)
    {
        if (attack.monsterList.Count == 0 || Defense.monsterList.Count == 0)
        {
            if (attack.monsterList.Count == 0 && Defense.monsterList.Count == 0)
                Debug.Log("무승부");
            else if (player.monsterList.Count >0)
                Debug.Log("플레이어 승");
            else
                Debug.Log("적 승");

            return false;
        }

        Attack(attack, Defense);

        return true;
    }

    //전투
    private bool Attack(Battler attack,  Battler Defensse)
    {
        Monster attackMonster = attack.monsterList[attack.battleIndex];

        //현재는 일단 도발은무시 
        int DefenseMonsterIndex = Random.Range(0, Defensse.monsterList.Count);
        //attackMonster

        Monster defenseMonster = Defensse.monsterList[DefenseMonsterIndex];

        attackMonster.hp -= defenseMonster.attack;
        defenseMonster.hp -= attackMonster.attack;

        Debug.Log("전투 : " + attackMonster.ToString() + ":" + defenseMonster.ToString());


        if (attackMonster.hp > 0)
            attackMonster.renewal();
        else
            attack.deathMonster(attackMonster);

        if (defenseMonster.hp > 0)
            defenseMonster.renewal();
        else
            Defensse.deathMonster(defenseMonster);

        if (attack.battleIndex < attack.monsterList.Count-1)
            attack.battleIndex++;
        else
            attack.battleIndex = 0;


        return true;

    }


}
