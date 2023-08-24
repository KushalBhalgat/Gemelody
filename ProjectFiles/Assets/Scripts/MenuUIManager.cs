using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] private Transform[] checkpoints;
    [SerializeField] private Transform UICamera;
    public static int currCheckpoint;
    float timeElapsed = 0f;

    public static MenuUIManager instance;
    private void Awake() {
        instance= this;
    }
        

    void Start() {
        currCheckpoint = 0;
        SetCameraPositionAndRotation(0);
        timeElapsed = 0f;
        StartCoroutine(FirstLerp());
        //StartCoroutine(LerpCamera(1));
    }

    void Update()
    {
        Debug.Log("CURR : "+currCheckpoint);
        if (Input.GetKey(KeyCode.Space)) {
            if(currCheckpoint != 4) {
                StartCoroutine(LerpCamera((currCheckpoint + 1) % 5));
                StartCoroutine(LerpCamera((currCheckpoint + 1) % 5));
            }
            else {
                StartCoroutine(LerpCamera(2));
            }
        }
        /*
        LerpCameraPosition(1, 2,timeElapsed);
        if(currCheckpoint == 0) {
            timeElapsed += Time.deltaTime;
        }
        if(currCheckpoint == 1) { StartCoroutine(WaitAtTitle()); }
    */
    }

    public void ChangePage(int index) {
        StartCoroutine(LerpCamera(index));
    }

    IEnumerator LerpCamera(int index) {
        float timeElapsed = 0f,time=1f;
        Debug.Log(index);
        while (timeElapsed < time) {
            UICamera.position = Vector3.Lerp(UICamera.position, checkpoints[index].position, timeElapsed / time);
            UICamera.rotation = Quaternion.Lerp(UICamera.rotation, checkpoints[index].rotation, timeElapsed / time);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        Debug.Log("reached end");
        currCheckpoint = index;
        SetCameraPositionAndRotation(index);
    }


    IEnumerator FirstLerp() {
        float timeElapsed = 0f, time = 1f;
        while (timeElapsed < time) {
            UICamera.position = Vector3.Lerp(UICamera.position, checkpoints[1].position, timeElapsed / time);
            UICamera.rotation = Quaternion.Lerp(UICamera.rotation, checkpoints[1].rotation, timeElapsed / time);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        currCheckpoint = 1;
        SetCameraPositionAndRotation(1);
        yield return new WaitForSeconds(3f);
        timeElapsed = 0f; time = 1f;
        while (timeElapsed < time) {
            UICamera.position = Vector3.Lerp(UICamera.position, checkpoints[2].position, timeElapsed / time);
            UICamera.rotation = Quaternion.Lerp(UICamera.rotation, checkpoints[2].rotation, timeElapsed / time);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        currCheckpoint = 2;
        SetCameraPositionAndRotation(2);
    }


    private void LerpCameraPosition(int i,float time,float timeElapsed) {
        if (timeElapsed < time) {
            Vector3 position = UICamera.position;
            position.y = Mathf.Lerp(UICamera.position.y, checkpoints[i].position.y, timeElapsed / time);
            UICamera.position=position;
        }
        else { 
            SetCameraPositionAndRotation(i);
            currCheckpoint = 1;
        }
    }

    private void SetCameraPositionAndRotation(int i) {
        UICamera.position = checkpoints[i].position;
        UICamera.rotation= checkpoints[i].rotation;
    }




}
