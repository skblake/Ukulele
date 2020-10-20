using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helpTrigger : MonoBehaviour
{
    public GameObject dialog; 
    
    void OnMouseEnter() {
        dialog.SetActive(true);
    }

    void OnMouseExit() {
        dialog.SetActive(false);
    }
}
