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
        /////////////////////////////// CONTROLS /////////////////////////////////
        if (Input.GetKeyDown(KeyCode.Space)) {
            strum();
        } else if (Input.GetKeyDown(KeyCode.Return)) {
            strumAll();
        }

    }

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