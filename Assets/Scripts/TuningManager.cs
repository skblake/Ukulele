 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuningManager : MonoBehaviour
{
    public float currentSpriteIndexSmooth;
    public int tuningVariable = 1;
    public int selectedKey = 0;
    public GameObject[] keys = new GameObject[4];
    public GameObject[] strings = new GameObject[4];
    public AudioSource[] sounds = new AudioSource[4];

    void Start()
    {
        
    }

    void Update()
    {
        /////////////////////////////// CONTROLS /////////////////////////////////
        if (Input.GetKeyDown(KeyCode.Return)) {
            strumAll();
        } else if (Input.GetKeyDown(KeyCode.Space) && selectedKey != 0) {
            strum();
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
        Debug.Log("Strum " + selectedKey);
        sounds[selectedKey - 1].Play();
    }

    void strumAll() {
        Debug.Log("Strum all");
    }
}