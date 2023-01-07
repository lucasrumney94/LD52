using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wiggle : MonoBehaviour
{
    public float wiggleMaxMagnitude = 25.0f;
    public float wiggleFreq = 10.0f;

    private float wiggleMagnitude = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Camera.main.transform.forward, wiggleMagnitude*Mathf.Cos(wiggleFreq * Time.time));
        if (wiggleMagnitude > 0.0f)
        {
            wiggleMagnitude *= 0.5f;
        }
    }

    public void Activate()
    {
        wiggleMagnitude += 100000.0f;
    }
}
