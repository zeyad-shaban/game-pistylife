using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorShatter : MonoBehaviour {
    [SerializeField] ParticleSystem explPS;
    [SerializeField] AudioSource AngrySFXs;
    bool canInteract = true;
    [SerializeField] int waitToReturn = 4;

    private void Start() {
    }

    private IEnumerator OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player") && canInteract) {
            canInteract = false;
            AngrySFXs.Play();
            yield return new WaitForSeconds(0.7f);
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<MeshCollider>().enabled = false;
            ParticleSystem clonedExpl = Instantiate(explPS);
            clonedExpl.transform.parent = transform;
            clonedExpl.transform.localPosition = new Vector3(0, 0, 0);
            clonedExpl.Play();

            yield return new WaitForSeconds(waitToReturn);
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            gameObject.GetComponent<MeshCollider>().enabled = true;
            canInteract = true;
        }
    }
}
