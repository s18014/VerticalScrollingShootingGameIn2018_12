using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour {
    private Rigidbody2D rigidbody2d;
    private Vector2 min;
    private Vector2 max;
    private Vector2 size;
    private float speed = 0f;
    private float acceleration = 0f;
    private Vector2 direction = Vector2.zero;

    private void Awake() {
        // 画面左下端と右上端を取得
        min = Camera.main.ViewportToWorldPoint(Vector2.zero);
        max = Camera.main.ViewportToWorldPoint(Vector2.one);
        rigidbody2d = GetComponent<Rigidbody2D>();
        size = GetComponent<SpriteRenderer>().size;
    }

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {
        IsOutOfRange();
        calcVelocity();
	}

    void IsOutOfRange () {
        // 規定の範囲外かチェッ
        Vector2 pos = transform.position;
        if (pos.y < min.y - size.y / 2f ||
            pos.y > max.y + size.y / 2f ||
            pos.x < min.x - size.x / 2f ||
            pos.x > max.x + size.x / 2f
            ) {
            Destroy(gameObject);
        }
    }

    // 初期化関数
    public void set (float speed, float range) {
        this.speed = speed;
        // Destroy Area を拡大
        min = new Vector2(min.x - range, min.y - range);
        max = new Vector2(max.x + range, max.y + range);
    }

    private void calcVelocity () {
        speed += acceleration * Time.deltaTime;
        rigidbody2d.velocity = direction * speed;
    }

    public void SimpleMove (Vector2 dir) {
        this.direction = dir;
    }

    public void ShiftMove (Vector2 dir, float secondSpeed, float shiftTime) {
        StartCoroutine(IEShiftMove(dir, secondSpeed, shiftTime));
    }

    public void AccelMove (Vector2 dir, float accel) {
        direction = dir;
        acceleration = accel;
    }

    IEnumerator IEShiftMove (Vector2 dir, float secondSpeed, float shiftTime) {
        this.direction = dir;
        yield return new WaitForSeconds(shiftTime);
        this.speed = secondSpeed;
    }
}
