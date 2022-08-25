using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Trigger : MonoBehaviour {
    bool didStart;
    [SerializeField] GameObject thief, laptop, jumpscare;
    [SerializeField] Transform handTrans, gardenHidingTrans;
    [SerializeField] AudioSource tookYourPC;
    CharacterController charController;


    void Start() {
        charController = thief.GetComponent<CharacterController>();
    }

    IEnumerator OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player") && PlayerPrefs.GetInt("mission") == 1 && !didStart) {
            didStart = true;
            Destroy(thief.GetComponent<DialogController>());
            Destroy(thief.GetComponent<BoxCollider>());

            thief.transform.position = new Vector3(1.642668f, 5.73f, -5.91f);
            thief.transform.localScale = new Vector3(0.6476527f, 0.6476527f, 0.6476527f);
            thief.transform.eulerAngles = new Vector3(0, 286.413696f, 0);

            laptop.transform.position = handTrans.position;
            tookYourPC.Play();
            jumpscare.SetActive(true);

            yield return new WaitForSeconds(1);
            jumpscare.SetActive(false);
            yield return new WaitForSeconds(4);

            thief.transform.LookAt(gardenHidingTrans.position);
            Vector3 direction = gardenHidingTrans.position - thief.transform.position;
            Vector3 movement = direction.normalized * 3 * Time.deltaTime;

            MissionUIController.instance.missions[1].Done = true;
            MissionUIController.instance.UpdateMissions();

            // TODO Activate running animation
            for (float i = 10; i > 0; i -= Time.deltaTime) {
                laptop.transform.position = handTrans.position;
                charController.Move(movement);
                yield return new WaitForEndOfFrame();
            }
            // TODO stop animation

            thief.transform.position = new Vector3(0.206f, 4.89900017f, -41.4620018f);
            thief.transform.eulerAngles = new Vector3(1.19320655f, 2.41513038f, 2.88544669f);
            thief.transform.localScale = new Vector3(0.107535832f, 0.107535832f, 0.107535832f);
            laptop.transform.position = handTrans.position;
        }
    }
}
