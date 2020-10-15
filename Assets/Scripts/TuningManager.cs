 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuningManager : MonoBehaviour
{
    public float currentSpriteIndexSmooth;
    public int tuningVariable = 1;
    public List<GameObject> keys;
    public List<GameObject> strings;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            strum();
        } else if (Input.GetKeyDown(KeyCode.Return)) {
            strumAll();
        }

    }

    /*public float smoothIndex(int currentSpriteIndex) {
        currentSpriteIndexSmooth += Input.GetAxis("Mouse ScrollWheel") 
            * Time.deltaTime * tuningVariable;
        if (currentSpriteIndexSmooth > 4) {
            return 0;
        } else if (currentSpriteIndexSmooth < 0) {
            return 4;
        }
        return currentSpriteIndex;
    }*/

    //selects the key # passed in, deselects the others    
    public void selectKey(int keyNum)
    {
        for(int i = 0; i < 4; i++)
        {
            keys[i].GetComponent<TuningKey3D>().selected = false;
        }
        keys[keyNum].GetComponent<TuningKey3D>().selected = true;

    }

    void strum() {
        Debug.Log("Strum");
    }

    void strumAll() {
        Debug.Log("Strum all");
    }
}