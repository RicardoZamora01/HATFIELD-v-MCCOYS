using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooldown : MonoBehaviour
{
    public bool active = true;
    public float timer = 5;
    public float timerMax = 5;
    public KeyCode fire;

    public void initializeFireBar() {
        // called inside CharacterMovement.cs
        active = false;
        timer = 0;
        transform.localScale = new Vector3(1, 1.001f, 1);
    }

    void Update()
    {
        if (timer >= timerMax) { active = true; }

        // if (timer >= timerMax) {
        //     active = true;
        //     if (Input.GetKeyDown(fire)) {
        //         //active = false; // set to false in CharacterMovement.cs
        //         timer = 0;
        //         transform.localScale = new Vector3(1, 1.001f, 1);
        //     }
        // }

        if (timer < timerMax) {
            timer += Time.deltaTime;
            transform.localScale = new Vector3(1 - (timer / timerMax), 1.001f, 1);
        }
    }
}
