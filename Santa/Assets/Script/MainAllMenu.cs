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
  
    GameObject helpPanel;
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
    public static float secondClear;
    // Start is called before the first frame update
    void Start()
    {
        ApplicationChrome.statusBarState = ApplicationChrome.States.VisibleOverContent;


        myaudio = GameObject.Find("MainAllMenu").GetComponent<AudioSource>();
        //기본
        helpPanel = GameObject.Find("helpPanel");
        SettingPanel = GameObject.Find("SettingPanel");
   
        // 도움말
        FirstGame = GameObject.Find("FirstGame");
        SecondGame = GameObject.Find("SecondGame");
        ThirdGame = GameObject.Find("ThirdGame");
        FourthGame = GameObject.Find("FourthGame");

        //처음 
        helpPanel.SetActive(false);
        SettingPanel.SetActive(false);

        // 세이브 데이터 로드
        sl = LoadIngameData();
        if (sl != null)
        {
            music_vol = sl.vol;
            secondClear = sl.secondScore;
        }
        else
        {
            music_vol = 0.5f;
            secondClear = 0;
        }
        backVolume.value = music_vol;
        myaudio.volume = music_vol;
        ButtonSound.volume = music_vol;

        Debug.Log (secondClear);
        Debug.Log(music_vol);
        

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
                helpPanel.SetActive(false);
                ButtonSound.Play();
                SaveAndExitSettingPanel();
                break;
            case "help":
                helpPanel.SetActive(true);
                ButtonSound.Play();
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
        SaveIngameData(backVolume.value ,secondClear);

        SettingPanel.SetActive(false);
    }

    void SaveIngameData(float vol , float secondScore )
    {
        SaveData IngameData = new SaveData(vol ,secondScore);
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


}

[Serializable]
class SaveData
{
    public float vol; // 사운드볼륨
   public float secondScore;
    // 필요한 데이터 여기에 추가

    public SaveData(float v,float ss)
    {
        vol = v;
        secondScore = ss;
    }

   

   
}

