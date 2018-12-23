using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNarrowShooter : MonoBehaviour, IShotable {
    [SerializeField] GameObject greenBulletPrefab;
    [SerializeField] float speed = 30f;
    [SerializeField] float delayTime = 0.01f;
    [SerializeField] float nWay = 3f;
    private Vector2 playerSize;
    private Vector2 prefabSize;
    private float exTime = 0f;

    private void Awake () {
        playerSize = GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>().size;
        prefabSize = greenBulletPrefab.GetComponent<SpriteRenderer>().size;
    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void shot () {
        if (!isShotable()) return;
        for (int i = 0; i< nWay; i++) {
            var offset = Mathf.Floor(nWay / 2f);
            if ((int)nWay % 2 == 0) offset -= 0.5f;
            Vector2 pos = transform.position;
            pos.y += playerSize.y - Mathf.Abs(i - offset) / 10f;
            pos.x += (i - offset) * prefabSize.x / 1.5f;
            GameObject bullet = Instantiate(greenBulletPrefab, pos , Quaternion.Euler(0, 0, 0));
            BulletMover mover = bullet.GetComponent<BulletMover>();
            mover.SimpleMove(Vector2.up, speed);
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
