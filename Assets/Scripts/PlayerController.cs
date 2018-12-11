using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Vector2 min;
    private Vector2 max;
    private Vector2 size;
    [SerializeField] float speed = 1;
	// Use this for initialization
	void Start () {
        // 画面左下端と右上端を取得
        min = Camera.main.ViewportToWorldPoint(Vector2.zero);
        max = Camera.main.ViewportToWorldPoint(Vector2.one);
        size = GetComponent<SpriteRenderer>().size;
        Debug.Log(size);
        Debug.Log(min);
        Debug.Log(max);
    }

    // Update is called once per frame
    void Update () {
        Control();
        RestrictMovement();
	}

    void RestrictMovement () {
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

    void Control () {
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
        Debug.Log(dir.normalized);
        Move(dir.normalized);
    }

    void Move (Vector2 direction) {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
