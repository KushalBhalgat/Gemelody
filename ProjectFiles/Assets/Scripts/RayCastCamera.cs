using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RayCastCamera : MonoBehaviour
{
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 100f;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Debug.DrawRay(transform.position, mousePos - transform.position, Color.blue);

        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) {
                int currIndex = MenuUIManager.currCheckpoint;
                if (hit.transform.name == "PlayStone") {
                    MenuEffectsSpawner.Instance.PlayEnemyTouchEffect(hit.transform.position);
                    MenuUIManager.instance.ChangePage(3);
                    MenuUIManager.currCheckpoint = 3;
                }
                else if (hit.transform.name == "ExitStone") {
                    MenuEffectsSpawner.Instance.PlayEnemyTouchEffect(hit.transform.position);
                    StartCoroutine(WaitForSceneChange("CreditScene"));
                    

                    //MenuUIManager.instance.ChangePage(3);
                }
                else if (hit.transform.name == "GoAhead") {
                    MenuEffectsSpawner.Instance.PlayEnemyTouchEffect(hit.transform.position);
                    MenuUIManager.instance.ChangePage(4);
                    MenuUIManager.currCheckpoint = 4;
                }
                else if (hit.transform.name == "Song1" || hit.transform.name == "Song2") {
                    if (hit.transform.name == "Song1") { SongCarrier.Instance.songNo = 1; }
                    else { SongCarrier.Instance.songNo = 0; }
                    MenuEffectsSpawner.Instance.PlayEnemyTouchEffect(hit.transform.position);
                    StartCoroutine(WaitForSceneChange("GameScene"));
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape)) {
            if (MenuUIManager.currCheckpoint == 2 || MenuUIManager.currCheckpoint == 0 || MenuUIManager.currCheckpoint == 1) {
                StartCoroutine(WaitForSceneChange("CreditScene"));
                //Application.Quit();
            }
            else if (MenuUIManager.currCheckpoint == 4) {
                MenuUIManager.instance.ChangePage(3);
                MenuUIManager.currCheckpoint = 3;
            }
            else if (MenuUIManager.currCheckpoint == 3) {
                MenuUIManager.instance.ChangePage(2);
                MenuUIManager.currCheckpoint = 2;
            }
        }
    }

    IEnumerator WaitForSceneChange(string name) {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(name);
    }

}
