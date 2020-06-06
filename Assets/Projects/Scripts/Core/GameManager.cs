using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameTurn { 
    Buy,Battle
}

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager instance {
        get {
            if (_instance==null) {
                _instance=FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }

    public GameTurn gameTurn;
}
