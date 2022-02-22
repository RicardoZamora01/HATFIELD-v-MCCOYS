using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepCooldown : MonoBehaviour
{
    public float stepMax = 10;
    public float step = 10;
    public KeyCode water;
    public bool active = true;

    void Update()
    {
        transform.localScale = new Vector3((stepMax - step) / stepMax, 1.001f, 1);
        if (step > 0) { active = true; }
        if (step == 0) { active = false; }
    }
}
