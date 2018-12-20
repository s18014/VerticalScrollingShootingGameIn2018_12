using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour {
    private PlayerStatus status;

    private void Awake() {
        status = GetComponent<PlayerStatus>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "PowerUp") {
            Destroy(collision);
        }
    }
}
