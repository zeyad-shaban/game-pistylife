using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ArabicFixer : MonoBehaviour {
    void Start() {
        gameObject.GetComponent<TextMeshProUGUI>().text = ArabicSupport.ArabicFixer.Fix(gameObject.GetComponent<TextMeshProUGUI>().text);
    }
}
