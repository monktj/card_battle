using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//테스트 시안 입니다.

 // 구현해야할 List  
 // 종특 할건지/
 // 기본상태  도발/천보/독성/질풍
 // 특수상태관련 전투의 함성 / 죽음의 메아리

  
public class Monster : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMesh attackText, hpText, TypeText;

    int uid;
    private int defaultHp,defaultAttack;
    public int attack ;
    public int hp ;
    int Mana;

    public int divineShieldCount = 0;
    public int windfuryAttackCount = 0;
    
    /// <summary>
    /// 현재는 bool값으로 처리 특수능 관련 클래스 구상중 
    /// 도발(Taunt)
    /// 무적(DivineShield)
    /// 독성(Poisonous)
    /// 질풍(Windfury)
    /// </summary>
    /// 
    public bool taunt = false;
    public bool divineShield = false;  
    public bool poisonous = false;
    public bool windfury = false;

    void Start()
    {
        attackText.text = attack.ToString();
        hpText.text = hp.ToString();
    }

    public void BattleSet()
    {
        if (divineShield)
            divineShieldCount = 1;

        if (windfury)
            windfuryAttackCount = 1;
    }

    public void renewal()
    {
        attackText.text = attack.ToString();
        hpText.text = hp.ToString();
    }
}

