using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour {
    private Rigidbody2D rigidbody2d;
    private float speed = 0f;
    private float acceleration = 0f;
    private Vector2 direction = Vector2.zero;

    private void Awake () {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {
        calcVelocity();
	}

    // 初期化関数
    public void set (float speed) {
        this.speed = speed;
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
