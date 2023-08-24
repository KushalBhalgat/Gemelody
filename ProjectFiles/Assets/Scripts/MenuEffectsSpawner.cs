using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class MenuEffectsSpawner : MonoBehaviour {
    public event EventHandler OnButtonHit;

    [SerializeField] private GameObject Dummy;
    [SerializeField] private GameObject hitEffect;
    public GameObject hitObject;
    public Vector3 hitObjectPosition;
    public Quaternion hitObjectRotation;
    public int hitIndex;

    public static MenuEffectsSpawner Instance { get; private set; }
    private void Awake() {
        Instance = this;
        hitIndex = 2;
    }

    public void PlayEnemyTouchEffect(Vector3 position) {
        Transform effect = Instantiate(hitEffect).transform;
        effect.position = position;
        OnButtonHit?.Invoke(this, EventArgs.Empty);
    }

    private void Update() {
        /*
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 100f;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Debug.DrawRay(transform.position, mousePos - transform.position,Color.blue);

        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) {
                Debug.Log(hit.transform.name);
            }
        }
        */

        /*
        if (Input.GetMouseButtonDown(0)) {
            Vector3 mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (MenuUIManager.instance.currCheckpoint == 2) { mouseposition.z = -3.86f; }
            else { mouseposition.z = -206.79f; }
            Instantiate(Dummy, mouseposition, Quaternion.identity);
        }
        */

        /*
        if (Input.GetMouseButtonDown(0)) {
            Vector3 mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseposition.z=transform.position.z;
            Instantiate(hitEffect, mouseposition, Quaternion.identity);
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.Log("hit attempt");
            if (Physics.Raycast(ray, out hit)) {
                Debug.DrawRay(ray.origin, ray.direction);
                if (hit.transform.gameObject.TryGetComponent<MenuButtonGem>(out MenuButtonGem menuButtonGem)) {
                    hitObject = hit.transform.gameObject;
                    hitObjectPosition = hit.transform.position;
                    hitObjectRotation = hit.transform.rotation;
                    hitIndex = MenuUIManager.instance.currCheckpoint;
                    PlayEnemyTouchEffect(hit.transform.position);
                    Destroy(hit.transform.gameObject);
                }
            }
            
    


        if (hitIndex <= MenuUIManager.instance.currCheckpoint) {
            if (hitObject != null) {
                Instantiate(hitObject, hitObjectPosition, hitObjectRotation);
            }
        }
        */
    }
}
