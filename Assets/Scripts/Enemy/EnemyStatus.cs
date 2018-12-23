using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour, IDamageable {
    [SerializeField] float hp = 100;
    [SerializeField] Vector2 size = Vector2.zero;
    private EnemyDestroyer destroyer;
    private LineRenderer line;

    private void Awake () {
        destroyer = GetComponent<EnemyDestroyer>();
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

    public void ApplyDamage(float point) {
        hp -= point;
        if (hp < 0) {
            destroyer.DoDestory();
        }
    }
}
