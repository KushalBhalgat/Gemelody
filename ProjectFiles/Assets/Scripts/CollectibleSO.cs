using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu()]
public class CollectibleSO : ScriptableObject{
    public float dieTimer;
    public int points;
    public GameObject prefab;
}
