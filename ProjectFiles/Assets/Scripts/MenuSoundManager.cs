using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSoundManager : MonoBehaviour {
    [SerializeField] private AudioClipsRefsSO audioClips;
    void Start() {
        MenuEffectsSpawner.Instance.OnButtonHit += Instance_OnButtonHit;
    }

    private void Instance_OnButtonHit(object sender, System.EventArgs e) {
        GetComponent<AudioSource>().Play();
    }

    private void Update() {
        transform.position=Camera.main.transform.position;
    }
}
