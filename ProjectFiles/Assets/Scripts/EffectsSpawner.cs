using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EffectsSpawner : MonoBehaviour
{
    public event EventHandler OnLevelUp;
    
    
    [SerializeField] private GameObject glowConfettiEffect;
    [SerializeField] private GameObject hitEffect;

    private int targetScore=50;
    private int targetScoreMultiplier=2;
    public static EffectsSpawner Instance { get; private set; }
    private void Awake() {
        Instance = this;
    }
    void Start()
    {
        
    }

    public void PlayEnemyTouchEffect(Vector3 position) {
        Transform effect=Instantiate(hitEffect).transform;
        effect.position = position;
    }

    void Update()
    {

        if (GameManager.Instance.score>=targetScore) { 
            Transform effect1 = Instantiate(glowConfettiEffect, CollectibleSpawnerScript.GetRandomPositionInArea(), Quaternion.identity).transform; 
            targetScore *= targetScoreMultiplier;OnLevelUp?.Invoke(this, EventArgs.Empty);
        }
        if (targetScore % 1000==0) { targetScoreMultiplier = 2; }
        else if(targetScore % 10000==1) { targetScoreMultiplier = 5;}
    }
}
