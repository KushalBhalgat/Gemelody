using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private Camera mainCamera;
    [SerializeField]private ParticleSystem pointParticleSystem;
    ParticleSystem.MainModule module;
    private float sizeTimer;
    private Vector3 mousePosition;
    void Start()
    {
        module=pointParticleSystem.main;
        mousePosition = Vector3.zero;
        mainCamera = Camera.main;
    }

    void Update()
    {
        sizeTimer += Time.deltaTime;
        mousePosition.x = Input.mousePosition.x;mousePosition.y = Input.mousePosition.y;mousePosition.z = -(Camera.main.transform.position.z+0.5f);
        transform.position = mainCamera.ScreenToWorldPoint(mousePosition);
        if (!GameInput.Instance.IsMouseMoving) {
            module.startSize= Mathf.Lerp(0.6f, 0.4f, Time.deltaTime);
        }
        else {
            module.startSize= Mathf.Lerp(0.4f, 0.6f, Time.deltaTime);
        }
    }
}
