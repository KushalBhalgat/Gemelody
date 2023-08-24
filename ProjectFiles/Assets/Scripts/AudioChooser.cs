using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioChooser : MonoBehaviour
{
    AudioSource song;
    [SerializeField] private AudioClip[] songs;
    void Start()
    {
        song = GetComponent<AudioSource>();
        song.clip = songs[SongCarrier.Instance.songNo];
        song.loop = true;
        song.Play();
    }
    private void Update() {
        if (Input.GetKey(KeyCode.Escape)) { SongCarrier.Instance.score = GameManager.Instance.score; SceneManager.LoadScene("EndScene1"); }
    }
}
