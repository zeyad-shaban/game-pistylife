using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDeath : MonoBehaviour {
	void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            DeathController.instance.Restart(@"أنت وقعت 
            من الدور العشرين");
        }
    }
}