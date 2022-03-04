using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    // Start is called before the first frame update
    public Image Star;
    public Sprite[] image = new Sprite[3];
    void Update()
    {
        if (MainAllMenu.thirdClear == 1)
        {
            Star.sprite = image[0];
        }
        else if (MainAllMenu.thirdClear == 2)
        {
            Star.sprite = image[1];
        }
        else if (MainAllMenu.thirdClear == 3)
        {
            Star.sprite = image[2];
        }
    }
}
