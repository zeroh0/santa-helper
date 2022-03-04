using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class CookieScript : MonoBehaviour
{

    public AudioSource ButtonSound;
    AudioSource myaudio;
    float music_vol;
    SaveData sl;

    //이미지 
    GameObject firstStart;
    GameObject secondStart;
    GameObject thirdStart;
    GameObject fourthStart;
    GameObject firstend;
    GameObject secondend;
    GameObject thirdend;
    GameObject fourthend;

    public GameObject first;
    public GameObject two;
    public GameObject three;
    public GameObject four;
    public GameObject five;
    public GameObject six;
    public GameObject seven;
    public GameObject dia;
    Animator animator;
    public static float checkstory;




    // Start is called before the first frame update
    void Start()
    { 
        ApplicationChrome.statusBarState = ApplicationChrome.States.VisibleOverContent;

        myaudio = GameObject.Find("CookieScript").GetComponent<AudioSource>();
       animator = dia.GetComponent<Animator>();
        sl = LoadIngameData();
        if (sl != null) music_vol = sl.vol;
        else music_vol = 0.5f;
        myaudio.volume = music_vol;
        ButtonSound.volume = music_vol;

        //오브젝트 찾기
        firstStart = GameObject.Find("FirstStart");
        secondStart = GameObject.Find("SecondStart");
        thirdStart = GameObject.Find("ThirdStart");
        fourthStart = GameObject.Find("FourthStart");
        firstend = GameObject.Find("FirstEnd");
        secondend = GameObject.Find("SecondEnd");
        thirdend = GameObject.Find("ThirdEnd");
        fourthend =  GameObject.Find("FourthEnd");


        //비활성화
        first.GetComponent<Button>().interactable = false;
        two.GetComponent<Button>().interactable = false;
        three.GetComponent<Button>().interactable = false;
        four.GetComponent<Button>().interactable = false;
        five.GetComponent<Button>().interactable = false;
        six.GetComponent<Button>().interactable = false;
        seven.GetComponent<Button>().interactable = false;
        firstStart.SetActive(false);
        secondStart.SetActive(false);
        thirdStart.SetActive(false);
        fourthStart.SetActive(false);
        firstend.SetActive(false);
        secondend.SetActive(false);
        thirdend.SetActive(false);
        fourthend.SetActive(false);

        animator.SetBool("click", false);
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
        }

        checkbutton();
    }

    SaveData LoadIngameData()
    {
        // 데이터셋 로드
        string path = Application.persistentDataPath + "/IngameData.dat";
        if (!File.Exists(path)) return null;
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Open(path, FileMode.Open);
        SaveData data = (SaveData)formatter.Deserialize(file);
        file.Close();
        return data;
    }

    public void checkbutton()
    {
        if(DialougeTrigger.cookiefirstScene== true)
        {
            first.GetComponent<Button>().interactable = true;
        }
        if (DialougeTrigger.cookietwoScene == true)
        {
            two.GetComponent<Button>().interactable = true;
        }
        if (DialougeTrigger.cookiethreeScene == true)
        {
           three.GetComponent<Button>().interactable = true;
        }
        if (DialougeTrigger.cookiefourScene == true)
        {
            four.GetComponent<Button>().interactable = true;
        }
        if (DialougeTrigger.cookiefiveScene == true)
        {
           five.GetComponent<Button>().interactable = true;

        }
        if(DialougeTrigger.cookiesixScene == true)
        {
            six.GetComponent<Button>().interactable = true;
        }
        if (DialougeTrigger.cookiesevenScene == true)
        {
            seven.GetComponent<Button>().interactable = true;
        }

    }




    public void ButtonDown(UnityEngine.UI.Button btn)
    {
        switch (btn.name)
        {
            case "BackButton":
                SceneManager.LoadScene("TitleScene");
                ButtonSound.Play();
                break;
            case "1":
                firstStart.SetActive(true);
                checkstory = 1;
                GameObject.Find("Cookietrigger").GetComponent<cookietrigger>().check();
                animator.SetBool("click", true);
                ButtonSound.Play();
                break;
            case "2":
                secondStart.SetActive(true);
                checkstory = 2;
                GameObject.Find("Cookietrigger").GetComponent<cookietrigger>().check();
                animator.SetBool("click", true);
                ButtonSound.Play();
                break;
            case "3":
                thirdStart.SetActive(true);
                checkstory = 3;
                GameObject.Find("Cookietrigger").GetComponent<cookietrigger>().check();
                animator.SetBool("click", true);
                ButtonSound.Play();
                break;
            case "4":
                fourthStart.SetActive(true);
                checkstory = 4;
                GameObject.Find("Cookietrigger").GetComponent<cookietrigger>().check();
                animator.SetBool("click", true);
                ButtonSound.Play();
                break;
            case "5":
                firstend.SetActive(true);
                checkstory = 5;
                GameObject.Find("Cookietrigger").GetComponent<cookietrigger>().check();
                animator.SetBool("click", true);
                ButtonSound.Play();
                break;
            case "6":
                secondend.SetActive(true);
                checkstory = 6;
                GameObject.Find("Cookietrigger").GetComponent<cookietrigger>().check();
                animator.SetBool("click", true);
                ButtonSound.Play();
                break;
            case "7":
                thirdend.SetActive(true);
                checkstory = 7;
                GameObject.Find("Cookietrigger").GetComponent<cookietrigger>().check();
                animator.SetBool("click", true);
                ButtonSound.Play();
                break;
            case "FirstStart":
                firstStart.SetActive(false);
                animator.SetBool("click", false);
                ButtonSound.Play();
                break;
            case "SecondStart":
                secondStart.SetActive(false);
                animator.SetBool("click", false);
                ButtonSound.Play();
                break;
            case "ThirdStart":
                thirdStart.SetActive(false);
                animator.SetBool("click", false);
                ButtonSound.Play();
                break;
            case "FourthStart":
                fourthStart.SetActive(false);
                animator.SetBool("click", false);
                ButtonSound.Play();
                break;
            case "FirstEnd":
                firstend.SetActive(false);
                animator.SetBool("click", false);
                ButtonSound.Play();
                break;
            case "SecondEnd":
                secondend.SetActive(false);
                animator.SetBool("click", false);
                ButtonSound.Play();
                break;
            case "ThirdEnd":
                thirdend.SetActive(false);
                animator.SetBool("click", false);
                ButtonSound.Play();
                break;
          
        }
    }
}
