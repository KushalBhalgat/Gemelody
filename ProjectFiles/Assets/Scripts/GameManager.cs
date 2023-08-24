using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] public int score;
    [SerializeField] private float timer;

    private void Awake() {
        Instance = this;
    }
    void Start()
    {
        score = 0; timer = 0f;
    }


    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 60*7) { SongCarrier.Instance.score = score; StartCoroutine(WaitFor5()); SceneManager.LoadScene("EndScene1"); }
    }

    IEnumerator WaitFor5() {
        yield return new WaitForSeconds(1);
    }
}
