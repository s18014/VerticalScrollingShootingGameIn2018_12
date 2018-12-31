using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour {
    private Vector2 min;
    private Vector2 max;
    private Vector2 size;
    private Mover mover;
    [SerializeField] float speed = 1f;

    // Use this for initialization

    private void Awake () {
        // 画面左下端と右上端を取得
        min = Camera.main.ViewportToWorldPoint(Vector2.zero);
        max = Camera.main.ViewportToWorldPoint(Vector2.one);
        size = GetComponent<SpriteRenderer>().size;
        mover = GetComponent<Mover>();
    }

    void Start () {
    }

    // Update is called once per frame
    void Update () {
	}

    void RestrictMovement () {
        // 画面外に行かないようにする処理
        Vector2 pos = transform.position;
        if (pos.y < min.y + size.y / 2f) {
            pos.y = min.y + size.y / 2f;
        }
        if (pos.y > max.y - size.y / 2f) {
            pos.y = max.y - size.y / 2f;
        }

        if (pos.x < min.x + size.x / 2f) {
            pos.x = min.x + size.x / 2f;
        }
        if (pos.x > max.x - size.x / 2f) {
            pos.x = max.x - size.x / 2f;
        }
        transform.position = pos;
    }

   
    public void Move (Vector2 direction) {
        mover.SimpleMove(direction, speed);
        RestrictMovement();
    }
}
