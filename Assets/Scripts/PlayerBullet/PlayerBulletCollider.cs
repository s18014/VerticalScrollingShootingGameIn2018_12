using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletCollider : MonoBehaviour {
    [SerializeField] GameObject SparkPrefab;
    private GameObject effectGroup;

    private void Awake() {
        effectGroup = GameObject.Find("SparkEffectGroup");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Enemy") {
            if (effectGroup.transform.childCount < 20) {
                Vector2 hitPos = collision.bounds.ClosestPoint(transform.position);
                hitPos.x *= Random.Range(0.9f, 1.1f);
                hitPos.y *= Random.Range(0.9f, 1.1f);
                var obj = (GameObject)Instantiate(SparkPrefab, hitPos, Quaternion.identity);
                obj.transform.parent = effectGroup.transform;
            }
            Destroy(gameObject);
        }
    }
}
