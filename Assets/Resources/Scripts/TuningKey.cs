using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuningKey : MonoBehaviour
{
    public int keyNum = 0;
    public bool selected = true; //CURRENTLY DEFAULTS TRUE
    public TuningManager manager;
    public Sprite[] sprites = new Sprite[5];
    private int currentSprite = 0;
    //private int loopSprite (int index) => manager.goodMod(sprites.Length, index);
    /*
    5 = 0
    6 = 1
    7 = 2
    8 = 3
    9 = 4
    10 = 0

    -1 = 4
    -2 = 3
    -3 = 2
    -4 = 1
    -5 = 0
    */

    void Start() {
        randomizeSprite();
        //Debug.Log(manager.goodMod(-6, 5).ToString());
    }

    void Update() {
        ///////////////////////////// UPDATE SPRITE //////////////////////////////
        /*if (manager.mouse.scrolled != 0 && selected) {
            currentSprite += manager.mouse.scrolled;
            if (currentSprite >= sprites.Length || currentSprite < 0) {
                Debug.Log("Wrap index");
                loopSprite(currentSprite);
            }
            Debug.Log("Setting sprite " + currentSprite);
            GetComponent<SpriteRenderer>().sprite = sprites[currentSprite];
            manager.mouse.scrolled = 0;
        }*/

        if (Input.GetAxis("Mouse ScrollWheel") != 0) {
            currentSprite = (int)manager.smoothIndex(currentSprite);
            manager.goodMod(currentSprite, sprites.Length);
        }

        ///////////////////////////// UPDATE PITCH //////////////////////////////
    }

    Sprite randomizeSprite() {
        int spriteIndex = (int)Random.Range(0, 4);
        return sprites[spriteIndex];
    }
}