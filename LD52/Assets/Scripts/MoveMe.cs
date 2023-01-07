using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMe : MonoBehaviour
{
    public float speed = 1.0f;

    public float scrollZoomSpeed = 5.0f;
    
    public float height = 1.5f;
    public float bobHeight = .1f;
    public float bobFreq = 30.0f;


    private Vector3 velocity;
    void Start()
    {
        velocity = Vector3.zero;
        transform.position += height * Vector3.up;
    }

    
    void Update()
    {
        // rotated 
        velocity.z = Input.GetAxis("Vertical");
        velocity.x = Input.GetAxis("Horizontal");
        velocity.y = bobHeight*Mathf.Sin(Time.time*bobFreq);
        velocity.y += -Input.mouseScrollDelta.y * scrollZoomSpeed * transform.position.y;
        transform.position += velocity * Time.deltaTime;

    }
}
