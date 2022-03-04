using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialougeTrigger : MonoBehaviour
{
    public Dialogue info;
    public Dialogue info2;
    public Dialogue info3;
    public Dialogue info4;
    public Dialogue info5;
    public Dialogue info6;
    public Dialogue info7;
    public Dialogue info8;

    public static bool cookiefirstScene;
    public static bool cookietwoScene;
    public static bool cookiethreeScene;
    public static bool cookiefourScene;
    public static bool cookiefiveScene;
    public static bool cookiesixScene;
    public static bool cookiesevenScene;
    void Start()
    {
       if(MainAllMenu.firstClear == 0)
        {
            Trigger();
            cookiefirstScene = true;
        }

       if(GameDirector.fClear == true)
        {
            Trigger2();
           
        }
        if (MainAllMenu.rsecondClear == 0 && GameDirector.fClear == false && MainAllMenu.firstClear != 0)
        {
            Trigger3();
            cookietwoScene = true;
          
        }
        if ( SecondGameDirector.SecondEndStory == true)
        {
            Trigger4();
            cookiethreeScene = true;
          

        }
        if(MainAllMenu.firstClear != 0 && MainAllMenu.rsecondClear !=0 &&  MainAllMenu.secondClear == 0 && SecondGameDirector.SecondEndStory == false)
        {
            Trigger5();
            cookiefourScene = true;
          
        }
        if(GameManager.ThirdGameClear == true)
        {
            Trigger6();
            cookiefiveScene = true;
           
        }
        if (MainAllMenu.firstClear != 0 && MainAllMenu.rsecondClear != 0 && MainAllMenu.secondClear != 0 && MainAllMenu.thirdClear ==0 && GameManager.ThirdGameClear == false)
        {
            Trigger7();
            cookiesixScene = true;
        }
        if (FifthGameDirector.lastClear == true)
        {
            Trigger8();
            cookiesevenScene = true;
        }
        
    }
    public void Trigger()
    {
        var system = FindObjectOfType<DialogueManager>();
        system.Begin(info);
    }
    public void Trigger2()
    {
        var system = FindObjectOfType<DialogueManager>();
        system.Begin(info2);
    }
    public void Trigger3()
    {
        var system = FindObjectOfType<DialogueManager>();
        system.Begin(info3);
    }
    public void Trigger4()
    {
        var system = FindObjectOfType<DialogueManager>();
        system.Begin(info4);
    }
    public void Trigger5()
    {
        var system = FindObjectOfType<DialogueManager>();
        system.Begin(info5);
    }
    public void Trigger6()
    {
        var system = FindObjectOfType<DialogueManager>();
        system.Begin(info6);
    }
    public void Trigger7()
    {
        var system = FindObjectOfType<DialogueManager>();
        system.Begin(info7);
    }
    public void Trigger8()
    {
        var system = FindObjectOfType<DialogueManager>();
        system.Begin(info8);
    }
   
}
