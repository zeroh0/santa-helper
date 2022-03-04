using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BGCHANGE : MonoBehaviour
{ // Start is called before the first frame update
    public Image bgground;
    public Sprite[] image = new Sprite[4];
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if ( 0 == MainAllMenu.allClear)
        {
            bgground.sprite = image[0];
        }
        if (4 > MainAllMenu.allClear && MainAllMenu.allClear > 0)
        {
            bgground.sprite = image[1];
        }
        if (7 > MainAllMenu.allClear && MainAllMenu.allClear >= 4)
        {
            bgground.sprite = image[2];
        }
         if (12 >= MainAllMenu.allClear && MainAllMenu.allClear >= 7)
        {
            bgground.sprite = image[3];
        }
    }
}