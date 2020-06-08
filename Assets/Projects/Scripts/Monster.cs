using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//테스트 시안 입니다.

 // 구현해야할 List  
 // 기본상태  도발/천보/독성
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

    //위치를 가져와야하나 ? 

    void Start()
    {
        attackText.text = attack.ToString();
        hpText.text = hp.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void renewal()
    {
        attackText.text = attack.ToString();
        hpText.text = hp.ToString();
    }
}

