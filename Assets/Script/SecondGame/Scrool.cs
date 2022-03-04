using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrool : MonoBehaviour
{
    private MeshRenderer render;

    public float speed;
    private float offset;
    void Start()
    {
        render = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        offset += Time.deltaTime * speed;
        render.material.mainTextureOffset = new Vector2(offset, 0);
        
    }
}
