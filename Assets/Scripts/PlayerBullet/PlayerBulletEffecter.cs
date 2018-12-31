using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletEffecter : MonoBehaviour {
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

    public void MakeSpark(Vector2 point) {
        if (effectGroup.transform.childCount < 50) {
            point.x += Random.Range(-0.1f, 0.1f);
            point.y += Random.Range(-0.1f, 0.1f);
            var obj = (GameObject)Instantiate(SparkPrefab, point, Quaternion.identity);
            obj.transform.parent = effectGroup.transform;
        }
    }
}
