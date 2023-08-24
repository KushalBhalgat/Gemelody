using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MusicSceneManager : MonoBehaviour
{
    [SerializeField] private Button helio;
    [SerializeField] private Button slow;

    private void Awake() {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        slow.onClick.AddListener(() => { SongCarrier.Instance.songNo = 0; StartCoroutine(WaitFor5()); SceneManager.LoadScene("GameScene"); });
        helio.onClick.AddListener(() => { SongCarrier.Instance.songNo = 1; StartCoroutine(WaitFor5()); SceneManager.LoadScene("GameScene"); });
    }


    IEnumerator WaitFor5() {
        yield return new WaitForSeconds(1);
    }
}
