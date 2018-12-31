using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour {
    static private int SCORE = 0;
    [SerializeField] int playerLife = 3;

    static public int GetScore () {
        return SCORE;
    }

    static public void AddScore(int point) {
        SCORE += point;
    }

    public int GetPlayerLife () {
        return playerLife;
    }

    public void SetPlayerLife (int life) {
        playerLife = life;
    }

}