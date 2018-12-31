using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour {
    private PlayerStatus status;
    private PlayerDestroyer destroyer;

    private void Awake() {
        status = GetComponent<PlayerStatus>();
        destroyer = GetComponent<PlayerDestroyer>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "PowerUp") {
            Destroy(collision.gameObject);
            if (status.SetWeaponLevel(status.GetWeaponLevel() + 1)) {
                GameStatus.AddScore(1000);
            } else {
                GameStatus.AddScore(4000);
            }
        }

        if (collision.tag == "EnemyBullet") {
            destroyer.DoDestroy();
            collision.GetComponent<IDestroyable>().DoDestroy();
        }
    }
}
