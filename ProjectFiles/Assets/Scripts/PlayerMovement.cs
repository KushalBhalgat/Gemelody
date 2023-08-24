using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /*
    private bool isPlayerMoving;
    public static PlayerMovement Instance { get; private set; }
    public Vector3 lastPos;
    public event EventHandler OnPlayerStoppedMoving;
    public event EventHandler OnPlayerIsMoving;
    private int flag =0;
    private void Awake() {
        Instance = this;
    }

    private void Start() {
        lastPos=transform.position;
        GameInput.Instance.OnMouseMoved += Instance_OnMouseMoved;
        GameInput.Instance.OnMouseStopped += Instance_OnMouseStopped;
        isPlayerMoving = false;
    }


    private void Update() {
        if (isPlayerMoving) { Debug.Log("A");}
    }
    private void Instance_OnMouseStopped(object sender, System.EventArgs e) {
        isPlayerMoving = false;
        if (flag == 1) { 
            OnPlayerStoppedMoving?.Invoke(this,EventArgs.Empty);
            flag = 0;
        }
    }

    private void Instance_OnMouseMoved(object sender, GameInput.OnMouseMovedEventArgs e) {
        lastPos = transform.position;
        transform.position = e.mousePositionVector;
        isPlayerMoving = true;
        transform.position = Vector3.Lerp(transform.position,e.mousePositionVector,Time.deltaTime);
        if (flag==0) { 
            OnPlayerIsMoving?.Invoke(this, EventArgs.Empty);
            flag = 1;
        }
    }

    public bool IsPlayerMoving() { return isPlayerMoving; }
    */
}
