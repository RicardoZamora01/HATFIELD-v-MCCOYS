using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour {
    [SerializeField] public int _width, _height;
    [SerializeField] public Tile _tilePrefab;
    [SerializeField] public GameObject _firePrefab;
    [SerializeField] public Transform _cam;

    void Start() {
        GenerateGrid();
    }

    void GenerateGrid() {
        for (int x = 0; x < _width; x++) {
            for (int y = 0; y < _height; y++) {
                // generate ground tiles
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";
                // give alternating color
                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnedTile.Init(isOffset);
                // generate fire animation tiles
                var fireTile = Instantiate(_firePrefab, new Vector3(x, y), Quaternion.identity);
                fireTile.name = $"Fire {x} {y}";
            }
        }

        _cam.transform.position = new Vector3((float)_width/2 -0.5f, (float)_height/2 - 0.5f,-10);
    }


}
