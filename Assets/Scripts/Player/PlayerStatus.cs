using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour, IDamageable {
    [SerializeField] int weponLevel = 0;

    public int GetWeponLevel () {
        return weponLevel;
    }

    public void ApplyDamage (float point) {
    }
}
