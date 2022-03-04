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



    // Start is called before the first frame update
    void Start()
    { 
        ApplicationChrome.statusBarState = ApplicationChrome.States.VisibleOverContent;

        myaudio = GameObject.Find("CookieScript").GetComponent<AudioSource>();

        sl = LoadIngameData();
        if (sl != null) music_vol = sl.vol;
        else music_vol = 0.5f;
        myaudio.volume = music_vol;
        

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
        firstStart.SetActive(false);
        secondStart.SetActive(false);
        thirdStart.SetActive(false);
        fourthStart.SetActive(false);
        firstend.SetActive(false);
        secondend.SetActive(false);
        thirdend.SetActive(false);
        fourthend.SetActive(false);
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






    public void ButtonDown(UnityEngine.UI.Button btn)
    {
        switch (btn.name)
        {
            case "BackButton":
                SceneManager.LoadScene("TitleScene");
                break;
            case "1":
                firstStart.SetActive(true);
                break;
            case "2":
                secondStart.SetActive(true);
                break;
            case "3":
                thirdStart.SetActive(true);
                break;
            case "4":
                fourthStart.SetActive(true);
                break;
            case "5":
                firstend.SetActive(true);
                break;
            case "6":
                secondend.SetActive(true);
                break;
            case "7":
                thirdend.SetActive(true);
                break;
            case "8":
                fourthend.SetActive(true);
                break;
            case "FirstStart":
                firstStart.SetActive(false);
                break;
            case "SecondStart":
                secondStart.SetActive(false);
                break;
            case "ThirdStart":
                thirdStart.SetActive(false);
                break;
            case "FourthStart":
                fourthStart.SetActive(false);
                break;
            case "FirstEnd":
                firstend.SetActive(false);
                break;
            case "SecondEnd":
                secondend.SetActive(false);
                break;
            case "ThirdEnd":
                thirdend.SetActive(false);
                break;
            case "FourthEnd":
                fourthend.SetActive(false);
                break;
        }
    }
}
