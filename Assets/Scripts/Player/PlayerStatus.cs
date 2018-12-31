using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour {
    [SerializeField] int maxWeaponLevel = 2;
    [SerializeField] int maxBombNum = 5;
    [SerializeField] int bombNum = 3;
    private int weaponLevel = 0;

    private void Awake() {
    }

    public int GetMaxWeaponLevel () {
        return maxWeaponLevel;
    }

    public int GetWeaponLevel () {
        return weaponLevel;
    }

    public int GetMaxBombNum () {
        return maxBombNum;
    }

    public int GetBombNum () {
        return bombNum;
    }


    public bool SetWeaponLevel (int level) {
        weaponLevel = level;
        if (weaponLevel > maxWeaponLevel) {
            weaponLevel = maxWeaponLevel;
            return false;
        } else {
            return true;
        }
    }

    public bool SetBombNum (int num) {
        bombNum = num;
        if (bombNum > maxBombNum) {
            bombNum = maxBombNum;
            return false;
        } else {
            return true;
        }
    }
}
