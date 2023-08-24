using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class EndSceneManager : MonoBehaviour
{
    [SerializeField] private Button menu;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake() {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        menu.onClick.AddListener(() => { SceneManager.LoadScene("Menu 2"); });
        
    }

    
    private void Start() {
        scoreText.text="Score : "+SongCarrier.Instance.score.ToString();
    }


    private void Update() {
        if(Input.GetKey(KeyCode.Escape)) { SceneManager.LoadScene("CreditScene"); }
    }
}
