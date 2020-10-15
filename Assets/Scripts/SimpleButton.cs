using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleButton : MonoBehaviour
{
    public string buttonText;
    public GameObject screenObj;
    void OnMouseDown() {
        Debug.Log("MOUSE DOWN");
        if (buttonText == "?") {
            //INSTANTIATE HELP CONTROLS
        } else if (buttonText == ">" || buttonText == "X") {
            closeWindow();
        } 
    }

    void closeWindow() {
        foreach(Transform child in screenObj.GetComponent<Transform>()) {
            child.gameObject.SetActive(false);
        }
        screenObj.SetActive(false);
    }
}
