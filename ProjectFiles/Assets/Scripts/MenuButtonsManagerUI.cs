using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtonsManagerUI : MonoBehaviour
{
    [SerializeField] private Button play;
    [SerializeField] private Button music;
    [SerializeField] private Button exit;

    private void Awake() {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        play.onClick.AddListener(() => { SceneManager.LoadScene("GameScene"); });
        //helio.onClick.AddListener(() => { SongCarrier.Instance.songNo = 1; SceneManager.LoadScene("GameScene"); });
        exit.onClick.AddListener(() => { Application.Quit();});
        music.onClick.AddListener(() => { SceneManager.LoadScene("Music"); });
    }

    private void Update() {
        if (Input.GetKey(KeyCode.Space)) { Application.Quit(); }
    }

}
