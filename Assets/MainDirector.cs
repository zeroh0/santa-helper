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

public class MainDirector : MonoBehaviour
{
    GameObject titleImg;

    float sound;
    AudioSource myaudio;
    public AudioClip[] sfx;

    GameObject fade;

    Animator fadeanimation;
    SaveData sl;
    // Start is called before the first frame update
    void Start()
    {
        titleImg = GameObject.Find("TitleImg");
        fade = GameObject.Find("FADE");

        fadeanimation = fade.GetComponent<Animator>();

        myaudio = this.GetComponent<AudioSource>();

        sl = LoadIngameData();
        if (sl != null)
        {
            sound = sl.vol;



        }
        else
        {
            sound = 0.5f;


        }
        myaudio.volume = sound;
        fadeanimation.SetBool("start" , false);
        Invoke("wait", 1.5f);
    }

    // Update is called once per frame
  
    public void TitleImage()
    {
        fade.SetActive(true);
        fadeanimation.SetBool("start", true);
        Invoke("loadScene", 1.5f);
    }

    public void loadScene()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void wait()
    {
        fade.SetActive(false);
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
