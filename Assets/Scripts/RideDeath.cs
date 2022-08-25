using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RideDeath : MonoBehaviour {
    bool inRad, riding;
    float speed = 1, acceleration = 0.001f, maxspeed = 60;
    [SerializeField] Transform ridePoint;
    [SerializeField] GameObject player1, player2;
    [SerializeField] AudioSource motorcycleStartSFX;
    bool deathCoCalled;


    void Update() {
        if (inRad) {
            if (Keyboard.current.fKey.wasPressedThisFrame) DeathController.instance.Restart();
            if (Keyboard.current.tKey.wasPressedThisFrame) DeathController.instance.Restart();
            if (Keyboard.current.rKey.wasPressedThisFrame) riding = true;
        }
    }

    void LateUpdate() {
        if (riding) {
            InteractUIController.instance.HideInteract();
            if (!motorcycleStartSFX.isPlaying) motorcycleStartSFX.Play();
            transform.position += transform.forward * speed * Time.deltaTime;
            player1.transform.position = ridePoint.position;
            player2.transform.position = ridePoint.position;
            if (speed > maxspeed) {
                speed = 500;
                if (!deathCoCalled) {
                    StartCoroutine(deathCo());
                    deathCoCalled = true;
                }
            } else speed += acceleration;
            acceleration += 0.05f * Time.deltaTime;
        }
    }

    IEnumerator deathCo() {
        yield return new WaitForSeconds(3);
        DeathController.instance.Restart(@"الحقوني صاحب اللعبه
        مش عارف يعمل
        موتوسيكل", 1.5f, true);
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            inRad = true;
            InteractUIController.instance.ShowInteract("R", 1.5f);
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            inRad = false;
            InteractUIController.instance.HideInteract();
        }
    }
}