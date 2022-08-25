using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CutsceneController : MonoBehaviour {
    VideoPlayer vid;

    void Start() {
        vid = GetComponent<VideoPlayer>();
        StartCoroutine(goToGameplayCo());
    }

    IEnumerator goToGameplayCo() {
        yield return new WaitForSeconds(1f);
        while (vid.isPlaying) yield return null;
        SceneManager.LoadScene("Gameplay");
    }
}