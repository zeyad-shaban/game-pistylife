using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class DeathController : MonoBehaviour {
    public static DeathController instance;
    [SerializeField] GameObject deathHolder;
    [SerializeField] TextMeshProUGUI deathMsg;
    [SerializeField] GameObject player1, player2;
    Vector3 plrStartPos;
    [SerializeField] AudioSource deathSFX, bsB2aSFX, ehDaY3mSFX, failSFX;
    bool dying;

    void Awake() {
        instance = this;
    }

    void Start() {
        plrStartPos = player1.transform.position;
    }

    void Update() {
        if (Keyboard.current.eKey.wasPressedThisFrame && !deathHolder.activeInHierarchy) {
            Restart("أضحك عليك XD");
        }
    }

    public void Restart(string msg = "صحصح شوية", float additionalWait = 0, bool fail = false) {
        if (dying) return;
        dying = true;
        PlayerPrefs.SetInt("DeathCount", PlayerPrefs.GetInt("DeathCount", 0) + 1);
        deathMsg.text = ArabicSupport.ArabicFixer.Fix(msg);
        deathHolder.SetActive(true);
        int deathCount = PlayerPrefs.GetInt("DeathCount");
        if (fail) failSFX.Play();
        else if (deathCount % 7 == 0) ehDaY3mSFX.Play();
        // else if (deathCount == 15) { Debug.Log("OK THAT'S ALOT OF DEATHES, TIME TO MEET DEATH GOD");} 
        else if (deathCount % 4 == 0) bsB2aSFX.Play();
        else deathSFX.Play();
        StartCoroutine(RestartCo(additionalWait));
    }

    IEnumerator RestartCo(float additionalWait) {
        yield return new WaitForSeconds(4 + additionalWait);
        //     deathHolder.SetActive(false);
        //     player1.transform.position = new Vector3(4.39f, 6.42f, -6.975f);
        //     player2.transform.position = new Vector3(4.39f, 6.42f, -6.975f);
        //     dying = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}