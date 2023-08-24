using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditSceneManager : MonoBehaviour
{

    private float timer = 0f;
    [SerializeField] private Transform UICamera;
    Vector3 targetPosition,temp;
    float timeElapsed,zval;
    void Start()
    {
        targetPosition=UICamera.position;
        targetPosition.y = -185.5f;
        zval=UICamera.position.z;
    }

    // Update is called once per frame

    IEnumerator WaitAndQuit() {
        yield return new WaitForSeconds(2f);
        Application.Quit();
    }
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (UICamera.position.y<=-239f) {
            temp=UICamera.position;
            temp.y += 45 * Time.deltaTime;
            UICamera.position = temp;
        }
        else {
            StartCoroutine(WaitAndQuit());  
        }
    }
}
