using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickToPop : MonoBehaviour
{
    Camera raycastCamera;

    private void Start()
    {
        raycastCamera = GetComponent<Camera>(); 
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = raycastCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;

            hit.transform.GetComponent<Wiggle>().Activate();

            // Pressing down
            if (Input.GetMouseButton(0))
            {
                Debug.Log("MOUSE DOWN!");

                // Do something with the object that was hit by the raycast.
                hit.transform.GetComponent<GrowOrPop>().Pop();
            }

            
        }
    }
}
