 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuningManager : MonoBehaviour
{
    public MouseBehavior mouse;
    public float currentSpriteIndexSmooth;
    public int tuningVariable = 1;
    public List<GameObject> keys;

    public int goodMod (int a, int b) => (int)(a - b * Mathf.Floor(a / b));
    void Start()
    {
        


        /*
        Sprite[] spriteArray;
        int currentSpriteIndex;
        float currentSpriteIndexSmooth; //
        int tuningVariable;

        void Update() {
            currentSpriteIndexSmooth += Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * tuningVariable; //getaxis might be better than scroll delta and it's how robert usually grabs it //Framerate dependent unless multiplied by deltatime.
            //getaxis returns something between 0 and 1
        }

        ok use a regular list
        */
        
    }

    void Update()
    {
        //Debug.Log("spriteIndexSmooth: " + currentSpriteIndexSmooth);
    }

    public float smoothIndex(int currentSpriteIndex) {
        currentSpriteIndexSmooth += Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * tuningVariable;
        if (currentSpriteIndexSmooth > 4) {
            return 0;
        } else if (currentSpriteIndexSmooth < 0) {
            return 4;
        }
        return currentSpriteIndex;
    }

    //selects the key # passed in, delselects the others    
    public void selectKey(int keyNum)
    {
        for(int i = 0; i < 4; i++)
        {
            keys[i].GetComponent<TuningKey3D>().selected = false;
        }
        keys[keyNum].GetComponent<TuningKey3D>().selected = true;

    }
}