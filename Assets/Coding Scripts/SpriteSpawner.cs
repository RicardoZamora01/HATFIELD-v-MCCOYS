using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSpawner : MonoBehaviour
{
    private int gridWidth;
    private int gridHeight;
    private int waterWellCount;
    private int trenchesCount;

    [SerializeField] private GameObject haystack;
    [SerializeField] private GameObject crops;
    [SerializeField] private GameObject waterWell;
    [SerializeField] private GameObject trench;
    [SerializeField] private GameObject tractorLeft;
    [SerializeField] private GameObject tractorRight;
    [SerializeField] private AudioSource gameplayAudio;

    void SpawnTractor(int minX, int maxX,int minY, int maxY, int tractors){
        int tractorCount = 0;
        for (int x = minX; x < maxX; x++) {
            for (int y = minY; y < maxY; y++) {
                int tractorRNG = (int)Random.Range(0, 100);
                if (tractorRNG % 2 == 0 && tractorCount < tractors) {
                    float leftX = x - 0.18f;
                    float leftY = y + 0.58f;

                    float rightX = x + 1.56f;
                    float rightY = y + 0.65f;

                    var tractorLeftInstance = Instantiate(tractorLeft, new Vector3(leftX,leftY,0f), Quaternion.identity);
                    var tractorRightInstance = Instantiate(tractorRight, new Vector3(rightX,rightY,0f), Quaternion.identity);

                    tractorRightInstance.name = $"Tractor Right {x} {y}";
                    tractorLeftInstance.name = $"Tractor Left {x} {y}";

                    int y1 = y + 1;
                    int x1 = x + 1;
                    int x2 = x + 2;

                    GameObject.Find($"Tile {x} {y}").GetComponent<Tile>().isFilled = true;
                    //GameObject.Find($"Tile {x} {y1}").GetComponent<Tile>().isFilled = true;
                    GameObject.Find($"Tile {x1} {y}").GetComponent<Tile>().isFilled = true;
                    GameObject.Find($"Tile {x1} {y1}").GetComponent<Tile>().isFilled = true;
                    GameObject.Find($"Tile {x2} {y}").GetComponent<Tile>().isFilled = true;
                    GameObject.Find($"Tile {x2} {y1}").GetComponent<Tile>().isFilled = true;

                    tractorCount += 1;
                }
            }
        }
    }

    void DestroySector(int minX, int maxX, int minY, int maxY){
        
        for (int x = minX; x < maxX; x++) {
            for (int y = minY; y < maxY; y++) {
                if (GameObject.Find($"Hay {x} {y}") != null){
                    Destroy(GameObject.Find($"Hay {x} {y}"));
                    GameObject.Find($"Tile {x} {y}").GetComponent<Tile>().isFilled = false;
                }
                else if (GameObject.Find($"Crops {x} {y}") != null){
                    Destroy(GameObject.Find($"Crops {x} {y}"));
                    GameObject.Find($"Tile {x} {y}").GetComponent<Tile>().isFilled = false;
                }
            }
        }
    }

    void playFarmerMusic(){
        gameplayAudio.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        playFarmerMusic();

         // get and set necessary variables for algorithm
        gridWidth = FindObjectOfType<GridManager>().GetComponent<GridManager>()._width;
        gridHeight = FindObjectOfType<GridManager>().GetComponent<GridManager>()._height;
        waterWellCount = 0;
        trenchesCount = 0;

        // Create Barn

        // barn 1 tiles filled: [0][11-13] [1][11-13] [2][11-13]
        for (int x = 0; x < 3; x++){
            for (int y = 11; y < 14; y++){
                GameObject.Find($"Tile {x} {y}").GetComponent<Tile>().isFilled = true;
            }
        }

        // barn 2 tiles filled: [48][11-13] [49][11-13] [50][11-13]

        for (int x = 48; x < 51; x++){
            for (int y = 11; y < 14; y++){
                GameObject.Find($"Tile {x} {y}").GetComponent<Tile>().isFilled = true;
            }
        }

        // Create Tractors

        // create player 1 tractor
        SpawnTractor(9, 18, 13, 18, 1);
        
        //create player 2 tractor
        SpawnTractor(32, 41, 3, 8, 1);
        




       

        //Middle Row is Taken care of, and should be filled with either well or trenches and nothing else
        for (int y = 0; y < gridHeight; y++){
            int x = 25;
            int num = Random.Range(0, 100);
            

            if (num < 30 && num > 10 && waterWellCount < 6) {
                var waterWellInstance = Instantiate(waterWell, new Vector3(x,y,0), Quaternion.identity);
                waterWellInstance.name = $"Water Well {x} {y}";
                GameObject.Find($"Tile {x} {y}").GetComponent<Tile>().isFilled = true;
                waterWellCount += 1;
            }
            
            else if(num > 50 && num < 80 && trenchesCount < 6){
                var trenchInstance = Instantiate(trench, new Vector3(x,y,0), Quaternion.identity);
                trenchInstance.name = $"Trench {x} {y}";
                GameObject.Find($"Tile {x} {y}").GetComponent<Tile>().isFilled = true;
                trenchesCount += 1;
            }

        }

        // Randomly filling out other tiles with crops and hay
        for (int x = 0; x < gridWidth; x++) {
            if (x != 25) {
                for (int y = 0; y < gridHeight; y++){
                // now we have to keep the middle line blank
                    int num = Random.Range(0, 1000);
                    if (((num < 100 && num > 75) || (num > 500 && num < 550) || (num > 900 && num < 950)) 
                            && GameObject.Find($"Tile {x} {y}").GetComponent<Tile>().isFilled == false 
                            )
                    {
                        var hayInstance = Instantiate(haystack, new Vector3(x,y,0), Quaternion.identity);
                        hayInstance.name = $"Hay {x} {y}";
                        GameObject.Find($"Tile {x} {y}").GetComponent<Tile>().isFilled = true;
                        //FindObjectOfType<Tile>().GetComponent<Tile>().isFilled = true;
                    }

                    else if (((num > 0 && num < 50) || (num > 200 && num < 250) || (num > 700 && num < 750)) 
                                    && GameObject.Find($"Tile {x} {y}").GetComponent<Tile>().isFilled == false
                                    )
                    {
                        var cropsInstance = Instantiate(crops, new Vector3(x,y,0), Quaternion.identity);
                        cropsInstance.name = $"Crops {x} {y}";
                        GameObject.Find($"Tile {x} {y}").GetComponent<Tile>().isFilled = true;
                    }

                }

            }
        }

        DestroySector(0,5,9,16);
        DestroySector(46,51,9,16);


    }

    // Update is called once per frame
    void Update()
    {

    }
}
