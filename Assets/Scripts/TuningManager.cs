 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuningManager : MonoBehaviour
{
    public int selectedKey = 0;
    public float strumDelay = 0.25f;
    public GameObject[] keys = new GameObject[4];
    public StringVibe[] strings = new StringVibe[4];
    public AudioSource[] sounds = new AudioSource[4];
    public float minPitch = 0.7f;
    public float maxPitch = 1.3f;
    public float pitchDelta = 0f;
    public float vol = 1f;

    private bool won = false;
    private bool tuned = false;
    private int keyIndex = -1;

    void Start()
    {
        randomizePitch();
    }

    void Update()
    {
        keyIndex = selectedKey - 1;

        ////////////// UPDATE PITCH ////////////
        if (selectedKey != 0) {
            float newPitch = sounds[keyIndex].pitch + pitchDelta;
            if (newPitch < minPitch) {
                newPitch = minPitch;
            } else if (newPitch > maxPitch) {
                newPitch = maxPitch;
            }
            sounds[keyIndex].pitch = newPitch;
            pitchDelta = 0;
        }

        /////////////////////////////// CONTROLS /////////////////////////////////
        if (Input.GetKeyDown(KeyCode.Return)) {
            StartCoroutine("strumAll", 0f);
        } else if (Input.GetKeyDown(KeyCode.Space) && selectedKey != 0) {
            strum();
        }

        ///////////// WIN CHECK ///////////
        if (won && !tuned) {
            tuned = true;
            gameEnd();
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
        sounds[keyIndex].PlayOneShot(sounds[keyIndex].clip, vol);
        strings[keyIndex].strum = true;
    }

    IEnumerator strumAll(float pause) {
        float elapsedTime = 0f;
        /////// PAUSE ///////
        while (elapsedTime <= pause) {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        elapsedTime = 0f;
        ///// STRUM ALL STRINGS /////
        for (int i = 0; i < keys.Length; i++) {
            while (elapsedTime <= strumDelay) {
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            sounds[i].PlayOneShot(sounds[i].clip, vol);
            strings[i].strum = true;
            elapsedTime = 0f;
            yield return null;
        }
        checkWin();

        yield return null;
    }

    void checkWin() {
        if (!tuned) {
            bool tune = true;
            foreach (AudioSource s in sounds) {
                if (s.pitch > 1.03f || s.pitch < 0.97f) {
                    tuned = false;
                }
            }
            won = tune;
        }
    }
    
    void randomizePitch() {
        foreach (AudioSource s in sounds) {
            s.pitch = Random.Range(minPitch, maxPitch);
            Debug.Log ("Pitch set " + s.pitch);
        }
    }

    void gameEnd() {
        Debug.Log ("Game won");
        strumDelay = 0.05f;
        vol = 0.8f;
        StartCoroutine("strumAll", 1.25f);
    }
}