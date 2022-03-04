using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class ThirdGameDirector : MonoBehaviour
{
    //데미지(체력), 점수
    public int score = 0;
    public int dmg = 0;

    GameObject player;

    GameObject scoretxt;
    GameObject healthtxt;

    //패널
    GameObject pnlGameHelp;
    GameObject pnlStory;

    GameObject pnlGameOver;
    GameObject pnlclear;

    //별
    GameObject starImage;

    //시간
    float limitTime = 30;
    float nowTime;

    Image bar;

    GameObject animationDirector;

    //소리
        float sound;

    // Start is called before the first frame update
    void Start()
    {
        sound = MainAllMenu.music_vol;
        //패널 클릭을 하고 나서 게임 시작을 위해 게임 정지
        Time.timeScale = 0;

        player = GameObject.Find("Player");

        //데미지(체력), 점수
        scoretxt = GameObject.Find("Score_bg/Score");
        healthtxt = GameObject.Find("Health_bg/Health");

        //패널
        pnlGameHelp = GameObject.Find("GameHelpPanel"); //게임 도움말
        pnlStory = GameObject.Find("StoryPanel"); // 게임 스토리

        pnlGameOver = GameObject.Find("GameoverPanel");
        pnlclear = GameObject.Find("ClearPanel");

        //별
        starImage = GameObject.Find("ClearPanel/StarImage");

        animationDirector = GameObject.Find("AnimationExtensions");

        //시간
        nowTime = limitTime;

        bar = GameObject.Find("FullBar").GetComponent<Image>();

        //게임 오버나 클리어시 팝업 창 활성화
        pnlGameOver.SetActive(false);
        pnlclear.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        nowTime -= Time.deltaTime;
        bar.fillAmount = nowTime / limitTime;

        //시간이 흘러 0이 되었을 때
        if(nowTime < 0.0001f)
        {
            
            pnlclear.SetActive(true); //클리어 패널 활성화 
            pnlclear.GetComponent<Animator>().Play("ShowPopup"); //ShowPopup 애니메이션 재생 
            Invoke("StopGame", 0.3f); // TImeScale = 0 일때 애니메이션이 재생이 안되서 일단 Invoke 함수를 사용

            //데미지(체력)에 따른 별 이미지 
            if (dmg == 0)
            {
                starImage.GetComponent<Image>().sprite = Resources.Load("star3", typeof(Sprite)) as Sprite;
                MainAllMenu.thirdClear = 3;

            }

            if (dmg <= 3 && dmg >= 1)
            {
                starImage.GetComponent<Image>().sprite = Resources.Load("star2", typeof(Sprite)) as Sprite;
                MainAllMenu.thirdClear = 2;


            }

            if (dmg >= 4)
            {
                starImage.GetComponent<Image>().sprite = Resources.Load("star1", typeof(Sprite)) as Sprite;
                MainAllMenu.thirdClear = 1;

            }

        }

        //데미지(체력)이 10이상 일때
        if (dmg >= 10)
        {
            pnlGameOver.SetActive(true); //게임 오버 패널 활성화
            Time.timeScale = 0; // 게임 중지
        }

        //데미지(체력), 점수의 텍스트
        scoretxt.GetComponent<Text>().text = "SCORE : " + score;
        healthtxt.GetComponent<Text>().text = dmg + " / 10";


    }

    public void ButtonClick(Button btn)
    {
        switch(btn.name) {
            case "StoryPanel":
                pnlStory.SetActive(false);
                break;

            case "GameHelpPanel":
                pnlGameHelp.SetActive(false);
                Time.timeScale = 1;
                break;

            case "GoRetryBtn":
                 SceneManager.LoadScene("FirstGameScene");
                break;

            case "GoNextBtn":
                SceneManager.LoadScene("ThirdGameScene");
                break;

            case "GoMainBtn":
                SceneManager.LoadScene("GameselectScene");
                Time.timeScale = 1;
                break;
        }
    }

    //게임 중지
    void StopGame()
    {
        Time.timeScale = 0;
    }

    //데미지 누적
    public void Damage()
    {
        dmg++;
        player.GetComponent<Animator>().Play("Damage", -1, 0f);
    }

    public void SaveAndExit()
    {
        SaveIngameData(MainAllMenu.music_vol, MainAllMenu.secondClear, MainAllMenu.firstClear, MainAllMenu.rsecondClear, MainAllMenu.thirdClear);


    }

    void SaveIngameData(float vol, float secondScore, float fristScore, float rsecondScore, float thirdScore)
    {
        SaveData IngameData = new SaveData(sound, secondScore, fristScore, rsecondScore, thirdScore);
        // 데이터셋 저장
        string path = Application.persistentDataPath + "/IngameData.dat";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Open(path, FileMode.Create);
        formatter.Serialize(file, IngameData);
        file.Close();
    }

}
