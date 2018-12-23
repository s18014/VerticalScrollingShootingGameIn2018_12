using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour {
    private Vector2 min;
    private Vector2 max;
    private Vector2 size;
    private float top;
    private float speed;
    private  Rigidbody2D rigidbody2d;

    private void Awake() {
        // 画面左下端と右上端を取得
        min = Camera.main.ViewportToWorldPoint(Vector2.zero);
        max = Camera.main.ViewportToWorldPoint(Vector2.one);
        rigidbody2d = GetComponent<Rigidbody2D>();
        size = GetComponent<SpriteRenderer>().size;
    }

    // Use this for initialization
    void Start () {
        rigidbody2d.velocity = Vector2.down * 2f;
	}
	
	// Update is called once per frame
	void Update () {
        GetPosition();
        if (top < max.y) {
            rigidbody2d.velocity = Vector2.zero;
        }
    }

    void GetPosition () {
        Vector2 pos = transform.position;
        top = pos.y + size.y / 2f;
    }
}