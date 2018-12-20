using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStatus : MonoBehaviour {
    [SerializeField] float power = 1f;

    public float GetPower () {
        return power;
    }
}
