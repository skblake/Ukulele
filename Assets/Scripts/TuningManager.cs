 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuningManager : MonoBehaviour
{
    public float currentSpriteIndexSmooth;
    public int tuningVariable = 1;
    public int selectedKey = 0;
    public float strumDelay = 0.25f;
    public GameObject[] keys = new GameObject[4];
    public StringVibe[] strings = new StringVibe[4];
    public AudioSource[] sounds = new AudioSource[4];

    private bool won = false;

    void Start()
    {
        
    }

    void Update()
    {
        /////////////////////////////// CONTROLS /////////////////////////////////
        if (Input.GetKeyDown(KeyCode.Return)) {
            StartCoroutine("strumAll");
        } else if (Input.GetKeyDown(KeyCode.Space) && selectedKey != 0) {
            strum();
        }


        ///////////// WIN CHECK ///////////
        if (won) {
            Debug.Log ("Game won");
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
        sounds[selectedKey - 1].PlayOneShot(sounds[selectedKey - 1].clip);
        strings[selectedKey - 1].strum = true;
    }

    IEnumerator strumAll() {
        ///// STRUM ALL STRINGS ///// 
        float elapsedTime = 0f;
        for (int i = 0; i < keys.Length; i++) {
            while (elapsedTime <= strumDelay) {
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            sounds[i].PlayOneShot(sounds[i].clip);
            strings[i].strum = true;
            elapsedTime = 0f;
            yield return null;
        }

        ///// CHECK WIN /////
        bool tuned = true;
        foreach (AudioSource s in sounds) {
            if (s.pitch > 1.03f || s.pitch < 0.97f) {
                tuned = false;
            }
        }
        won = tuned;
        yield return null;
    }
    
    void randomizePitch() {
        foreach (AudioSource s in sounds) {
            
        }
    }
}