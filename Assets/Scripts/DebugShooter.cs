using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugShooter : MonoBehaviour {
    BulletMover bulletMover;

    private void Awake() {
        bulletMover = GetComponent<BulletMover>();
    }

    // Use this for initialization
    void Start () {
        bulletMover.set(10f);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.Space)) {
            bulletMover.AccelMove(Vector2.up, 10f);
        }
    }

}
