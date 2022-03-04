using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class cookietrigger : MonoBehaviour
{
    public cookieread info;
    public cookieread info2;
    public cookieread info3;
    public cookieread info4;
    public cookieread info5;
    public cookieread info6;
    public cookieread info7;
    
    // Start is called before the first frame update


    public  void check()
    {
        if (CookieScript.checkstory == 1)
        {
            Trigger();
          
        }

        if (CookieScript.checkstory == 2)
        {
            Trigger2();

        }
        if (CookieScript.checkstory == 3)
        {
            Trigger3();
           

        }
        if (CookieScript.checkstory == 4)
        {
            Trigger4();
          


        }
        if (CookieScript.checkstory == 5)
        {
            Trigger5();
         

        }
        if (CookieScript.checkstory == 6)
        {
            Trigger6();
          

        }
        if (CookieScript.checkstory == 7)
        {
            Trigger7();
            
        }

    }
    public  void Trigger()
    {
        var system = FindObjectOfType<cooketext>();
        system.Begin(info);
    }
    public void Trigger2()
    {
        var system = FindObjectOfType<cooketext>();
        system.Begin(info2);
    }
    public void Trigger3()
    {
        var system = FindObjectOfType<cooketext>();
        system.Begin(info3);
    }
    public void Trigger4()
    {
        var system = FindObjectOfType<cooketext>();
        system.Begin(info4);
    }
    public void Trigger5()
    {
        var system = FindObjectOfType<cooketext>();
        system.Begin(info5);
    }
    public void Trigger6()
    {
        var system = FindObjectOfType<cooketext>();
        system.Begin(info6);
    }
    public void Trigger7()
    {
        var system = FindObjectOfType<cooketext>();
        system.Begin(info7);
    }
    
}
