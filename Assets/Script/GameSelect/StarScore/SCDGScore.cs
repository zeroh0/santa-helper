using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;

public class SCDGScore : MonoBehaviour
{
    // Start is called before the first frame update
    public Image Star;
    public Sprite[] image = new Sprite[3];
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if (MainAllMenu.secondClear == 1)
        {
            Star.sprite = image[0];
        }
        else if (MainAllMenu.secondClear == 2)
        {
            Star.sprite = image[1];
        }
        else if (MainAllMenu.secondClear == 3)
        {
            Star.sprite = image[2];
        }
    }
}
