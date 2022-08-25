using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallShatterOnEnemy : MonoBehaviour {
    [SerializeField] ParticleSystem explPS;
    [SerializeField] AudioSource boomSFX;
    bool canInteract = true;

    private void Start() {
    }

    IEnumerator OnTriggerEnter(Collider other) {
        if (other.CompareTag("Enemy") && canInteract) {
            canInteract = false;
            yield return new WaitForSeconds(0.7f);
            boomSFX.Play();
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<MeshCollider>().enabled = false;
            ParticleSystem clonedExpl = Instantiate(explPS);
            clonedExpl.transform.parent = transform;
            clonedExpl.transform.localPosition = new Vector3(0, 0, 0);
            clonedExpl.Play();
        }
    }
}