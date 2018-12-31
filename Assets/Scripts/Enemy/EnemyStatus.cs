using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour {
    [SerializeField] float hp = 100f;
    [SerializeField] int score = 500;
    [SerializeField] Vector2 size = Vector2.zero;
    private LineRenderer line;

    private void Awake () {
        gameObject.AddComponent<LineRenderer>();
        line = GetComponent<LineRenderer>();
    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        TestShowSize();
    }

    public Vector2 GetSize () {
        return size;
    }

    public float GetHp () {
        return hp;
    }

    public int GetScore () {
        return score;
    }

    public void SetHp (float point) {
        hp = point;
    }

    public void TestShowSize () {
        line.startWidth = 0.05f;
        line.endWidth = 0.05f;
        Vector2 pos = transform.position;
        line.positionCount = 5;
        line.SetPosition(0, pos - new Vector2(size.x / 2f, -size.y / 2f));
        line.SetPosition(1, pos - new Vector2(-size.x / 2f, -size.y / 2f));
        line.SetPosition(2, pos - new Vector2(-size.x / 2f, size.y / 2f));
        line.SetPosition(3, pos - new Vector2(size.x / 2f, size.y / 2f));
        line.SetPosition(4, pos - new Vector2(size.x / 2f, -size.y / 2f));
    }

}