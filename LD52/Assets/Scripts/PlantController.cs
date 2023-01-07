using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantController : MonoBehaviour
{
    public GameObject plant;
    public int plantsWide = 50;
    public int plantsHigh = 50;

    float horizontalSpacing = 1.0f;
    float verticalSpacing = 1.0f;

    float spreadAmount = .3f;

    List<GameObject> plants = new List<GameObject>();

    void Start()
    {
        for (int i = -plantsWide/2; i < plantsWide/2; i++)
        {
            for (int j = -plantsHigh/2; j < plantsHigh/2; j++)
            {
                GameObject go = Instantiate(plant) as GameObject;
                Vector3 smallRandomOffset = Random.insideUnitSphere;
                smallRandomOffset.y = 0;
                smallRandomOffset.x *= spreadAmount * horizontalSpacing;
                smallRandomOffset.z *= spreadAmount * verticalSpacing; 
                go.transform.position = new Vector3(i*horizontalSpacing, 0, j * verticalSpacing) + smallRandomOffset;
                go.transform.parent = transform;
                go.SetActive(true);
                plants.Add(go);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
