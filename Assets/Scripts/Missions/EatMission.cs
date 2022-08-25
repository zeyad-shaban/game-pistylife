using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Cinemachine;

public class EatMission : MonoBehaviour {
    public bool playerInRadius;
    [SerializeField] Image foodHolder;
    [SerializeField] GameObject followCamera;
    [SerializeField] GameObject thinArmature, buffArmature;
    [SerializeField] Transform thinCamRootTrans, buffCamRootTrans;

    void Update() {
        if (playerInRadius) {
            if (Keyboard.current.fKey.wasPressedThisFrame) {

                foodHolder.gameObject.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
            } else if (Keyboard.current.tKey.wasPressedThisFrame || Keyboard.current.rKey.wasPressedThisFrame) DeathController.instance.Restart();
        }
    }

    public void TurnThin() {
        thinArmature.transform.position = buffArmature.transform.position;
        buffArmature.SetActive(false);
        thinArmature.SetActive(true);
        followCamera.GetComponent<CinemachineVirtualCamera>().Follow = thinCamRootTrans;

        foodHolder.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;

        MissionUIController.instance.missions[0].Done = true;
        MissionUIController.instance.UpdateMissions();
    }

    public void TurnBuffBoi() {
        buffArmature.transform.position = thinArmature.transform.position;
        thinArmature.SetActive(false);
        buffArmature.SetActive(true);
        followCamera.GetComponent<CinemachineVirtualCamera>().Follow = buffCamRootTrans;

        foodHolder.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;

        MissionUIController.instance.missions[0].Done = true;
        MissionUIController.instance.UpdateMissions();
    }


    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            playerInRadius = true;
            InteractUIController.instance.ShowInteract("F", 3);
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            playerInRadius = false;
            InteractUIController.instance.HideInteract();
        }
    }
}
