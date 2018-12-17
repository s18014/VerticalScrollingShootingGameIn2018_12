using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWideShooterManager : MonoBehaviour, IShotable {
    private int level = 0;
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

    public void setLevel (int newLevel) {
        if (newLevel < 0) newLevel = 0;
        if (newLevel > 2) newLevel = 2;
        level = newLevel;
    }

    public void shot () {
        shooters[level].GetComponent<IShotable>().shot();
    }

}
