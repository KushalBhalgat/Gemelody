using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuboid : MonoBehaviour,ICollectible
{
    private float dieTimer = 5f; 
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

        if (scaleTimer <= 1f) {
            currScale = Vector3.Lerp(transform.localScale, targetScale, scaleTimer);
            transform.localScale = currScale;
        }
        else if (scaleTimer > 4f) {
            targetScale = Vector3.zero;
            currScale = Vector3.Lerp(transform.localScale, targetScale, (scaleTimer - 4f));
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
            GameManager.Instance.score += 1;
            collisionFlag = false;
            Destroy(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }
}
