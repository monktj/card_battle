using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType 
{
    Minion=0,
    Magic=1,
    Weapon=2
}

[System.Serializable]
public class Card 
{
    public string uid;
    public string name;
    public int price;
    public int type;
    public CardType cardType => (CardType)type;
    public int grade;
    public Sprite texture;
}
