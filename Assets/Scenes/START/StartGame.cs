using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    bool transitioning = false;
    float time = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouse = Input.mousePosition;
            mouse = Camera.main.ScreenToWorldPoint(mouse);
            if (mouse.x >= -2 && mouse.x <= 2 && mouse.y >= -4 && mouse.y <= -2)
            {
                transitioning = true;
            }
        }
        if (transitioning)
        {
            time += Time.deltaTime;
            GameObject.Find("cover").GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, time);
            if (time >= 2)
            {
                SceneManager.LoadScene("TilesScene");
            }
        }
    }
}
