using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnTotal : MonoBehaviour
{
    [Header("Percentages")]
    public int P1Burning = 0;
    public int P2Burning = 0;
    public int P1Burnt = 0;
    public int P2Burnt = 0;
    private int Max;
    public float full = .239f;

    [Header("Objects")]
    public GameObject P1Red;
    public GameObject P2Red;
    public GameObject P1Brown;
    public GameObject P2Brown;

    private int gridWidth, gridHeight;
    private float t = 0;
    public float spreadTimeInterval = 24f;

    void Start() {
        gridWidth = FindObjectOfType<GridManager>().GetComponent<GridManager>()._width;
        gridHeight = FindObjectOfType<GridManager>().GetComponent<GridManager>()._height;
        Max = gridWidth/2 * gridHeight;
    }
//
    void getBurningStats() {
        P1Burning = 0;
        P2Burning = 0;
        P1Burnt = 0;
        P2Burnt = 0;
        // p1
        for (int x = 0; x < gridWidth/2; x++) {
            for (int y = 0; y < gridHeight; y++) {
                if (GameObject.Find($"Fire {x} {y}").GetComponent<Fire>().isBurning == true) {
                    P1Burning += 1;
                }
                if (GameObject.Find($"Fire {x} {y}").GetComponent<Fire>().isBurnt == true) {
                    P1Burnt += 1;
                }
            }
        }
        // p2
        for (int x = gridWidth/2; x < gridWidth; x++) {
            for (int y = 0; y < gridHeight; y++) {
                if (GameObject.Find($"Fire {x} {y}").GetComponent<Fire>().isBurning == true) {
                    P2Burning += 1;
                }
                if (GameObject.Find($"Fire {x} {y}").GetComponent<Fire>().isBurnt == true) {
                    P2Burnt += 1;
                }
            }
        }
    }

    void fireSpread() {
        // List<(int, int)> burningFires = new List<(int, int)>();
        var burningFires = new List<KeyValuePair<int, int>>();

        for (int x = 1; x < gridWidth-1; x++) {
            for (int y = 1; y < gridHeight-1; y++) {
                if (GameObject.Find($"Fire {x} {y}").GetComponent<Fire>().isBurning == true) {
                    // Debug.Log((x,y)+" is burning");
                    burningFires.Add(new KeyValuePair<int, int>(x, y));
                }
            }
        }
        foreach (var item in burningFires) {
            int x = item.Key;
            int y = item.Value;

            GameObject f1 = GameObject.Find($"Fire {x+1} {y}");
            GameObject f2 = GameObject.Find($"Fire {x} {y+1}");
            GameObject f3 = GameObject.Find($"Fire {x-1} {y}");
            GameObject f4 = GameObject.Find($"Fire {x} {y-1}");

            f1.GetComponent<Fire>().isBurning = true;
            f2.GetComponent<Fire>().isBurning = true;
            f3.GetComponent<Fire>().isBurning = true;
            f4.GetComponent<Fire>().isBurning = true;

            f1.GetComponent<SpriteRenderer>().color = new Color(255,255,255,255);
            f2.GetComponent<SpriteRenderer>().color = new Color(255,255,255,255);
            f3.GetComponent<SpriteRenderer>().color = new Color(255,255,255,255);
            f4.GetComponent<SpriteRenderer>().color = new Color(255,255,255,255);
        }

    }

    // Update is called once per frame
    void Update()
    {
        // the fire spreads every <spreadTimeInterval>
        t += Time.deltaTime;
        if (t >= spreadTimeInterval) {
            fireSpread();
            t = 0;
        }
        getBurningStats();
        P1Red.transform.localScale = new Vector3(((float)(P1Burning + P1Burnt) / (float)Max) * full, 4, 1);
        P2Red.transform.localScale = new Vector3(((float)(P2Burning + P2Burnt) / (float)Max) * full, 4, 1);
        P1Brown.transform.localScale = new Vector3(((float)P1Burnt / (float)Max) * full, 4, 1);
        P2Brown.transform.localScale = new Vector3(((float)P2Burnt / (float)Max) * full, 4, 1);
    }














}
