using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour {
    private SpriteRenderer SP;

    private void Awake () {
        SP = GetComponent<SpriteRenderer>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Flashing () {
        StartCoroutine("IEFlashing");
    }

    IEnumerator IEFlashing () {
        SP.color = new Color(255f, 0f, 0f); 
        yield return new WaitForSeconds(0.1f);
        SP.color = new Color(255f, 255f, 255f);
    }
}
