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
    public GameObject JUPButton;
    public static bool ThirdGameClear;
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
    public GameObject ClearBTN;
    public GameObject GameOverBTN;
   
    public Text score;
    
    public float gameSpeed;
    public bool isPlay = false;
    bool sfxPlay = false;
    AudioSource myaudio;
    float sound;
    bool mob;
    bool checkpoint;
    public AudioClip[] msic = new AudioClip[5];

    Animator animator;

    GameObject clearParticle;

    public float time ;

    public bool alreadyStory;


    UnityEngine.UI.Image bar;
    void Start()
    {


        ApplicationChrome.statusBarState = ApplicationChrome.States.VisibleOverContent;

        if (MainAllMenu.secondClear==0)
        {
            alreadyStory = false;
        }
        else { alreadyStory = true; }

        ThirdGameClear = false;

        mob = GameObject.FindWithTag("Mob").GetComponent<Collider2D>().isTrigger;
        checkpoint = GameObject.FindWithTag("point").GetComponent<Collider2D>().isTrigger;
        myaudio = GameObject.Find("Gamemanager").GetComponent<AudioSource>();
        sound = MainAllMenu.music_vol;

        myaudio.volume = sound;


        ApplicationChrome.statusBarState = ApplicationChrome.States.VisibleOverContent;

        Debug.Log(MainAllMenu.music_vol);

        animator = Player.GetComponent<Animator>();
        animator.SetBool("hitMob", false);

        clearParticle = GameObject.Find("ClearParticle");
        clearParticle.SetActive(false);

        GameOverBTN.SetActive(false);
        ClearBTN.SetActive(false);

        bar = GameObject.Find("FullBar").GetComponent<UnityEngine.UI.Image>();

        Debug.Log(alreadyStory);
        Debug.Log(MainAllMenu.secondClear);

    }

   

    private void Update()
    {
        
        if (isPlay == true)
        {
            time -= Time.deltaTime;
            bar.fillAmount = time / 45;
            if (gameSpeed < 5)
            {
                gameSpeed += Time.deltaTime;
            }
        }

        if(Mathf.Round(time) == 0f)
        {
            if (sfxPlay == false)
            {
                StartCoroutine(GameClear());
                sfxPlay = true;
            }

            ClearBTN.SetActive(true);
            isPlay = false;
            
            clearParticle.SetActive(true);

            if (point >= 50)
            {
                MainAllMenu.secondClear = 3;
           
                SaveAndExit();
            }
            else if (50 > point && point >= 25)
            {
                MainAllMenu.secondClear = 2;
                
                SaveAndExit();

            }
            else if (25 > point && point >= 0)
            {
                MainAllMenu.secondClear = 1;
                
                SaveAndExit();
            }


        }

    }
    IEnumerator GameClear()
    {
        myaudio.clip = msic[4];
        myaudio.Play();
        yield return new WaitForSeconds(0f);
        
    }
    public void PlayBtnClick()
    {
        life = 5;
        point = 0;
        time = 45;
        GameOverBTN.SetActive(false);
        playBtn.SetActive(false);
        ClearBTN.SetActive(false);
        isPlay = true;
        onPlay.Invoke(isPlay);
        myaudio.clip = msic[3];
        myaudio.Play();
        gameSpeed = 1;
        score.text = "SCORE : 0"  ;
    }

    public void GamePoint()
    {
        myaudio.clip = msic[0];
        myaudio.Play();
        checkpoint = false;
        point += 5;
        score.text = "SCORE : " + point;
        Invoke("EnableCol", 1);
        GameObject scoreUpPrefab = Instantiate(Resources.Load("ScoreAnimParent") as GameObject, Player.transform.position, Quaternion.identity);
        scoreUpPrefab.transform.localScale = new Vector3(0.5f, 0.5f, 0);
    }

    public void GameOver()
    {
        animator.SetBool("hitMob", true);
        mob = false;
        life--;
        Scorepoint();
        myaudio.clip = msic[2];
        myaudio.Play();
        Invoke("EnableCol",1);
        if (life == 0f && Mathf.Round(time) != 0f)
        {
            myaudio.clip = msic[1];
            myaudio.Play();
            GameOverBTN.SetActive(true);
            isPlay = false;
            

        }
      
    }


    public void ButtonDown(UnityEngine.UI.Button btn)
    {
        switch (btn.name)
        {
            case "reback":
                {
                    SceneManager.LoadScene("GameSelectScene");
                    myaudio.clip = msic[3];
                    myaudio.Play();
                    break;
                }
            case "Back":
                ThirdGameClear = true;
                if (alreadyStory != false ) {
                    SceneManager.LoadScene("GameSelectScene");
                }
                else
                {
                    SceneManager.LoadScene("Dialog");
                }
                myaudio.clip = msic[3];
                myaudio.Play();
                break;
            
        }
    }

    public void EnableCol()
    {
        mob = true;
        animator.SetBool("hitMob", false);
        checkpoint = true;
    }
    
    public void Scorepoint()
    {
     
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
