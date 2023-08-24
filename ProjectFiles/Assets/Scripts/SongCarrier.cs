using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SongCarrier : MonoBehaviour
{
    public static SongCarrier Instance;
    public int score;
    public int songNo;
    private void Awake() {
        Instance = this;
        GameObject[] notDestroyedObjects = GameObject.FindGameObjectsWithTag("SongCarry");
        if (notDestroyedObjects.Length > 1) {
            Destroy(this.gameObject);
        }
        else {
            DontDestroyOnLoad(this.gameObject);
        }
    }
    void Start()
    {
        songNo = 0;
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "GameScene" || SceneManager.GetActiveScene().name=="CreditScene") {
            Cursor.visible = false;
        }
        else{
            Cursor.visible = true;
        }
    }
    
}
