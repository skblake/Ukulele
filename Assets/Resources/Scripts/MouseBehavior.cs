using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBehavior : MonoBehaviour
{
    public int scrolled = 0;
    private float _scrollDelta;
    private float _scrollPrev;
    private float _swapThreshold = 1f;

    public float scrollDelta() => Input.mouseScrollDelta.y - _scrollPrev;

    void Start()
    {
        
    }

    void Update()
    {
        /////////////////////////// SCROLL BEHAVIOR //////////////////////////////
        /*if (scrollDelta() != 0) {
            _scrollDelta += Mathf.Sign(scrollDelta());
            //Debug.Log ("scrollDelta " + _scrollDelta);
            if (Mathf.Abs(_scrollDelta) >= _swapThreshold) {
                scrolled += (int)Mathf.Sign(_scrollDelta);
                _scrollDelta = 0;
                Debug.Log("Swap " + scrolled);
            }
        }*/
        //_scrollPrev = Input.mouseScrollDelta.y;

    }
}
