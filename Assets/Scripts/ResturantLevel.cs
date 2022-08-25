using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.UI;

public class ResturantLevel : MonoBehaviour {
    bool playing;
    [SerializeField] GameObject marawanModel;
    [SerializeField] GameObject timerHolder;
    [SerializeField]  satisfactionBar;
    [SerializeField] TextMeshProUGUI timerTxt;
    int timeRemaining = 60;

    void startLevel() {
        GameObject marawan = Instantiate(marawanModel);
        marawan.transform.position = new Vector3(1.80999994f, 5.38999987f, -39.6899986f);

        timerHolder.SetActive(true);
        StartCoroutine(countingCo());
        // Display satisfaction bar at 50%

        // marawan goes cook
        // Activate cookingArea for pisty 
    }

    IEnumerator countingCo() {
        while (timeRemaining >= 0) {
            yield return new WaitForSeconds(1);
            timerTxt.text = timeRemaining.ToString();
            timeRemaining--;
        }
        timerTxt.text = timeRemaining + "OH NO!";
        timeRemaining = 60;
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player") || !playing) {
            playing = true;
            startLevel();
        }
    }
}