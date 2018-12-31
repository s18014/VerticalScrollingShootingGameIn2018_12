using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShotType {
    Simple,
    Accel,
    Shift
}

public class EnemyShooter : MonoBehaviour {
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float directionAngle = -90f;
    [SerializeField] float rotate = 0f;
    [SerializeField] float randomAngle = 0f;
    [SerializeField] float speed = 3f;
    [SerializeField] int nWay = 1;
    [SerializeField] float angleRange = 0f;
    [SerializeField] int firePerOnce = 1;
    [SerializeField] float interval = 1f;
    [SerializeField] float beginDelay = 0f;
    [SerializeField] float delay = 0f;
    [SerializeField] int times = 1;
    [SerializeField] ShotType type;
    [SerializeField] float acceleration = 0f;
    [SerializeField] float secondSpeed = 3f;
    [SerializeField] float shiftTime = 1f;
    [SerializeField] bool isFollow = false;
    private GameObject player;
    private float tmpDirectionAngle;
    private int fireCount;
    private float intervalCount;
    private float beginDelayCount;
    private float delayCount;
    private int restTimes;

    private void Awake() {
        player = GameObject.FindWithTag("Player");
    }

    // Use this for initialization
    void Start() {
        Init();
    }

    // Update is called once per frame
    void Update() {
        beginDelayCount += Time.deltaTime;
        intervalCount += Time.deltaTime;
        delayCount += Time.deltaTime;
        tmpDirectionAngle += rotate * Time.deltaTime;

        if (restTimes == 0) return;
        if (beginDelayCount < beginDelay) return;
        if (delayCount < delay) {
            intervalCount = 0f;
            return;
        }
        if (fireCount <= 0) {
            fireCount = firePerOnce;
            intervalCount = 0f;
            delayCount = 0f;
            restTimes -= 1;
            return;
        }
        if (intervalCount < interval) return;
        if (isFollow && player.gameObject != null) tmpDirectionAngle = Util.GetAngle(player.transform.position);
        NWayShot();
        intervalCount = 0f;
        fireCount -= 1;
    }

    public void Init () {
        tmpDirectionAngle = directionAngle;
        fireCount = firePerOnce;
        intervalCount = interval;
        beginDelayCount = 0f;
        delayCount = delay;
        restTimes = times;
    }

    private void NWayShot() {
        for (int i = 0; i < nWay; i++) {
            var offset = Mathf.Floor(nWay / 2f);
            if ((int)nWay % 2 == 0) offset -= 0.5f;
            float angle = (i - offset) * angleRange + tmpDirectionAngle + Random.Range(-randomAngle / 2f, randomAngle / 2f);
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0f, 0f, angle + 90f));
            Mover mover = bullet.GetComponent<Mover>();
            switch (type) {
                case ShotType.Accel:
                    mover.AccelMove(Util.GetDirection(angle), speed, acceleration);
                    break;
                case ShotType.Shift:
                    mover.ShiftMove(Util.GetDirection(angle), speed, secondSpeed, shiftTime);
                    break;
                default:
                    mover.SimpleMove(Util.GetDirection(angle), speed);
                    break;
            }
        }
    }

}