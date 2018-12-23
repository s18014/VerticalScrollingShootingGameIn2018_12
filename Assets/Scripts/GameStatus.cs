using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour {
    private float SCORE = 0f;

    public float GetScore () {
        return SCORE;
    }

    public void AddScore (float point) {
        SCORE += point;
    }


}
