using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogController : MonoBehaviour {
    public static DialogController instance;
    [SerializeField] GameObject dialogBox;
    [SerializeField] TMPro.TextMeshProUGUI dialogTxt;
    [SerializeField] string dialog;

    void Awake() {
        instance = this;
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            showDialog(dialog);
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) hideDialog(dialog);
    }

    public void hideDialog(string txt="") {
        dialogBox.SetActive(false);
        dialogTxt.text = ArabicSupport.ArabicFixer.Fix(txt);
    }

    public void showDialog(string txt) {
        dialogBox.SetActive(true);
        dialogTxt.text = ArabicSupport.ArabicFixer.Fix(txt);
    }
}
