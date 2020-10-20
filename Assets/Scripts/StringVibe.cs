using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringVibe : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public bool strum;
    public float amp;
    public AnimationCurve animationCurve;
    public List<float> anim;
    public float curveCenter = 100f;

    void Start()
    {
        lineRenderer = this.GetComponent<LineRenderer>();
        strum = false;
        //animationCurve = new AnimationCurve();
        anim = new List<float>();
        //animationCurve.AddKey(0f, 0f);
        //animationCurve.AddKey(175f, 1f);
        //animationCurve.AddKey(199f, 0f);
        //curveCenter = 100f;
    }

    void Update()
    {
        if (strum) {
            strumString();
            strum = false;
        }

        DrawTravellingSineWave(new Vector3(0, 0, 0), .5f, 20, 150);
            // older values: (new Vector3(0, 0, 0), 1, 20, 50) 
        transform.localScale = new Vector3(0.5f, amp, 1f);
        amp = amp * 0.99f;

        if (amp < 0.001f) {
            amp = 0f;
        } 
    }

    void DrawTravellingSineWave (Vector3 startPoint, float amplitude, 
        float wavelength, float waveSpeed)
    {

        float x = 0f;
        float y;
        float k = 2 * Mathf.PI / wavelength;
        float w = k * waveSpeed;
        lineRenderer.positionCount = 200;

        for (int i = 0; i < lineRenderer.positionCount; i++) {
            x += i * 0.001f;
            y = amplitude * Mathf.Sin(k * x + w * Time.time) * 
                animationCurve.Evaluate(i) * animationCurve.Evaluate(i);
            lineRenderer.SetPosition(i, new Vector3(x, y, 0) + startPoint);
        }
    }

    void strumString()
    {
        amp = 0.05f;
    }

    //public void moveCurve(float newCenter)
    //{
    //    animationCurve.MoveKey((int)curveCenter, new Keyframe(newCenter, 100f));
    //    curveCenter = newCenter;
    //}
    
}