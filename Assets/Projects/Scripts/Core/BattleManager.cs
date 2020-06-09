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

    public float BattleSpeed =1; 

    // Use this for initialization
    void Start()
    {
        attacker = player;
        defenser = enemy;

        attacker.BattleReady();
        defenser.BattleReady();

    }

    // Update is called once per frame
    float Timetick;
    void Update()
    {
        if (playBattle)
        {
            Timetick += Time.deltaTime;

            if (Timetick > BattleSpeed)
            {
                Timetick = 0;
                playBattle = Battle(attacker, defenser);
                Battler temp = attacker;
                attacker = defenser;
                defenser = temp;
            }            
        }
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
    private bool Attack(Battler attack, Battler Defensse)
    {
        Monster attackMonster = attack.GetAttackMonster();
        Monster defenseMonster = Defensse.GetDefenseMonst();

        if (attackMonster == null || defenseMonster == null)
        {
            Debug.Log("BattleManager Attack Error");
            return false;
        }

        Debug.Log("전투 : " + attackMonster.ToString() + ":" + defenseMonster.ToString());

        if (attackMonster.divineShieldCount > 0 )
        {
            Debug.Log("천상의 보호막 " + attackMonster.ToString());
            attackMonster.divineShieldCount --;
        }
        else
        {
            if (defenseMonster.poisonous)
            {
                Debug.Log("독성 " + defenseMonster.ToString());
                attackMonster.hp = 0;
            }
                
            else
                attackMonster.hp -= defenseMonster.attack;
        }

        if(defenseMonster.divineShieldCount > 0)
        {
            Debug.Log("천상의 보호막 " + defenseMonster.ToString());
            defenseMonster.divineShieldCount--;
        }
        else
        {
            if (attackMonster.poisonous)
            {
                defenseMonster.hp = 0;
                Debug.Log("독성 " + attackMonster.ToString());
            }
                
            else
                defenseMonster.hp -= attackMonster.attack;
        }

        if (attackMonster.hp > 0)
            attackMonster.renewal();
        else
            attack.deathMonster(attackMonster);

        if (defenseMonster.hp > 0)
            defenseMonster.renewal();
        else
            Defensse.deathMonster(defenseMonster);

        return true;
    }


}
