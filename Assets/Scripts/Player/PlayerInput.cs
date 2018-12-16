using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
    private enum equipType {
        NarrowShooter,
        WideShooter,
        Bomb
    }
    private PlayerMover playerMover;
    private List<Transform> equips = new List<Transform>();

    private void Awake() {
        playerMover = GetComponent<PlayerMover>();
        foreach (Transform child in transform.Find("PlayerEquips").transform) {
            equips.Add(child);
        }
    }

    // Use this for initialization
    void Start () {
	}

    // Update is called once per frame
    void Update () {
        Move();
        shot();
    }

    void Move() {
        Vector2 dir = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.UpArrow)) {
            dir += Vector2.up;
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            dir += Vector2.down;
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            dir += Vector2.right;
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            dir += Vector2.left;
        }
        playerMover.Move(dir.normalized);
    }

    void shot () {
        if (Input.GetKey(KeyCode.Space)) {
            equips[(int)equipType.NarrowShooter].GetComponent<IShotable>().shot();
        }
    }

}
