using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour,ICollectible
{
    private float dieTimer = 3.5f; 
    private float scaleTimer = 0f;
    private Vector3 targetScale;
    private Vector3 currScale;
    private bool collisionFlag = true;



    private void Start() {
        targetScale.x = 0.3f; targetScale.y = 0.3f; targetScale.z = 0.3f;
        transform.localScale = Vector3.zero;
        collisionFlag = true;
    }
    public void KillItself() {
        dieTimer -= Time.deltaTime;
        scaleTimer += Time.deltaTime;

        if (scaleTimer <= 0.5f) {
            currScale = Vector3.Lerp(transform.localScale, targetScale, scaleTimer / 0.5f);
            transform.localScale = currScale;
        }
        else if (scaleTimer > 3) {
            targetScale = Vector3.zero;
            currScale = Vector3.Lerp(transform.localScale, targetScale, (scaleTimer -3f) / 0.5f);
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
        if (collision.gameObject.TryGetComponent<MovePlayer>(out MovePlayer movePlayer) && collisionFlag) {
            GameManager.Instance.score += 2;
            collisionFlag = false;
            Destroy(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }
}
