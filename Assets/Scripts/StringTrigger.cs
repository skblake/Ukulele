using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringTrigger : MonoBehaviour
{
    public TuningManager manager;
    public int keyNum;

    void OnMouseDown() {
        manager.strum(keyNum);
    }
}
