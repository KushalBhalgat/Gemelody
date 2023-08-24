using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyKiller : MonoBehaviour
{
    // Start is called before the first frame update
    public event EventHandler OnGemClicked;
    void Start()
    {
        timer = 0f;
    }

    private float timer;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 2f) {
            timer = 0f;
           Destroy(this.gameObject); 
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.TryGetComponent<AnimationScript>(out AnimationScript animationScript)){
            MenuEffectsSpawner.Instance.hitObject = collision.gameObject;
            MenuEffectsSpawner.Instance.hitObjectPosition = collision.gameObject.transform.position;
            MenuEffectsSpawner.Instance.hitObjectRotation= collision.gameObject.transform.rotation;
            MenuEffectsSpawner.Instance.hitIndex = MenuUIManager.currCheckpoint;
            MenuEffectsSpawner.Instance.PlayEnemyTouchEffect(collision.gameObject.transform.position);
            Destroy(collision.gameObject);
        }
    }
}
