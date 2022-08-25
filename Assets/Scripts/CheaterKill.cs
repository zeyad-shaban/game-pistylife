using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheaterKill : MonoBehaviour {
    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) DeathController.instance.Restart(@"أه يغشاش مستغل
         اني مش عامل سقف");
    }
}
