using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UIElements;

public class MainAllMenu : MonoBehaviour
{
    //게임 버튼 오브젝트들 

    
    GameObject SettingPanel;

    // 도움말 안의 설명 버튼및 이미지
    GameObject FirstGame;
    GameObject SecondGame;
    GameObject ThirdGame;
    GameObject FourthGame;


    public AudioSource ButtonSound;
    //게임 저장기능
    public static float music_vol; // 전역변수는 어디서나 사용 가능
    public UnityEngine.UI.Slider backVolume; //볼륨바
    AudioSource myaudio;

    SaveData sl;
    //게임 클리어 여부
    public static float secondClear; //3번 게임 클리어 
    public static float firstClear; //1번 게임 클리어
    public static float rsecondClear; //2 번 게임 클리어
    public static float thirdClear;//마지막  게임 클리어

    public static float allClear;// 모든 게임 총합
                                 //씬 실행 여부 획인 변수 




   
    
    //스토리 스킵 버튼

    void Start()
    {
        ApplicationChrome.statusBarState = ApplicationChrome.States.VisibleOverContent;

      

        myaudio = GameObject.Find("MainAllMenu").GetComponent<AudioSource>();
         
        //기본
        
        SettingPanel = GameObject.Find("SettingPanel");

     
        

        // 도움말
        FirstGame = GameObject.Find("FirstGame");
        SecondGame = GameObject.Find("SecondGame");
        ThirdGame = GameObject.Find("ThirdGame");
        FourthGame = GameObject.Find("FourthGame");


        
        //처음 
       
        SettingPanel.SetActive(false);

        // 세이브 데이터 로드
        sl = LoadIngameData();
        if (sl != null)
        {
            music_vol = sl.vol;
            firstClear = sl.firstScore;
            secondClear = sl.secondScore;
            rsecondClear = sl.rsecondScore;
            thirdClear = sl.thirdScore;
          
            

        }
        else
        {
            music_vol = 0.5f;
            firstClear = 0;
            secondClear = 0;
            rsecondClear = 0;
            thirdClear = 0;
          
           
        }
       
        backVolume.value = music_vol;
        myaudio.volume = music_vol;
        ButtonSound.volume = music_vol;
        allClear = firstClear + rsecondClear + secondClear + thirdClear;

      
        Debug.Log(firstClear);
        Debug.Log(rsecondClear);
        Debug.Log(secondClear);
        Debug.Log(thirdClear);
        Debug.Log(music_vol);
        Debug.Log(allClear);

        cookie();

        //스토리씬 실행 여부 확인


    }

    // Update is called once per frame
    void Update()
    {
        myaudio.volume = backVolume.value;
        ButtonSound.volume = backVolume.value;

        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
       

    }

  
    public void ButtonDown(UnityEngine.UI.Button btn)
    {
        switch(btn.name)
        {
            case "SETClose":
               
                ButtonSound.Play();
                SaveAndExitSettingPanel();
                break;
          
            case "Gellay":
                SceneManager.LoadScene("cookieScene");
                ButtonSound.Play();
                break;
            case "Start":
                SceneManager.LoadScene("GameSelectScene");
                ButtonSound.Play();
                break;
            case "Setting":
                SettingPanel.SetActive(true);
                ButtonSound.Play();
                break;
            // 도움말 전환
            case "FirstgameBTN":
                ButtonSound.Play();
                FirstGame.SetActive(true);
                SecondGame.SetActive(false);
                ThirdGame.SetActive(false);
                FourthGame.SetActive(false);
                break;
            case "SecondGameBTN":
                ButtonSound.Play();
                FirstGame.SetActive(false);
                SecondGame.SetActive(true);
                ThirdGame.SetActive(false);
                FourthGame.SetActive(false);
                break;
            case "ThirdGameBTN":
                ButtonSound.Play();
                FirstGame.SetActive(false);
                SecondGame.SetActive(false);
                ThirdGame.SetActive(true);
                FourthGame.SetActive(false);
                break;
            case "FourthGameBTN":
                ButtonSound.Play();
                FirstGame.SetActive(false);
                SecondGame.SetActive(false);
                ThirdGame.SetActive(false);
                FourthGame.SetActive(true);
                break;
            
        }
    }

    public void SaveAndExitSettingPanel()
    {
        SaveIngameData(backVolume.value ,secondClear , firstClear ,rsecondClear ,thirdClear );

        SettingPanel.SetActive(false);
    }

    void SaveIngameData(float vol, float secondScore, float firstScore, float rsecondScore , float thirdScore)
    {
        SaveData IngameData = new SaveData(vol ,secondScore ,firstScore , rsecondScore , thirdScore);
        // 데이터셋 저장
        string path = Application.persistentDataPath + "/IngameData.dat";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Open(path, FileMode.Create);
        formatter.Serialize(file, IngameData);
        file.Close();
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

    public void cookie()
    {
        if(firstClear != 0)
        {
            DialougeTrigger.cookiefirstScene = true;
        }
        if(secondClear != 0)
        {
            DialougeTrigger.cookiefourScene = true;
            DialougeTrigger.cookiefiveScene = true;
           
        }
        if(rsecondClear != 0)
        {
            DialougeTrigger.cookietwoScene = true;
            DialougeTrigger.cookiethreeScene = true;
        }
        if(thirdClear != 0)
        {
            DialougeTrigger.cookiesixScene = true;
            DialougeTrigger.cookiesevenScene = true;
        }
    }
  
    
    public void togglecontrol(UnityEngine.UI.Toggle toggletest)
    {
        if (toggletest.isOn)
        {
           
            ButtonSound.Play();
            Debug.Log("토글 온");
        }
        else
        {
           
            ButtonSound.Play();
            Debug.Log("토글 오프");
        }
    }

}

[Serializable]
class SaveData
{
    public float vol; // 사운드볼륨
    public float secondScore;//3번쨰 게임 세이브
    public float firstScore;//1번쨰 게임 세이브
    public float rsecondScore; // 2번쨰 게임 세이브 r은 real
    public float thirdScore;  //마지막 게임
  
    // 필요한 데이터 여기에 추가

    public SaveData(float v,float ss ,float fs ,float rs ,float ts)
    {
        vol = v;
        firstScore = fs;
        rsecondScore = rs;
        secondScore = ss;
        thirdScore = ts;
      

    }

   

   
}

