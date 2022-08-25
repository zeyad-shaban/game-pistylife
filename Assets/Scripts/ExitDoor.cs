using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ExitDoor : MonoBehaviour {
    bool inRadius;
    [SerializeField] AudioSource doorOpenSFX;

    void Update() {
        if (inRadius && PlayerPrefs.GetInt("mission") >= 2) {
            if (Keyboard.current.fKey.wasPressedThisFrame || Keyboard.current.rKey.wasPressedThisFrame) DeathController.instance.Restart(@"فاكره هيبقي
            نفس الزرار");
            else if (Keyboard.current.tKey.wasPressedThisFrame) {
                InteractUIController.instance.HideInteract();
                DialogController.instance.hideDialog();

                gameObject.GetComponent<MeshRenderer>().enabled = false;
                gameObject.GetComponent<MeshCollider>().enabled = false;
                doorOpenSFX.Play();
                returnDoorCo();
            }
        }
    }

    IEnumerator returnDoorCo() {
        yield return new WaitForSeconds(3);
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        gameObject.GetComponent<MeshCollider>().enabled = true;
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            inRadius = true;
            if (PlayerPrefs.GetInt("mission") < 2) DialogController.instance.showDialog("خلص المهمات الموجوده الاول");
            else InteractUIController.instance.ShowInteract("T", 3);
        }
    }
    void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            inRadius = false;
            if (PlayerPrefs.GetInt("mission") < 2) DialogController.instance.hideDialog();
            else InteractUIController.instance.HideInteract();
        }
    }
}