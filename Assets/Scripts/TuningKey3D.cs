using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuningKey3D : MonoBehaviour
{
    public int keyNum = 0;
    public bool selected = false;
    public TuningManager manager;
    public float rotation;


    void Start() 
    {
        rotation = (float)Random.Range(-600f, 600.0f);
    }

    void Update() 
    {
        if (selected) {
            
            rotation += Input.GetAxis("Mouse ScrollWheel") * -50f;
            transform.localEulerAngles = new Vector3(
                transform.localEulerAngles.x, 
                rotation, 
                transform.localEulerAngles.z);

            if (Input.GetAxis("Mouse ScrollWheel") != 0)
            {
                //Debug.Log(Input.GetAxis("Mouse ScrollWheel"));
            }

        ///////////////////////////// UPDATE PITCH //////////////////////////////
        }
    }

    void OnMouseEnter() 
    {
        Debug.Log("mouse enter");
        selected = true;
    }

    void OnMouseExit() 
    {
        Debug.Log("Mouse exit");
        selected = false;
    }

    void OnMouseOver() {
        Debug.Log("Mouse is over");
    }
}