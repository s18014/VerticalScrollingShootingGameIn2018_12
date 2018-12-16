using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour {
    private Vector2 min;
    private Vector2 max;
    private Vector2 size;
    private Rigidbody2D rigidbody2d;
    [SerializeField] float speed = 1;

    // Use this for initialization

    private void Awake() {
        // 画面左下端と右上端を取得
        min = Camera.main.ViewportToWorldPoint(Vector2.zero);
        max = Camera.main.ViewportToWorldPoint(Vector2.one);
        size = GetComponent<SpriteRenderer>().size;
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Start () {
    }

    // Update is called once per frame
    void Update () {
	}

    void RestrictMovement () {
        // 画面外に行かないようにする処理
        Vector2 pos = transform.position;
        if (pos.y < min.y + size.y / 2) {
            pos.y = min.y + size.y / 2;
        }
        if (pos.y > max.y - size.y / 2) {
            pos.y = max.y - size.y / 2;
        }

        if (pos.x < min.x + size.x / 2) {
            pos.x = min.x + size.x / 2;
        }
        if (pos.x > max.x - size.x / 2) {
            pos.x = max.x - size.x / 2;
        }
        transform.position = pos;
    }

   
    public void Move (Vector2 direction) {
        rigidbody2d.velocity = direction * speed;
        RestrictMovement();
    }
}
