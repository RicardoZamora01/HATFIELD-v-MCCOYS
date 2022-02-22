using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    // [SerializeField] private SpriteRenderer _renderer;
    public bool isBurning = false;
    public bool isBurnt = false;
    public float BurntInterval = 33;
    private float time = 0;
    public Sprite burntHay;
    // private float time = 0;

    public void Update()
    {
        if (!isBurning)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
        }
        if (isBurning)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
            time += Time.deltaTime;
            if (time >= BurntInterval)
            {
                string tileName = "Tile " + this.name.Substring(5);
                isBurning = false;
                isBurnt = true;
                this.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
                GameObject.Find(tileName).GetComponent<SpriteRenderer>().color = Color.gray;
                if (GameObject.Find("Hay " + this.name.Substring(5)) != null)
                {
                    GameObject hay = GameObject.Find("Hay " + this.name.Substring(5));
                    hay.GetComponent<SpriteRenderer>().sprite = burntHay;
                }
            }
        }
    }
}
