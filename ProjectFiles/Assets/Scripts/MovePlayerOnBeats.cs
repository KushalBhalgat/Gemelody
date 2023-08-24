using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerOnBeats : AudioSyncer {

    [SerializeField] private SpawnAreaSO[] spawnAreaSOArray;
    private Vector3 lerpingCoordinates;
    private float lerpingTimer;
    private bool lerpFlag;
    private float playerVelocity;
    private Vector3 targetDir;

    private void Start() {
        lerpingTimer = 0f;
        lerpFlag = false;
        lerpingCoordinates = transform.position;
        targetDir = transform.position;
    }

    public override void OnUpdate() {
        base.OnUpdate();
        playerVelocity = UnityEngine.Random.Range(1f, 2f);
        if (lerpFlag) {
            if (lerpingTimer < 3f) {
                lerpingTimer += Time.deltaTime;
                transform.position = Vector3.Lerp(transform.position, lerpingCoordinates, Time.deltaTime);
            }
            else { 
                lerpingTimer = 0f;
                lerpFlag = false;
            }
        }
        else {
            transform.Translate(targetDir*Time.deltaTime*playerVelocity);
        }
        if (m_isBeat) { return; }
    }

    public override void OnBeat() {
        base.OnBeat();
        lerpingCoordinates = GetRandomPositionInArea();
        targetDir = lerpingCoordinates-transform.position;
        lerpFlag = true;
        Debug.Log("Beat");
        m_isBeat = false;
    }

    public static Vector3 GetRandomPositionInArea() {
        Vector3 pos;
        pos.x = UnityEngine.Random.Range(-8.1f, 8.3f);
        pos.y = UnityEngine.Random.Range(-4.3f, 4.3f);
        pos.z = 0f;
        return pos;
    }
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Boundary") {
            m_isBeat = true;
        }
    }

    public bool IsABeat() { return m_isBeat; }
}
