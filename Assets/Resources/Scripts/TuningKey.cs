using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuningKey : MonoBehaviour
{
    public int keyNum = 0;
    public bool selected = true; //CURRENTLY DEFAULTS TRUE
    public TuningManager manager;
    //public LinkedList<Texture2D> sprites = new LinkedList<Texture2D>();

    private Sprite[] sprites = new Sprite[5];
    private int currentSprite = 0;

    private int loopSprite (int index) => sprites.Length % index;

    void Start() {
        randomizeSprite();
        loadSprites();
        Debug.Log(-1 % 5);
    }

    void Update() {
        ///////////////////////////// UPDATE SPRITE //////////////////////////////
        if (manager.mouse.scrolled != 0 && selected) {
            currentSprite += manager.mouse.scrolled;
            if (currentSprite >= sprites.Length || currentSprite < 0) {
                Debug.Log("Wrap index");
                loopSprite(currentSprite);
            }
            Debug.Log("Setting sprite " + currentSprite);
            GetComponent<SpriteRenderer>().sprite = sprites[currentSprite];
            manager.mouse.scrolled = 0;
        }
        
        ///////////////////////////// UPDATE PITCH //////////////////////////////
    }
    
    void loadSprites() {
        for (int i = 0; i < sprites.Length; i++) {
            //Debug.Log("Added sprite " + i);
            sprites[i] = Resources.Load<Sprite>("Sprites/TuningKeys_" + i);
        }
        /*sprites[0] = Resources.Load<Texture2D>("Sprites/TuningKeys_0");
        sprites[1] = Resources.Load<Texture2D>("Sprites/TuningKeys_1");
        sprites[2] = Resources.Load<Texture2D>("Sprites/TuningKeys_2");
        sprites[3] = Resources.Load<Texture2D>("Sprites/TuningKeys_3");
        sprites[4] = Resources.Load<Texture2D>("Sprites/TuningKeys_4");*/
    }

    Sprite randomizeSprite() {
        int spriteIndex = (int)Random.Range(0, 4);
        return sprites[spriteIndex];
    }
}
