using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float dieTimer = 3.5f; 
    private float scaleTimer = 0f;
    private Vector3 targetScale;
    private Vector3 currScale;
    private void Start() {
        targetScale.x = 0.3f; targetScale.y = 0.3f; targetScale.z = 0.3f;
        transform.localScale = Vector3.zero;
    }

    public void KillItself() {
        dieTimer -= Time.deltaTime;
        scaleTimer += Time.deltaTime;

        if (scaleTimer <= 1f) {
            currScale = Vector3.Lerp(transform.localScale, targetScale, scaleTimer);
            transform.localScale = currScale;
        }
        else if (scaleTimer > 2.5) {
            targetScale = Vector3.zero;
            currScale = Vector3.Lerp(transform.localScale, targetScale, (scaleTimer - 2.5f));
            transform.localScale = currScale;
        }
        if (dieTimer <= 0) {
            Destroy(gameObject);
        }
    }

    void Update() {
        KillItself();
    }
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.TryGetComponent<MovePlayer>(out MovePlayer movePlayer)) {
            EffectsSpawner.Instance.PlayEnemyTouchEffect(collision.gameObject.transform.position);
            EnemiesManager.Instance.isEnemyHit = true;
            //UnityEditor.EditorApplication.isPaused = true;
            Destroy(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }
}
