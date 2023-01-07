using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowOrPop : MonoBehaviour
{
    public float verticalGrowthRate = .1f;
    public float maxHeight = 2.0f;

    public float widthGrowthSpeed = 0.05f;
    private float widthGrowth = 0.0f;

    public float maxWidth = 2.0f;
    private float randomGrowthSpeed;

    private float randomGrowthLimit;

    private MeshRenderer mr;

    public List<Texture2D> colorPallettes;
    public int colorPallettesIndex = 0;

    void Start()
    {
       
        randomGrowthSpeed = Random.Range(0.60f, 1.05f);
        randomGrowthLimit = Random.Range(0.70f, 1.2f);
        mr = GetComponent<MeshRenderer>();
    }

    
    void Update()
    {
        Grow();

        if (Input.GetButtonDown("Jump"))
        {
            colorPallettesIndex = (colorPallettesIndex + 1) % colorPallettes.Count;
        }
    }

    public void Grow()
    {
        Vector3 newscale = transform.localScale;
        // grow taller
        newscale.y += randomGrowthSpeed * verticalGrowthRate * Time.deltaTime;

        newscale.y = Mathf.Clamp(newscale.y, 0.0f, maxHeight * randomGrowthLimit);

        widthGrowth += randomGrowthSpeed * widthGrowthSpeed * Time.deltaTime;
        widthGrowth = Mathf.Clamp(widthGrowth, 0.0f, maxWidth * randomGrowthLimit);
        newscale.x = widthGrowth;
        newscale.z = widthGrowth;

        transform.localScale = newscale;

    }

    public void Pop()
    {
        widthGrowth = 0.0f;
        transform.localScale = Vector3.zero;
        randomGrowthSpeed = Random.Range(0.9f, 1.1f); 
        randomGrowthLimit = Random.Range(0.9f, 1.1f);


        //mr.materials[0].color = Random.ColorHSV();

        mr.materials[0].color = colorPallettes[colorPallettesIndex].GetPixel(
            Random.Range(0, 
                        colorPallettes[colorPallettesIndex].width), 
                            colorPallettes[colorPallettesIndex].height/2);
    }
}
