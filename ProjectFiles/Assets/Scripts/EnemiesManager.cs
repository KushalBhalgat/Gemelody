using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class EnemiesManager : MonoBehaviour
{
    public static EnemiesManager Instance;
    public bool isEnemyHit = false;

    public event EventHandler OnEnemyHit;
    [SerializeField] private float WaitBeforeNextEnemy;
    [SerializeField] private CollectibleSO[] enemiesSOArray;
    private float enemyTimer;
    private int enemyOnScreen;
    private void Awake() {
        Instance = this;
    }
    void Start()
    {
        enemyTimer = -3f;
        isEnemyHit = false;
        WaitBeforeNextEnemy = 3f;
    }

    void Update()
    {
        enemyOnScreen = GameObject.FindGameObjectsWithTag("Enemy").Length;
        enemyTimer += Time.deltaTime;
        if (enemyTimer >= WaitBeforeNextEnemy) {
            if (GameManager.Instance.score <= 100) {
                if (enemyOnScreen < 2) { 
                    WaitBeforeNextEnemy = UnityEngine.Random.Range(3f, 6f);
                    Transform enemy=InstantiateEnemy();
                    enemy.position = CollectibleSpawnerScript.GetRandomPositionInArea();
                    enemyTimer = 0f;
                }
            }
            else if (GameManager.Instance.score <= 200) {
                if (enemyOnScreen < 3) {
                    WaitBeforeNextEnemy = UnityEngine.Random.Range(2f, 4f);
                    Transform enemy = InstantiateEnemy();
                    enemy.position = CollectibleSpawnerScript.GetRandomPositionInArea();
                    enemyTimer = 0f;
                }
            }
            else if (GameManager.Instance.score <= 400) {
                if (enemyOnScreen < 4) {
                    WaitBeforeNextEnemy = UnityEngine.Random.Range(1.5f, 3.5f);
                    Transform enemy = InstantiateEnemy();
                    enemy.position = CollectibleSpawnerScript.GetRandomPositionInArea();
                    enemyTimer = 0f;
                }
            }
            else {
                if (enemyOnScreen < 5) {
                    WaitBeforeNextEnemy = UnityEngine.Random.Range(2f, 4f);
                    Transform enemy = InstantiateEnemy();
                    enemy.position = CollectibleSpawnerScript.GetRandomPositionInArea();
                    enemyTimer = 0f;
                }
            }
        }
        if (isEnemyHit) {
            if (GameManager.Instance.score < 20) { GameManager.Instance.score = 0; }
            else {
                GameManager.Instance.score -= 20;
            }
            OnEnemyHit?.Invoke(this, EventArgs.Empty);isEnemyHit = false;
        }
    }

    private Transform InstantiateEnemy() {
        return Instantiate(enemiesSOArray[UnityEngine.Random.Range(0, enemiesSOArray.Length)].prefab).transform;
        
    }
}
