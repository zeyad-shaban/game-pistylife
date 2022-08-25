using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractUIController : MonoBehaviour {
    public static InteractUIController instance;
    [SerializeField] GameObject interactHolder;
    [SerializeField] TextMeshProUGUI keyTxt;
    [SerializeField] TextMeshProUGUI interactTxt;

    void Awake() {
        instance = this;
    }

    public void ShowInteract(string key, float timeToCorrect) {
        keyTxt.text = "E";
        interactTxt.text = "To Interact";
        interactHolder.SetActive(true);
        StartCoroutine(ShowInteractCo(key, timeToCorrect));
    }
    IEnumerator ShowInteractCo(string key, float timeToCorrect) {
        yield return new WaitForSeconds(timeToCorrect);
        keyTxt.text = key;
        interactTxt.text = ArabicSupport.ArabicFixer.Fix("لقد قفشتني");
    }

    public void HideInteract() {
        if (interactHolder.activeInHierarchy) interactHolder.SetActive(false);
    }
}
