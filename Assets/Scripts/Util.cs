using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static List<Transform> GetAllChildren (Transform parent) {
        List<Transform> children = new List<Transform>();
        RecursiveGetChildren(parent, children);
        return children;
    }

    private static void RecursiveGetChildren (Transform parent, List<Transform> list) {
        var children = parent.GetComponentInChildren<Transform>();

        if (children.childCount == 0) {
            return;
        }

        foreach (Transform child in children) {
            list.Add(child);
            RecursiveGetChildren(child, list);
        }
    }

    public static float GetAngle (Vector2 dir) {
        float rot = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (rot > 180) rot -= 360;
        if (rot < -180) rot += 360;
        return rot;
    }

    public static Vector2 GetDirection (float angle) {
        return new Vector2(
            Mathf.Cos(angle * Mathf.Deg2Rad),
            Mathf.Sin(angle * Mathf.Deg2Rad)
            );
    }
}
