using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNarrowShooterManager : MonoBehaviour {
    private List<Transform> shooters = new List<Transform>();

    private void Awake() {
        foreach (Transform t in transform) {
            shooters.Add(t);
        }
    }

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
	}

    public void shot (int level) {
        if (level < 0) level = 0;
        if (level >= shooters.Count) level = shooters.Count - 1;
        shooters[level].GetComponent<IShotable>().shot();
    }
}
