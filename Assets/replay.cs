using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class replay : MonoBehaviour
{
    [SerializeField] private AudioSource gameplayAudio;

    void playMusic(){
        gameplayAudio.Play();
    }

    void Start() {
        playMusic();
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            SceneManager.LoadScene("TilesScene");
        }
    }
}
