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


public class GameManager : MonoBehaviour
{
    #region instance
    public static GameManager instance;
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion
    public delegate void Onplay(bool isPlay);
    public Onplay onPlay;
    public int life;
    public int point;
    public GameObject Player;
    public GameObject pointer;
    public GameObject playBtn;
    GameObject Timecheck;
    public Text score;
    public Text timecheck;
    public float gameSpeed = 1;
    public bool isPlay = false;
    AudioSource myaudio;
    float sound;
    bool mob;
    bool checkpoint;
    
    public float time ;

    void Start()
    {
        mob = GameObject.FindWithTag("Mob").GetComponent<Collider2D>().isTrigger;
        checkpoint = GameObject.FindWithTag("point").GetComponent<Collider2D>().isTrigger;
        myaudio = GameObject.Find("Gamemanager").GetComponent<AudioSource>();
        sound = MainAllMenu.music_vol;

        myaudio.volume = sound;

        Timecheck = GameObject.Find("Timecheck");
        Timecheck.SetActive(false);

        ApplicationChrome.statusBarState = ApplicationChrome.States.VisibleOverContent;

        Debug.Log(MainAllMenu.music_vol);
    }
    private void Update()
    {
        
        if (isPlay == true)
        {
            time -= Time.deltaTime;
            timecheck.text = "시간:" + Mathf.Round(time);
        }

        if(Mathf.Round(time) == 0f)
        {
            GameOver();

        }
        
    }
    public void PlayBtnClick()
    {
        life = 10;
        point = 0;
        time = 60;
        playBtn.SetActive(false);
        isPlay = true;
        onPlay.Invoke(isPlay);
        Timecheck.SetActive(true);
    }

    public void GameOver()
    {
        mob = false;
        life--;
        Scorepoint();
        Invoke("EnableCol",1);
        if (life == 0)
        {
            playBtn.SetActive(true);
            isPlay = false;
            Timecheck.SetActive(false);

        }
      
    }

    public void GamePoint()
    {
        checkpoint = false;
        point += 5 ;
        score.text = "Score:" + point;
        Invoke("EnableCol",1);
    }

    public void ButtonDown(UnityEngine.UI.Button btn)
    {
        switch (btn.name)
        {
            case "Back":
                SceneManager.LoadScene("GameSelectScene");
                break;
            
     
            
        }
    }

    public void EnableCol()
    {
        mob = true;

        checkpoint = true;
    }
    
    public void Scorepoint()
    {
        if (life != 0)
        {
            if (point > 50)
            {
                MainAllMenu.secondClear = 3;
                Debug.Log(MainAllMenu.secondClear);
                SaveAndExit();
            }
            else if (point > 25)
            {
                MainAllMenu.secondClear = 2;
                Debug.Log(MainAllMenu.secondClear);
                SaveAndExit();
            }
            else 
            {
                MainAllMenu.secondClear = 1;
                Debug.Log(MainAllMenu.secondClear);
                SaveAndExit();
            }
        }
        else
        {

        }
    }

    public void SaveAndExit()
    {
        SaveIngameData(MainAllMenu.music_vol, MainAllMenu.secondClear);

        
    }
    void SaveIngameData(float vol, float secondScore)
    {
        SaveData IngameData = new SaveData(sound, secondScore);
        // 데이터셋 저장
        string path = Application.persistentDataPath + "/IngameData.dat";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Open(path, FileMode.Create);
        formatter.Serialize(file, IngameData);
        file.Close();
    }

}
