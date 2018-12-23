using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWideShooter : MonoBehaviour, IShotable {
    [SerializeField] GameObject wideBulletPrefab;
    [SerializeField] float speed = 30f;
    [SerializeField] float delayTime = 0.03f;
    [SerializeField] float nWay = 4f;
    private Vector2 playerSize;
    private Vector2 prefabSize;
    private float exTime = 0f;

    private void Awake () {
        playerSize = GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>().size;
        prefabSize = wideBulletPrefab.GetComponent<SpriteRenderer>().size;
    }

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {

    }
    public void shot () {
        if (!isShotable()) return;
        for (int i = 0; i < nWay; i++) {
            var offset = Mathf.Floor(nWay / 2f);
            if ((int)nWay % 2 == 0) offset -= 0.5f;
            var angle = new Vector3 (0f, 0f, (i - offset) * -3f);
            Vector2 pos = transform.position;
            pos.y += playerSize.y - Mathf.Abs(i - offset) / 15f;
            pos.x += (i - offset) * prefabSize.x / 2f;
            GameObject bullet = Instantiate(wideBulletPrefab, pos, Quaternion.Euler(angle));
            BulletMover mover = bullet.GetComponent<BulletMover>();
            mover.SimpleMove(Quaternion.Euler(angle) * Vector2.up, speed);
        }
    }

    private bool isShotable () {
        if (Time.time - exTime > delayTime) {
            exTime = Time.time;
            return true;
        }
        return false;
    }
}