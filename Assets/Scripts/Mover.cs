using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
    private Rigidbody2D rigidbody2d;
    private float speed = 0f;
    private float acceleration = 0f;
    private float angle = 0f;
    private Vector2 direction = Vector2.zero;

    private void Awake () {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {
        CalcVelocity();
    }

    private void CalcVelocity () {
        direction = Quaternion.Euler(0f, 0f, angle * Time.deltaTime) * direction;
        speed += acceleration * Time.deltaTime;
        rigidbody2d.velocity = direction * speed;
    }

    public void Set (Vector2 dir, float speed, float accel, float angle) {
        this.direction = dir;
        this.speed = speed;
        this.acceleration = accel;
        this.angle = angle;
    }

    public void SimpleMove (Vector2 dir, float speed) {
        this.speed = speed;
        this.direction = dir;
    }

    public void ShiftMove (Vector2 dir, float firstSpeed, float secondSpeed, float shiftTime) {
        StartCoroutine(IEShiftMove(dir, firstSpeed, secondSpeed, shiftTime));
    }

    public void AccelMove (Vector2 dir, float speed, float accel) {
        this.speed = speed;
        this.direction = dir;
        this.acceleration = accel;
    }

    IEnumerator IEShiftMove (Vector2 dir, float firstSpeed, float secondSpeed, float shiftTime) {
        this.speed = firstSpeed;
        this.direction = dir;
        yield return new WaitForSeconds(shiftTime);
        this.speed = secondSpeed;
    }
}
