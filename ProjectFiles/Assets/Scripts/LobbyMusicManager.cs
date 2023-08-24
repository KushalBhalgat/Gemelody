using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyMusicManager : MonoBehaviour
{
    public static LobbyMusicManager Instance;
    private AudioSource lobbyMusic;

    private void Awake() {
        Instance = this;
        GameObject[] notDestroyedObjects = GameObject.FindGameObjectsWithTag("LobbyAudio");
        if (notDestroyedObjects.Length > 1) {
            Destroy(this.gameObject);
        }
        else {
            DontDestroyOnLoad(this.gameObject);
        }
    }
    void Start()
    {
        
        lobbyMusic = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(SceneManager.GetActiveScene().name=="GameScene") { lobbyMusic.Pause(); }
        else {
            if (!lobbyMusic.isPlaying) { lobbyMusic.Play(); }
        }
    }
}
