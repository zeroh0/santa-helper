using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstScore : MonoBehaviour
{
    // Start is called before the first frame update
    public Image Star;
    public Sprite[] image = new Sprite[3];
    void Update()
    {
        if (MainAllMenu.firstClear == 1)
        {
            Star.sprite = image[0];
        }
        else if (MainAllMenu.firstClear == 2)
        {
            Star.sprite = image[1];
        }
        else if (MainAllMenu.firstClear == 3)
        {
            Star.sprite = image[2];
        }
    }
}
