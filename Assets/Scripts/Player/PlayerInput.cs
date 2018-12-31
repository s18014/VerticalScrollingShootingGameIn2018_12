using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
    private PlayerMover playerMover;
    private PlayerEquipsManager equipsManager;
    private PlayerStatus playerStatus;

    private void Awake () {
        playerMover = GetComponent<PlayerMover>();
        equipsManager = transform.Find("PlayerEquips").GetComponent<PlayerEquipsManager>();
        playerStatus = GetComponent<PlayerStatus>();
    }

    // Use this for initialization
    void Start () {
	}

    // Update is called once per frame
    void Update () {
        Move();
        shot();
    }

    void Move () {
        Vector2 dir = Vector2.zero;
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
        if (Input.GetKey(KeyCode.F)) {
            equipsManager.WideShot(playerStatus.GetWeaponLevel());
        }
        if (Input.GetKey(KeyCode.Space)) {
            equipsManager.NarrowShot(playerStatus.GetWeaponLevel());
        }
    }

}
