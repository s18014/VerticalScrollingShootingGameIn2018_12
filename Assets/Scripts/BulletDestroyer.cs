using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroyer : MonoBehaviour {
    private Vector2 min;
    private Vector2 max;
    private Vector2 size;

    private void Awake () {
        // 画面左下端と右上端を取得
        min = Camera.main.ViewportToWorldPoint(Vector2.zero);
        max = Camera.main.ViewportToWorldPoint(Vector2.one);
        size = GetComponent<SpriteRenderer>().size;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        IsOutOfRange();
	}

    void IsOutOfRange () {
        // 規定の範囲外かチェック
        Vector2 pos = transform.position;
        if (pos.y < min.y - size.y / 2f ||
            pos.y > max.y + size.y / 2f ||
            pos.x < min.x - size.x / 2f ||
            pos.x > max.x + size.x / 2f
            ) {
            Destroy(gameObject);
        }
    }

    public void ExpendArea (float range) {
        // Destroy Area を拡大
        min = new Vector2(min.x - range, min.y - range);
        max = new Vector2(max.x + range, max.y + range);
    }

}
