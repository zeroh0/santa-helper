using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SecondGameDirector : MonoBehaviour
{
    //플레이어 - 애니메이션을 위해
    GameObject player;

    //패널
    GameObject gameHelpPnl;
    GameObject gameOverPnl;
    GameObject gameClearPnl;
    //GameObject eventPnl;

    //점수 관련
    GameObject scoretxt;
    GameObject leftGift;

    GameObject clearParticle;

    Button giftBtn;

    //public Image starImg;
    GameObject starImage;

    public int score = 0;
    public int left = 25;

    public int drop = 0; //바닥으로 떨어진 선물

    public int wall_distance = 0; //플레이어를 지나간 굴뚝 갯수

    //시간
    float nowTime;

    //반복 제한
    bool flag = false;

    private bool isPlay;

    float sound;
    AudioSource myaudio;
    public AudioClip[] sfx;

    public static bool SecondEndStory;
    bool already; 
    // Start is called before the first frame update
    void Start()
    {
        isPlay = false;

        //팝업 창을 클릭한 후에 게임 시작
        Time.timeScale = 0;

        myaudio = this.GetComponent<AudioSource>();
        sound = MainAllMenu.music_vol;
        myaudio.volume = sound;

        player = GameObject.Find("Player");

        //패널
        gameHelpPnl = GameObject.Find("GameHelpPanel");
        gameOverPnl = GameObject.Find("GameOverPanel");
        gameClearPnl = GameObject.Find("ClearPnl");
        //eventPnl = GameObject.Find("EventPanel");

        //점수
        scoretxt = GameObject.Find("Score_bg/Score");
        leftGift = GameObject.Find("GiftGage/Slider/GiftScore");

        giftBtn = GameObject.Find("GiftBtn").GetComponent<Button>();

        clearParticle = GameObject.Find("ClearParticle");
        clearParticle.SetActive(false);

        //starImg = GameObject.Find("ClearPnl/StarImg").GetComponent<Image>();
        starImage = GameObject.Find("ClearPnl/StarImg");

        //시간
        nowTime = Time.time;

        //패널 비활성화 
        gameOverPnl.SetActive(false);
        gameClearPnl.SetActive(false);
        //eventPnl.SetActive(false);

        if (MainAllMenu.rsecondClear !=0)
        {   already = true;}else{ already = false; }

        Debug.Log(MainAllMenu.rsecondClear);
    }

    // Update is called once per frame
    void Update()
    {
       
        player.GetComponent<Animator>().Play("SantaFloat"); //산타(플레이어) 둥둥 떠다니는 애니메이션
        scoretxt.GetComponent<Text>().text = "SCORE : " + score; //점수 텍스트
        leftGift.GetComponent<Text>().text = left + " / 25";
    }

    public void ButtonClick(Button btn)
    {
        switch (btn.name)
        {
            case "GameHelpPanel":
                //StartCoroutine(GameHelp());
                //gameHelpPnl.GetComponent<Animator>().Play("HidePopup");
                gameHelpPnl.SetActive(false);
                Time.timeScale = 1;
                break;
            case "EventPanel":
                StartCoroutine(EventPnl());
                //eventPnl.GetComponent<Animator>().Play("HidePopup");
                //eventPnl.SetActive(false);
                break;
            case "GoRetry":
                SceneManager.LoadScene("SecondGameScene");
                break;
            case "GoMain":
                SceneManager.LoadScene("GameSelectScene");
                Time.timeScale = 1;
                break;
            case "GODialog":
                if (already == false)
                {
                    SceneManager.LoadScene("Dialog");
                    SecondEndStory = true;
                    SaveAndExit();
                    Time.timeScale = 1;
                }else
                {
                    SceneManager.LoadScene("GameSelectScene");
                }
                break;
        }
    }

    public void GiftClick()
    {
        if (left < 0) giftBtn.interactable = false;
        else left -= 1;
    }

    void GameStop()
    {
        Time.timeScale = 0;
    }

    IEnumerator GameHelp()
    {
        yield return new WaitForSeconds(1.0f);
        gameHelpPnl.SetActive(false);
    }

    IEnumerator EventPnl()
    {
        yield return new WaitForSeconds(0f);
        //eventPnl.SetActive(false);
    }

    //점수 상승
    public void UpScore()
    {
        myaudio.clip = sfx[0];
        myaudio.Play();
        score += 5;
        Instantiate(Resources.Load("ScoreAnimParent") as GameObject, player.transform.position, Quaternion.identity);
    }

    public void DownScore()
    {
        myaudio.clip = sfx[1];
        myaudio.Play();
        if (score <= 0) score = 0;
        else score -= 5;
    }

    void ClearMusic()
    {
        myaudio.clip = sfx[2];
        myaudio.Play();
    }

    IEnumerator GameFail()
    {
        myaudio.clip = sfx[3];
        myaudio.Play();
        yield return new WaitForSeconds(0f);
    }

    //선물이 굴뚝에 맞지않아 떨어진 갯수 누적시켜 7번 이상이면 게임 오버 패널 활성화
    public void DropGift()
    {
        if (left < 0)
        {
            gameOverPnl.SetActive(true);
            gameOverPnl.GetComponent<Animator>().Play("ShowPopup");
            Invoke("GameStop", 0.3f);
            //Time.timeScale = 0;
            if (isPlay == false)
            {
                StartCoroutine(GameFail());
                isPlay = true;
            }
        }
        /*
        drop += 1;

        if(drop >= 10)
        {
            gameOverPnl.SetActive(true);
            gameOverPnl.GetComponent<Animator>().Play("ShowPopup");
            Invoke("GameStop", 0.3f);
            //Time.timeScale = 0;
            if(isPlay == false)
            {
                StartCoroutine(GameFail());
                isPlay = true;
            }
            
        }
        */
    }

    public void WallFinish()
    {
        wall_distance += 1;

        Invoke("GameFinish", 1.0f);
    }

    void GameFinish()
    {
        if (wall_distance == 15 && !flag)
        {
            flag = true;
            //eventPnl.SetActive(true);
            //Time.timeScale = 0;
            Invoke("ClearMusic", 0.3f);
            gameClearPnl.SetActive(true);
            gameClearPnl.GetComponent<Animator>().Play("ShowPopup");
            Invoke("GameStop", 0.3f);
            clearParticle.SetActive(true);

            //starchg.GetComponent<Image>().sprite = Resources.Load("images/star1", typeof(Sprite)) as Sprite; -> 이 코드를 써봤는데 NULL 에러가 발생해 다른 코드로 교체

            //점수에 따른 별 이미지
            if (score >= 0 && score <= 25)
            {
                starImage.GetComponent<Image>().sprite = Resources.Load("star1", typeof(Sprite)) as Sprite;
                MainAllMenu.rsecondClear = 1;
                //Sprite newsprite = Resources.Load<Sprite>("star1");
                //starImg.overrideSprite = newsprite;
            }

            if (score >= 26 && score <= 50)
            {
                starImage.GetComponent<Image>().sprite = Resources.Load("star2", typeof(Sprite)) as Sprite;
                MainAllMenu.rsecondClear = 2;
                //Sprite newsprite = Resources.Load<Sprite>("star2");
                //starImg.overrideSprite = newsprite;
            }

            if (score >= 51 && score <= 75)
            {
                starImage.GetComponent<Image>().sprite = Resources.Load("star3", typeof(Sprite)) as Sprite;
                MainAllMenu.rsecondClear = 3;
                //Sprite newsprite = Resources.Load<Sprite>("star3");
                //starImg.overrideSprite = newsprite;
            }
        }
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
