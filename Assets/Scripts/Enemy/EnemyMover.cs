using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : Mover {

    private void Start() {
        SimpleMove(Vector2.down, 1f);
    }

    private void Update() {
        CalcVelocity();
    }
}
