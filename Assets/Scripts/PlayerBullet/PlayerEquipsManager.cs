using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipsManager : MonoBehaviour {
    private PlayerNarrowShooterManager PNSM;
    private PlayerWideShooterManager PWSM;

    private void Awake () {
        PNSM = transform.Find("PlayerNarrowShooterManager").GetComponent<PlayerNarrowShooterManager>();
        PWSM = transform.Find("PlayerWideShooterManager").GetComponent<PlayerWideShooterManager>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NarrowShot (int level) {
        PNSM.shot(level);
    }

    public void WideShot (int level) {
        PWSM.shot(level);
    }

}
