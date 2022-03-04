using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBackGround : MonoBehaviour
{
    // Start is called before the first frame update
    public Image BackGround;
    public Sprite[] Image = new Sprite[8];
    void Update()
    {
        if(MainAllMenu.firstClear == 0)
        {
            BackGround.sprite = Image[0];
        }
        if (MainAllMenu.firstClear != 0 && MainAllMenu.rsecondClear == 0)
        {
           BackGround.sprite = Image[1];
        }
        if (MainAllMenu.secondClear == 0 && GameDirector.fClear == false && MainAllMenu.firstClear != 0)
        {
            BackGround.sprite = Image[2];
        }
        if (SecondGameDirector.SecondEndStory == true)
        {
            BackGround.sprite = Image[3];
        }
        if (MainAllMenu.firstClear != 0 && MainAllMenu.rsecondClear != 0 && MainAllMenu.secondClear == 0 && SecondGameDirector.SecondEndStory == false)
        {
            BackGround.sprite = Image[4];
        }
        if (GameManager.ThirdGameClear == true)
        {
            BackGround.sprite = Image[5];
        }
        if (MainAllMenu.firstClear != 0 && MainAllMenu.rsecondClear != 0 && MainAllMenu.secondClear != 0 && MainAllMenu.thirdClear == 0 && GameManager.ThirdGameClear == false)
        {
            BackGround.sprite = Image[6];
        }
        if (FifthGameDirector.lastClear == true)
        {
            BackGround.sprite = Image[7];
        }
    }
}
