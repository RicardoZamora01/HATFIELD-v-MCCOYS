using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundaries : MonoBehaviour
{
    private float objectWidth;
    private float objectHeight;
    public int gridWidth, gridHeight;


    // Use this for initialization
    void Start () {
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2
        gridWidth = FindObjectOfType<GridManager>().GetComponent<GridManager>()._width;
        gridHeight = FindObjectOfType<GridManager>().GetComponent<GridManager>()._height;

    }

    // Update is called once per frame
    void Update(){

        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, 0, gridWidth - objectWidth * 2);
        viewPos.y = Mathf.Clamp(viewPos.y, 0, gridHeight - objectHeight * 2);
        transform.position = viewPos;

    }
}
