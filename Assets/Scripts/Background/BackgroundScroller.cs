using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour {
    private Vector2 min;
    private Vector2 max;
    private Vector2 center;
    private Vector2 size;
    private Vector2 maxTop;
    private Vector2 minBottom;
    private float speed = 0.5f;
    private  Rigidbody2D rigidbody2d;

    private void Awake() {
        // 画面左下端と右上端を取得
        min = Camera.main.ViewportToWorldPoint(Vector2.zero);
        max = Camera.main.ViewportToWorldPoint(Vector2.one);
        center = Camera.main.ViewportToWorldPoint(new Vector2(0.5f, 0.5f));
        rigidbody2d = GetComponent<Rigidbody2D>();
        size = GetComponent<SpriteRenderer>().size;
    }

    // Use this for initialization
    void Start () {
        SetLimit();
        transform.position = minBottom;
        rigidbody2d.velocity = Vector2.down * speed; 
	}
	
	// Update is called once per frame
	void Update () {
        if (maxTop.y > transform.position.y) {
            transform.position = maxTop;
            rigidbody2d.velocity = Vector2.zero;
        }
    }

    private void SetLimit () {
        Vector2 pos = transform.position;
        pos.x = center.x;

        pos.y = max.y - size.y / 2f;
        maxTop = pos;
        pos.y = min.y + size.y / 2f;
        minBottom = pos;
    }
}