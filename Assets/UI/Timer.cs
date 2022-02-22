using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    private float frame = 0.0f;
    public int sec = 180;
    public string time = "3:00";
    public TMP_Text GameTimer;

    void timeGoDown() {
        frame += Time.deltaTime;
        if (frame >= 1.0f && sec >= 0)
        {
            frame -= 1.0f;
            sec -= 1;
        }
        if (sec >= 0)
        {
            if (sec % 60 > 9)
            {
                time = (sec / 60).ToString() + ":" + (sec % 60).ToString();
            } else
            {
                time = (sec / 60).ToString() + ":0" + (sec % 60).ToString();
            }
            GameTimer.text = time;
            if (sec <= 30 && sec % 2 == 0)
            {
                GameTimer.color = Color.red;
            } else
            {
                GameTimer.color = Color.white;
            }
        }
    }

    void popScreen() {
        if (sec <= 0) {
            time = "TIME'S UP!";
            GameObject burnTotal = GameObject.Find("BurntTotal");
            if (burnTotal.GetComponent<BurnTotal>().P1Burning + burnTotal.GetComponent<BurnTotal>().P1Burnt <= burnTotal.GetComponent<BurnTotal>().P2Burning + burnTotal.GetComponent<BurnTotal>().P2Burnt) {
                // Debug.Log("P1 wins");
                SceneManager.LoadScene("WIN1");
            } else {
                SceneManager.LoadScene("WIN2");
            }
        }
    }

    void Update()
    {
        timeGoDown();
        popScreen();
    }











}
