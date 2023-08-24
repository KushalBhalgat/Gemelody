using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuButtonGem : MonoBehaviour
{
    [SerializeField]private GameObject Dummy;
    private Vector3 mousePosition;
    private Camera mainCamera;
    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update() {
        
            /*
            if(Input.GetMouseButtonDown(0)) {
                mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = transform.position.z;
                Instantiate(Dummy,mousePosition,Quaternion.identity);
            }


            if (Input.GetMouseButtonDown(0)) {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit)) {
                    if (hit. == "Sphere") {
                        mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
                        mousePosition.z = transform.position.z;
                        Instantiate(Dummy, mousePosition, Quaternion.identity);
                    }
                }
            }
            */
        }


}
