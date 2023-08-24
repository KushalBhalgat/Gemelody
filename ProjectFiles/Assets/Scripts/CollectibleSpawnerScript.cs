using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawnerScript : AudioSyncer {
    [SerializeField] private CollectibleSO[] collectibleSOArray;
    public static CollectibleSpawnerScript instance;
    [SerializeField] private GameObject[] collectibles;

    private float startTimer = 2f;
    private bool spawnerFlag = false;

    private void Awake() {
        instance = this;
    }

    void Start() {
        spawnerFlag = false;
    }

    public override void OnUpdate() {
        base.OnUpdate();
        if (!spawnerFlag) { startTimer -= Time.deltaTime; }
        if (startTimer <= 0) {
            spawnerFlag = true; startTimer = 0f;
        }
        collectibles = GameObject.FindGameObjectsWithTag("Collectible");
    }
    public override void OnBeat() {
        base.OnBeat();
        CollectibleSO selectedSO = collectibleSOArray[UnityEngine.Random.Range(0, collectibleSOArray.Length)];
        Vector3 targetPos = GetRandomPositionInArea();
        //  targetPos.z = -0.5f;
        if (collectibles.Length <= 3 && spawnerFlag) {
            Transform collectible = Instantiate(selectedSO.prefab).transform;
            collectible.transform.position = targetPos;
        }
        m_isBeat = false;
    }
    public static Vector3 GetRandomPositionInArea() {
        Vector3 pos;
        pos.x = UnityEngine.Random.Range(-8.1f, 8.3f);
        pos.y = UnityEngine.Random.Range(-4.3f, 4.3f);
        pos.z = 0f;
        return pos;
    }

}
