using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipsManager : MonoBehaviour {
    private enum equipType {
        NarrowShooter,
        WideShooter,
        Bomb
    }
    private List<Transform> weapons = new List<Transform>();

    private void Awake() {
        foreach (Transform child in transform) {
            Debug.Log(child.name);
            weapons.Add(child);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LevelUpdate (int newLevel) {
        weapons[(int)equipType.NarrowShooter].GetComponent<PlayerNarrowShooterManager>().setLevel(newLevel);
    }

    public void NarrowShot () {
        weapons[(int)equipType.NarrowShooter].GetComponent<IShotable>().shot();
    }

    public void WideShot () {
        weapons[(int)equipType.WideShooter].GetComponent<IShotable>().shot();
    }

}
