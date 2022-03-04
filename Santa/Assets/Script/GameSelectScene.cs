using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Tilemaps;
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


    // Start is called before the first frame update
    void Start()

    { //오브젝트 찾기
        SecondGameGo = GameObject.Find("SecondGameGo");
        ThirdGameGo = GameObject.Find("ThirdGameGo");
        FourthGameGo = GameObject.Find("FourthGameGo");
        Fade = GameObject.Find("Fade");
        animator = Fade.GetComponent<Animator>();
        pullScore = GameObject.Find("PullScore").GetComponent<Text>();

        //초반 버튼 비활성화 나중에 게임들 만들어지면은 수정해야됨
        SecondGameGo.GetComponent<UnityEngine.UI.Button>().interactable = true;
        ThirdGameGo.GetComponent<UnityEngine.UI.Button>().interactable = false;
        FourthGameGo.GetComponent<UnityEngine.UI.Button>().interactable = false;

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
        pullScore.text = MainAllMenu.secondClear + "/18";

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
                ButtonSound.Play();
                Fade.SetActive(true);
                animator.SetBool("Fade Out", true);
                Invoke("FirstGame", 2f);
                
                break;
            case "SecondGameGo":
                ButtonSound.Play();
                Fade.SetActive(true);
                animator.SetBool("Fade Out", true);
                Invoke("SecondGame", 2f);

                break;

        }
    }

    //Fade out 후에 나타남 
    public void GoTitleScene()
    {
        SceneManager.LoadScene("TitleScene");
        
    }
    public void FirstGame()
    {
        SceneManager.LoadScene("FirstGame");
    }

    public void SecondGame()
    {
        SceneManager.LoadScene("SecondGame2");
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

