using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEnemySpawnSync : AudioSyncer
{
    /*
    
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private SpawnAreaSO[] spawnAreaSOArray;
    [SerializeField] private float enemyDieTimer;
    private float timer = 0f;


    private Vector3 currScale=Vector3.one*0.1f;
    private Vector3 targetScale=Vector3.one;

    private int beatCount;
    private int restCount;
    private int onScreenEnemyCount;

    void Start() {
        currScale = Vector3.one * 0.1f;
        targetScale = Vector3.one;
        enemyDieTimer = 3f; 
    }
    
    public override void OnUpdate() {
        base.OnUpdate();
        if (isBeat) { return; }
        if (enemyDieTimer <= 0) { enemyDieTimer = 3f; }
        enemyDieTimer -= Time.deltaTime;
        while (onScreenEnemyCount <= 6) { Instantiate(enemyPrefab, GetRandomSpawnPosition(spawnAreaSOArray), Quaternion.identity); }
    }

    public override void RegisterBeat() {
        base.RegisterBeat();
        float _timer = 0;
        while (_timer < timeToBeat) {
            Transform enemy=Instantiate(enemyPrefab, GetRandomSpawnPosition(spawnAreaSOArray), Quaternion.identity).transform;
            currScale = Vector3.Lerp(currScale, targetScale, _timer / timeToBeat);
            enemy.localScale = currScale;
            _timer += Time.deltaTime;
        }
        isBeat = false;
        Instantiate(enemyPrefab, GetRandomSpawnPosition(spawnAreaSOArray), Quaternion.identity);
    }

    private Vector3 GetRandomSpawnPosition(SpawnAreaSO[] spawnAreaSOArray) {
        Vector3 spawnPosition = Vector3.zero;
        spawnPosition.z = 0f;
        SpawnAreaSO chosenSpawnArea = spawnAreaSOArray[UnityEngine.Random.Range(0, 3)];
        if (chosenSpawnArea.fixedX != -1000f) {
            spawnPosition.x = chosenSpawnArea.fixedX;
            spawnPosition.y = UnityEngine.Random.Range(chosenSpawnArea.bound1, chosenSpawnArea.bound2);
        }
        else {
            spawnPosition.x = UnityEngine.Random.Range(chosenSpawnArea.bound1, chosenSpawnArea.bound2);
            spawnPosition.y = chosenSpawnArea.fixedY;
        }
        return spawnPosition;
    }
    */
}
