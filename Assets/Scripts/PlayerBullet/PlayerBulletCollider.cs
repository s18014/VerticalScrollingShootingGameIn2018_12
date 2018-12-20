using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletCollider : MonoBehaviour {
    [SerializeField] GameObject SparkPrefab;
    private GameObject effectGroup;
    private BulletStatus bulletStatus;
    private bool isHit = false;

    private void Awake () {
        effectGroup = GameObject.Find("SparkEffectGroup");
        bulletStatus = GetComponent<BulletStatus>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D (Collider2D collision) {
        if (collision.gameObject.tag == "Enemy" && !isHit) {
            isHit = true;
            MakeSpark(collision, 50);
            ApplyDamage(collision);
            Destroy(gameObject);
        }
    }

    private void MakeSpark (Collider2D collision, int max) {
        if (effectGroup.transform.childCount < max) {
            Vector2 hitPos = collision.bounds.ClosestPoint(transform.position);
            hitPos.x += Random.Range(-0.1f, 0.1f);
            hitPos.y += Random.Range(-0.1f, 0.1f);
            var obj = (GameObject)Instantiate(SparkPrefab, hitPos, Quaternion.identity);
            obj.transform.parent = effectGroup.transform;
        }
    }

    private void ApplyDamage (Collider2D collision) {
        collision.gameObject.GetComponent<IDamageable>().ApplyDamage(bulletStatus.GetPower());
    }
}
