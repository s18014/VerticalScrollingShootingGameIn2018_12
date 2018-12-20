using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour, IDamageable {
    [SerializeField] float hp = 100;
    [SerializeField] GameObject explosionPrefab;
    private EnemyAnimation enemyAnimation;

    private void Awake () {
        enemyAnimation = GetComponent<EnemyAnimation>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ApplyDamage(float point) {
        enemyAnimation.Flashing();
        hp -= point;
        if (hp < 0) {
            MakeExplosion();
            Destroy(gameObject);
        }
    }

    private void MakeExplosion() {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
    }
}
