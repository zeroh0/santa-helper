using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class FifthGameDirector : MonoBehaviour
{
    //엔딘씬을 실행하기위한 변수
    public static bool lastClear;

    GameObject player;
    public new GameObject light;
    public GameObject fuel;
    public GameObject monster1;
    public GameObject lodge;
    public GameObject tree1;
    public GameObject tree2;

    GameObject failPnl;
    GameObject clearPnl;
    GameObject helpPnl;

    GameObject starImage;

    GameObject clearParticle;

    public int score = 0;
    GameObject scoretxt;

    CapsuleCollider2D lightColl2D;
    Animator lightOnAnim;

    Image bar;
    float limitTime = 90.0f;
    float nowTime;

    List<Vector3> spawnList = new List<Vector3>();

    Vector3 lightPos;

    float sound;
    AudioSource myaudio;
    public AudioClip[] sfx;

    private bool isPlay;

    bool alreadyStory;

    // Start is called before the first frame update
    void Start()
    {
        isPlay = false;

        myaudio = this.GetComponent<AudioSource>();
        sound = MainAllMenu.music_vol;
        myaudio.volume = sound;

        Time.timeScale = 0;

        player = GameObject.Find("Player");
        bar = GameObject.Find("FullBar").GetComponent<Image>();

        failPnl = GameObject.Find("FailPanel"); //실패
        clearPnl = GameObject.Find("ClearPanel"); //성공
        helpPnl = GameObject.Find("GameHelpPanel"); //도움말

        starImage = GameObject.Find("ClearPanel/StarImage");

        scoretxt = GameObject.Find("Score/Scoretxt");

        clearParticle = GameObject.Find("ClearParticle");
        clearParticle.SetActive(false);

        failPnl.SetActive(false);
        clearPnl.SetActive(false);
    
        nowTime = limitTime;

        for (int i = 0; i < 500 & spawnList.Count < 10; i++)
        {
            SpawnIngameObject(light, 20f);
        }

        for (int i = 0; i < 500 & spawnList.Count < 30; i++)
        {
            SpawnIngameObject(fuel, 5f);
        }

        for (int i = 0; i < 500 & spawnList.Count < 50; i++)
        {
            SpawnIngameObject(monster1, 1f);
        }

        for (int i = 0; i < 500 & spawnList.Count < 51; i++)
        {
            SpawnIngameObject(lodge, 35f);
        }

        for (int i = 0; i < 500 & spawnList.Count < 61; i++)
        {
            SpawnIngameObject(tree1, 10f);
        }

        for (int i = 0; i < 500 & spawnList.Count < 71; i++)
        {
            SpawnIngameObject(tree2, 10f);
        }

        if(MainAllMenu.thirdClear == 0)alreadyStory = false;
        else alreadyStory =true;
    }

    void Update()
    {
        nowTime -= Time.deltaTime;
        bar.fillAmount = nowTime / limitTime;

        if(nowTime < 0f)
        {
            Debug.Log("게임오버");
            FailGame();
        }

        scoretxt.GetComponent<Text>().text = "SCORE : " + score;
    }

    void SpawnIngameObject(GameObject obj, float dist)
    {
        Vector3 newSpawnPoint = new Vector3(Random.Range(-40f, 40f), Random.Range(-40f, 40f), 0f);

        bool flag = true;

        if (obj == lodge)
        {
            foreach (Vector3 oldSpawnPoint in spawnList)
            {
                if ((newSpawnPoint - transform.position).magnitude < dist) flag = false;
            }
            if (flag)
            {
                Instantiate(obj, newSpawnPoint, Quaternion.identity);
                spawnList.Add(newSpawnPoint);
                            
            }
        }

        foreach (Vector3 oldSpawnPoint in spawnList)
        {
            if ((newSpawnPoint - oldSpawnPoint).magnitude < dist) flag = false;
        }
        if (flag)
        {
            if (newSpawnPoint.magnitude >= dist)
            {
                Instantiate(obj, newSpawnPoint, Quaternion.identity);
                spawnList.Add(newSpawnPoint);
            }
        }
    }

    public void ButtonClick(Button btn)
    {
        switch (btn.name)
        {
            case "GameHelpPanel":
                helpPnl.SetActive(false);
                Time.timeScale = 1;
                break;

            case "GoMainBtn":
                SceneManager.LoadScene("GameSelectScene");
                Time.timeScale = 1;
                break;

            case "GoRetryBtn":
                SceneManager.LoadScene("FifthGameScene");
                break;

            case "GoNextBtn":
                if (alreadyStory == false)
         {       SceneManager.LoadScene("Dialog");
                Time.timeScale = 1;
                lastClear = true;
         }
                else SceneManager.LoadScene("GameSelectScene");
                break;

            case "TurnOnBtn":
                Instantiate(Resources.Load("Score15AnimParent") as GameObject, player.transform.position, Quaternion.identity);
                myaudio.clip = sfx[1];
                myaudio.Play();
                Instantiate(Resources.Load("LightOnArea") as GameObject, lightPos, Quaternion.identity);
                score += 15;
                nowTime -= 5.0f;
                lightColl2D.enabled = false;
                lightOnAnim.enabled = true;
                break;
        }
    }
    
    public void SetLightPosition(Vector3 pos)
    {
        lightPos = pos;
        //Debug.Log(lightPos.x + " " + lightPos.y);
    }

    public void LightCollider(CapsuleCollider2D coll2D)
    {
        lightColl2D = coll2D;
    }

    public void LightOnAnim(Animator anim)
    {
        lightOnAnim = anim;
    }

    void ClearMusic()
    {
        
    }

    void FailMusic()
    {
        
    }

    public void FailGame()
    {
        if(isPlay == false)
        {
            StartCoroutine(GameFail());
            isPlay = true;
        }
        
        //Time.timeScale = 0;
        failPnl.SetActive(true);
        failPnl.GetComponent<Animator>().Play("ShowPopup");
        Invoke("GameStop", 0.3f);
    }

    IEnumerator GameFail()
    {
        myaudio.clip = sfx[4];
        myaudio.Play();
        yield return new WaitForSeconds(0f);
    }

    // 오두막 찾았을 때
    public void ClearGame()
    {
        myaudio.clip = sfx[3];
        myaudio.Play();

        if (score >= 120)
        {
            starImage.GetComponent<Image>().sprite = Resources.Load("star3", typeof(Sprite)) as Sprite;
            MainAllMenu.thirdClear = 3;
            SaveAndExit();
        }
        else if (score >= 60 && score <= 115)
        {
            starImage.GetComponent<Image>().sprite = Resources.Load("star2", typeof(Sprite)) as Sprite;
            MainAllMenu.thirdClear = 2;
            SaveAndExit();
        }
        else
        {
            starImage.GetComponent<Image>().sprite = Resources.Load("star1", typeof(Sprite)) as Sprite;
            MainAllMenu.thirdClear = 1;
            SaveAndExit();
        }

        //Time.timeScale = 0;
        clearPnl.SetActive(true);
        clearPnl.GetComponent<Animator>().Play("ShowPopup");
        Invoke("GameStop", 0.3f);
        clearParticle.SetActive(true);
    }

    public void AddFuel()
    {
        Instantiate(Resources.Load("ScoreAnimParent") as GameObject, player.transform.position, Quaternion.identity);
        myaudio.clip = sfx[0];
        myaudio.Play();
        nowTime += 15.0f;
        if (nowTime > limitTime) nowTime = limitTime;
        score += 5;
    }

    void GameStop()
    {
        Time.timeScale = 0;
    }

    public void DecreaseFuel()
    {
        myaudio.clip = sfx[2];
        myaudio.Play();
        nowTime -= 5.0f;
        Debug.Log("몬스터 충돌");
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
