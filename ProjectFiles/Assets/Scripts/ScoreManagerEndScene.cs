using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManagerEndScene : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI scoreText;
    private float timer = 0f;
    void Start()
    {
        scoreText.text = SongCarrier.Instance.score.ToString();
        timer = 0f;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("CreditScene");
        }
        timer += Time.deltaTime;
        if (timer > 3f) {
            timer = 0f;
            SceneManager.LoadScene("Menu 3");
        }
    }
}
