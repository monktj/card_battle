using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameDatabase : ScriptableObject
{
    public static GameDatabase instance {
        get {
            if (_instance==null) {
                _instance= Resources.Load<GameDatabase>("GameDatabase");
            }
            return _instance;
        }
    }
    private static GameDatabase _instance;

    public List<Card> cards = new List<Card>();
}
