using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour {
    [SerializeField] GameObject explosionPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DoDestory () {
        MakeExplosion();
        Destroy(gameObject);
    }

    private void MakeExplosion() {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
    }
}
