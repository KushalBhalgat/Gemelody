using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClipsRefsSO audioClips;
    void Start()
    {
        EnemiesManager.Instance.OnEnemyHit += Instance_OnEnemyHit;
        EffectsSpawner.Instance.OnLevelUp += Instance_OnLevelUp;
    }

    private void Instance_OnLevelUp(object sender, System.EventArgs e) {
        PlaySound(audioClips.levelUp,10f);

    }

    private void Instance_OnEnemyHit(object sender, System.EventArgs e) {
        PlaySound(audioClips.hitEnemy,2f);
    }

    void Update()
    {
        
    }


    private void PlaySound(AudioClip[] clips,float volume=1f) {
        PlaySound(clips[UnityEngine.Random.Range(0, clips.Length)],volume);
    }

    private void PlaySound(AudioClip clip,float volume = 1f) {
        AudioSource.PlayClipAtPoint(clip, transform.position,volume);
    }
}
