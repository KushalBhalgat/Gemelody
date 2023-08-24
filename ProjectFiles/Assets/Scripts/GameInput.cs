using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance;
    private Camera mainCamera;
    //public event EventHandler<OnMouseMovedEventArgs> OnMouseMoved;

    public bool IsMouseMoving;
    //public event EventHandler OnMouseStopped;
    public class OnMouseMovedEventArgs : EventArgs {
        public Vector3 mousePositionVector;
    }


    private float inputMouseXAxis, inputMouseYAxis;
    private Vector3 mousePosition;
    private void Awake() {
        Instance = this;
        mainCamera=Camera.main;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    private void Start() {
        mousePosition = new Vector3(0, 0);
    }

    private void Update() {
        inputMouseXAxis = Input.GetAxis("Mouse X");
        inputMouseYAxis = Input.GetAxis("Mouse Y");
        mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        IsMouseMoving = !(inputMouseXAxis!=0 && inputMouseYAxis!=0);
        /*
        if (inputMouseXAxis!=0 || inputMouseYAxis!=0) {
            mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            OnMouseMoved?.Invoke(this, new OnMouseMovedEventArgs { mousePositionVector = mousePosition});
        }
        else if(inputMouseXAxis==0 && inputMouseYAxis == 0) {
            OnMouseStopped.Invoke(this, EventArgs.Empty);
        }
        */
    }

}
