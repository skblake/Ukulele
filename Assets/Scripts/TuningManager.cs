 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuningManager : MonoBehaviour
{
    public float currentSpriteIndexSmooth;
    public int tuningVariable = 1;
    public List<GameObject> keys;

    void Start()
    {
        
    }

    void Update()
    {

    }

    public float smoothIndex(int currentSpriteIndex) {
        currentSpriteIndexSmooth += Input.GetAxis("Mouse ScrollWheel") 
            * Time.deltaTime * tuningVariable;
        if (currentSpriteIndexSmooth > 4) {
            return 0;
        } else if (currentSpriteIndexSmooth < 0) {
            return 4;
        }
        return currentSpriteIndex;
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
}