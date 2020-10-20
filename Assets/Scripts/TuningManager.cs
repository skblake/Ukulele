 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuningManager : MonoBehaviour
{
    public int selectedKey = 0;
    public float strumDelay = 0.25f;
    public GameObject winBox;
    public GameObject[] keys = new GameObject[4];
    public StringVibe[] strings = new StringVibe[4];
    public AudioSource[] sounds = new AudioSource[4];
    public AudioSource[] helpSounds = new AudioSource[4];
    public float minPitch = 0.7f;
    public float maxPitch = 1.3f;
    public float pitchDelta = 0f;
    public float vol = 1f;

    private bool won = false;
    private bool tuned = false;
    private int keyIndex = -1;
    private string typed = "";

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
            if (tuned) {
                randomizePitch();
                winBox.SetActive(false);
            } else {
                StartCoroutine("strumAll", 0f);
                typed = "";
            }
        } else if (Input.GetKeyDown(KeyCode.Space) && selectedKey != 0) {
            strum();
            typed = "";
        }

        /////////////////// HELP CHECK /////////////////////

        if (Input.GetKeyDown(KeyCode.H)) {
            typed += "H";
        } else if (Input.GetKeyDown(KeyCode.E)) {
            typed += "E";
        } else if (Input.GetKeyDown(KeyCode.L)) {
            typed += "L";
        } else if (Input.GetKeyDown(KeyCode.P)) {
            typed += "P";
        }

        if (typed == "HELP") {
            StartCoroutine("strumInTune");
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

    public void strum(int toStrum = -1) {
        if (toStrum == -1) {
            toStrum = keyIndex;
        } else {
            toStrum--;
        }
        //Debug.Log("Strum " + selectedKey);
        sounds[toStrum].PlayOneShot(sounds[toStrum].clip, vol);
        strings[toStrum].strum = true;
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
                    tune = false;
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
        won = false; 
        tuned = false;
    }

    void gameEnd() {
        winBox.SetActive(true);
        strumDelay = 0.05f;
        vol = 0.8f;
        StartCoroutine("strumAll", 1.25f);
        strumDelay = 0.25f;
    }

    IEnumerator strumInTune() {
        typed = "";
        strumDelay = 0.8f;
        float elapsedTime = 0f;
        ///// STRUM ALL STRINGS /////
        for (int i = 0; i < keys.Length; i++) {
            while (elapsedTime <= strumDelay) {
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            strumDelay = 0.25f;
            helpSounds[i].PlayOneShot(helpSounds[i].clip, vol);
            strings[i].strum = true;
            elapsedTime = 0f;
            yield return null;
        }
        yield return null; 
    }
}