using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamager : MonoBehaviour, IDamageable {
    private EnemyStatus status;
    private EnemyDestroyer destroyer;
    private EnemyCollisionAnime anime;
    private bool isDead = false;

    private void Awake() {
        status = GetComponent<EnemyStatus>();
        destroyer = GetComponent<EnemyDestroyer>();
        anime = GetComponent<EnemyCollisionAnime>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ApplyDamage (float point) {
        if (isDead) return;
        GameStatus.AddScore((int)point);
        anime.Flashing();
        status.SetHp(status.GetHp() - point);
        if (status.GetHp() <= 0) {
            isDead = true;
            GameStatus.AddScore(status.GetScore());
            destroyer.DoDestroy();
        }
    }
}
