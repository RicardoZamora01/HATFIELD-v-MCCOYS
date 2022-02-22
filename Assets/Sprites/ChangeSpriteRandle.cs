using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpriteRandle : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    private int arrayPos;

    public Sprite[] spriteArray;
    void ChangeSprite(int SpritePos)
    {
        spriteRenderer.sprite = spriteArray[SpritePos];
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            arrayPos = 3;
            ChangeSprite(arrayPos);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            arrayPos = 1;
            ChangeSprite(arrayPos);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            arrayPos = 0;
            ChangeSprite(arrayPos);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            arrayPos = 2;
            ChangeSprite(arrayPos);
        }
    }
}