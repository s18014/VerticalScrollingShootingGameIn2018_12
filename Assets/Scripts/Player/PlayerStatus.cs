using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour {
    [SerializeField] int weponLevel = 0;

    public int GetWeponLevel () {
        return weponLevel;
    }
}
