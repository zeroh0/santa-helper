using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;


using System.IO;
using System.Runtime.Serialization.Formatters.Binary;



public class GameSelectScene : MonoBehaviour
{
    GameObject SecondGameGo;
    GameObject ThirdGameGo;
    GameObject FourthGameGo;
    Animator animator;
    GameObject Fade;




    //이야기 선택의 별수 총합 계산
    Text pullScore;


    AudioSource myaudio;
    float music_vol;
    SaveData sl;

    public AudioSource ButtonSound;

    // 게임 다시 도전후 클리어시 스토리 생략용
    public static bool fGretry;

    // Start is called before the first frame update
    void Start()

    {
        Time.timeScale = 1;

        ApplicationChrome.statusBarState = ApplicationChrome.States.VisibleOverContent;
        //시나리오 관리 
        GameDirector.fClear = false;
        SecondGameDirector.SecondEndStory = false;
        GameManager.ThirdGameClear = false;

        //오브젝트 찾기
        SecondGameGo = GameObject.Find("SecondGameGo");
        ThirdGameGo = GameObject.Find("ThirdGameGo");
        FourthGameGo = GameObject.Find("FourthGameGo");
        Fade = GameObject.Find("Fade");
        animator = Fade.GetComponent<Animator>();
        pullScore = GameObject.Find("PullScore").GetComponent<Text>();

        //초반 버튼 비활성화 나중에 게임들 만들어지면은 수정해야됨
        if (MainAllMenu.firstClear != 0)
        {
            SecondGameGo.GetComponent<UnityEngine.UI.Button>().interactable = true;
            if (MainAllMenu.rsecondClear != 0)
            {
                ThirdGameGo.GetComponent<UnityEngine.UI.Button>().interactable = true;
                if (MainAllMenu.secondClear != 0)
                {
                    FourthGameGo.GetComponent<UnityEngine.UI.Button>().interactable = true;
                    
                }
            }
        }
        else
        {
            SecondGameGo.GetComponent<UnityEngine.UI.Button>().interactable = false;
            ThirdGameGo.GetComponent<UnityEngine.UI.Button>().interactable = false;
            FourthGameGo.GetComponent<UnityEngine.UI.Button>().interactable = false;
        }
        //애니메이션 패러미터 값 
        animator.SetBool("Fade Out", false);
        Invoke("FadeIn", 2f);


        //소리관련
        myaudio = GameObject.Find("GameSelectScene").GetComponent<AudioSource>();

        //데이터 로드
        sl = LoadIngameData();
        if (sl != null) music_vol = sl.vol;
        else music_vol = 0.5f;
        myaudio.volume = music_vol;
        ButtonSound.volume = music_vol;

        //기타
        ApplicationChrome.statusBarState = ApplicationChrome.States.VisibleOverContent;

        //이야기 선택의 별수 총합 계산
        pullScore.text =   MainAllMenu.firstClear + MainAllMenu.rsecondClear + MainAllMenu.secondClear+ MainAllMenu.thirdClear + "/12";

    }

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if(Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
        }



    }

    public void ButtonDown(UnityEngine.UI.Button btn)
    {
        switch (btn.name)
        {
            case "backButton":
                ButtonSound.Play();
                Fade.SetActive(true);
                animator.SetBool("Fade Out", true);
                Invoke("GoTitleScene",2f);
                break;
            case "FirstGameGo":
                GameObject.Find("AD").GetComponent<AdmobInterstitialScript>().show();
                ButtonSound.Play();
                Fade.SetActive(true);
                animator.SetBool("Fade Out", true);
                if (MainAllMenu.firstClear != 0) {
                    Invoke("FirstGame", 2f);
                    fGretry = true;
                }
                else
                {
                    Invoke("GoStory", 2f);
                }
                break;
            case "SecondGameGo":
                GameObject.Find("AD").GetComponent<AdmobInterstitialScript>().show();
                ButtonSound.Play();
                Fade.SetActive(true);
                animator.SetBool("Fade Out", true);
                if (MainAllMenu.rsecondClear != 0)
                {
                    Invoke("SecondGame", 2f);
                }
                else
                {
                    Invoke("GoStory", 2f);
                }
                break;
            case "ThirdGameGo":
                GameObject.Find("AD").GetComponent<AdmobInterstitialScript>().show();
                ButtonSound.Play();
                Fade.SetActive(true);
                animator.SetBool("Fade Out", true);
                if (MainAllMenu.secondClear != 0)
                {
                    Invoke("ThirdGame", 2f);
                }
                else
                {
                    Invoke("GoStory" , 2f);
                }
                
               
                break;
            case "FourthGameGo":
                GameObject.Find("AD").GetComponent<AdmobInterstitialScript>().show();
                ButtonSound.Play();
                Fade.SetActive(true);
                animator.SetBool("Fade Out", true);
                if (MainAllMenu.thirdClear != 0)
                {
                    Invoke("FourthGame", 2f);
                }
                else
                {
                    Invoke("GoStory", 2f);
                }
                break;

        }
    }

    //Fade out 후에 나타남 
    public void GoTitleScene()
    {
        SceneManager.LoadScene("TitleScene");
        
    }
    public void GoStory()
    {
        SceneManager.LoadScene("Dialog");
    }
    public void FirstGame()
    {
        SceneManager.LoadScene("FirstGameScene");
    }
    public void SecondGame()
    {
        SceneManager.LoadScene("SecondGameScene");
    }
    public void ThirdGame()
    {
        SceneManager.LoadScene("thirdGameScene");
    }
    public void FourthGame()
    {
        SceneManager.LoadScene("FifthGameScene");
    }
    public void FadeIn()
    {
        Fade.SetActive(false);

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

