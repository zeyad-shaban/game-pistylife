using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class MissionUIController : MonoBehaviour {
    public static MissionUIController instance;
    [SerializeField] TextMeshProUGUI hintTxt;
    public Mission[] missions = new Mission[3];

    float lastHClick = 0;


    void Awake() {
        instance = this;
        missions[0] = new Mission("أفتح الثلاجه", @"أقف جنب الثلاجه شويه
        E زر الانتحار");
        missions[1] = new Mission("أشغتل علي الابتوب", @"ارجع الاوضه
        ثو`اني انت محتاج تلميح ليه اصلا");
        missions[2] = new Mission("أقفش الحرامي", "المشي صحي بردو");
    }
    void Start() {
        // DEVELOPER PURPOSE
        PlayerPrefs.DeleteAll();

        UpdateMissions();
        displayHint(missions[PlayerPrefs.GetInt("mission")].Objective);

    }

    void Update() {
        if (Keyboard.current.hKey.wasPressedThisFrame) {
            UpdateMissions();
            Mission currMission = missions[PlayerPrefs.GetInt("mission")];
            displayHint(lastHClick <= 0.5 ? currMission.Solution : currMission.Objective);
            lastHClick = 0;
        }
        lastHClick += Time.deltaTime;
    }

    public void displayHint(string hint = "", int waitTime = 10) {
        if (hint.Trim() == "") hint = hintTxt.text;

        hintTxt.text = ArabicSupport.ArabicFixer.Fix(hint);
        StartCoroutine(displayHintCo(waitTime));
    }

    IEnumerator displayHintCo(int waitTime) {
        hintTxt.gameObject.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        hintTxt.gameObject.SetActive(false);
    }

    public void UpdateMissions() {
        int missionIndex = PlayerPrefs.GetInt("mission", 0);
        Mission currMission = missions[PlayerPrefs.GetInt("mission")];

        if (currMission.Done) PlayerPrefs.SetInt("mission", missionIndex + 1);
        displayHint(missions[PlayerPrefs.GetInt("mission", 0)].Objective);
    }
}