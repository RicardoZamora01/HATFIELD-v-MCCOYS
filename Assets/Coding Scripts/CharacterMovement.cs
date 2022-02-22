using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public int player;
    private int direction = 3;
    [SerializeField] private KeyCode right, up, left, down, fire, water;

    // sprites
    public SpriteRenderer spriteRenderer;
    private int arrayPos;
    public Sprite[] spriteArray;
    void ChangeSprite(int SpritePos)
    {
        spriteRenderer.sprite = spriteArray[SpritePos];
    }

    void Movement() {
        Vector3 pos = transform.position;
        float x = Mathf.Ceil(transform.position.x);
        float y = Mathf.Ceil(transform.position.y);

        if (Input.GetKeyDown(right)) {
            pos.x += 1;
            direction = 0;
            x += 1;
            ChangeSprite(direction);
        }
        if (Input.GetKeyDown(up)) {
            pos.y += 1;
            direction = 1;
            y += 1;
            ChangeSprite(direction);
        }
        if (Input.GetKeyDown(left)) {
            pos.x -= 1;
            direction = 2;
            x -= 1;
            ChangeSprite(direction);
        }
        if (Input.GetKeyDown(down)) {
            pos.y -= 1;
            direction = 3;
            y -= 1;
            ChangeSprite(direction);//
        }

        GameObject fire = GameObject.Find($"Fire {(int)x} {(int)y}");
        GameObject tile = GameObject.Find($"Tile {(int)x} {(int)y}");
        if (fire.GetComponent<Fire>().isBurning == false && tile.GetComponent<Tile>().isFilled == false) {
            transform.position = pos;
        }
    }//

    void setFireWater() {
        float x = Mathf.Ceil(transform.position.x);
        float y = Mathf.Ceil(transform.position.y);
        if (direction == 0) { x += 1; }
        if (direction == 1) { y += 1; }
        if (direction == 2) { x -= 1; }
        if (direction == 3) { y -= 1; }

        if (Input.GetKeyDown(fire)) {
            GameObject fire = GameObject.Find($"Fire {(int)x} {(int)y}");
            GameObject tile = GameObject.Find($"Tile {(int)x} {(int)y}");
            // GameObject firebar = GameObject.Find($"firebar{player}").transform.Find("firebarempty");
            GameObject firebar = GameObject.Find($"firebar{player}/firebarempty");

            if (fire.GetComponent<Fire>().isBurning == false && tile.GetComponent<Tile>().isFilled == true && firebar.GetComponent<Cooldown>().active == true) {
                // reveal the fire by setting Color(_,_,_,255)
                fire.GetComponent<SpriteRenderer>().color = new Color(255,255,255,255);
                // firebar.GetComponent<Cooldown>().active = false;
                firebar.GetComponent<Cooldown>().initializeFireBar();
                fire.GetComponent<Fire>().isBurning = true;
            }
        }

        if (Input.GetKeyDown(water)) {
            GameObject fire = GameObject.Find($"Fire {(int)x} {(int)y}");
            GameObject tile = GameObject.Find($"Tile {(int)x} {(int)y}");
            GameObject waterbar = GameObject.Find($"waterbar{player}/waterbarempty");

            if (fire.GetComponent<Fire>().isBurning == true && waterbar.GetComponent<StepCooldown>().active == true /* && tile.GetComponent<Tile>().isFilled == true */) {
                // hide the fire by setting Color(_,_,_,0)
                fire.GetComponent<SpriteRenderer>().color = new Color(255,255,255,0);
                fire.GetComponent<Fire>().isBurning = false;
                waterbar.GetComponent<StepCooldown>().step -= 1;
            }

            if (GameObject.Find($"Water Well {x} {y}") != null)
            {
                waterbar.GetComponent<StepCooldown>().step = waterbar.GetComponent<StepCooldown>().stepMax;
            }
        }

    }

    void Update()
    {
        Movement();
        setFireWater();
    }






















}
