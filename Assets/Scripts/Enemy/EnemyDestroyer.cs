using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour, IDestroyable {
    [SerializeField] GameObject explosionPrefab;
    bool isDead = false;
    private Vector2 min;
    private Vector2 max;
    private Vector2 size;

    private void Awake() {
        // 画面左下端と右上端を取得
        min = Camera.main.ViewportToWorldPoint(Vector2.zero);
        max = Camera.main.ViewportToWorldPoint(Vector2.one);
        size = GetComponent<EnemyStatus>().GetSize();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        IsOutOfRange();
	}

    void IsOutOfRange() {
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

    public void DoDestroy () {
        if (isDead) return;
        isDead = true;
        MakeExplosion();
        Destroy(gameObject);
    }

    private void MakeExplosion() {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
    }
}
