using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionAnime : MonoBehaviour {
    [SerializeField] bool applyChildren = true;
    private List<SpriteRenderer> SRs = new List<SpriteRenderer>();

    private void Awake () {
        var sr = GetComponent<SpriteRenderer>();
        if (sr != null) SRs.Add(sr);
        if (applyChildren) {
            foreach (Transform child in Util.GetAllChildren(transform.transform)) {
                sr = child.GetComponent<SpriteRenderer>();
                if (sr != null) {
                    SRs.Add(sr);
                }
            }
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // 親オブジェクトのみ点滅アニメーション
    public void Flashing() {
        if (SRs.Count <= 0) return;
        StartCoroutine("IEFlashing");
    }

    IEnumerator IEFlashing () {
        foreach (SpriteRenderer sr in SRs) {
            sr.color = new Color(0f, 0f, 255f);
        }
        yield return new WaitForSeconds(0.01f);
        foreach (SpriteRenderer sr in SRs) {
            sr.color = new Color(255f, 255f, 255f);
        }
    }

}
