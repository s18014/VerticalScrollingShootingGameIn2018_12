using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletCollider : MonoBehaviour {
    private BulletStatus bulletStatus;
    private PlayerBulletDestroyer destroyer;
    private PlayerBulletEffecter effecter;
    private bool isHit = false;

    private void Awake () {
        bulletStatus = GetComponent<BulletStatus>();
        destroyer = GetComponent<PlayerBulletDestroyer>();
        effecter = GetComponent<PlayerBulletEffecter>();
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
            ApplyDamage(collision);
            effecter.MakeSpark(collision.bounds.ClosestPoint(transform.position));
            destroyer.DoDestroy();
        }
    }



    private void ApplyDamage (Collider2D collision) {
        collision.gameObject.GetComponent<IDamageable>().ApplyDamage(bulletStatus.GetPower());
    }
}