using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.Experimental.VFX;

public class PlayerTrailVisual : MonoBehaviour
{
    [SerializeField]private VisualEffect trail;
    [SerializeField] private Color col;
    [SerializeField] private Transform player;
    private MovePlayerOnBeats playerScript;

    private void Start() {
        playerScript= player.GetComponent<MovePlayerOnBeats>();
        //MovePlayerOnBeats.instance.OnBeatStart += Instance_OnBeatStart;
        //MovePlayerOnBeats.instance.OnBeatEnd += Instance_OnBeatEnd;
    }

    /*
    private void Instance_OnBeatEnd(object sender, System.EventArgs e) {
        trail.Reinit();
    }

    private void Instance_OnBeatStart(object sender, System.EventArgs e) {
        trail.Stop();
    }
    */
    private void Update() {
        //trail.SetVector3("ParticlePosition", (MovePlayerOnBeats.lastPos - player.transform.position).normalized);
        trail.SetFloat("Thrust", Random.Range(20, 30f));
    }
}
