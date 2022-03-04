using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DialogueManager : MonoBehaviour
{
    public Text txtName;
    public Text txtSentence;

    Queue<string> sentences = new Queue<string>();

    public Animator anim;
    public Animator fade;

    AudioSource myaudio;
    float sound;

    void Start()
    {
        sound = MainAllMenu.music_vol;
        myaudio = GameObject.Find("Dialogumanager").GetComponent<AudioSource>();
        myaudio.volume = sound;

    }

    public void Begin(Dialogue info)
    {
        anim.SetBool("isOpen",true);
        fade.SetBool("fade", false) ;
        sentences.Clear();

        txtName.text = info.name;

        foreach(var sentence in info.sentences)
        {
            sentences.Enqueue(sentence);
        }

        Next();
    }    

   public void Next()
    {
        if(sentences.Count ==0)
        {
            End();
            return;
        }

        //txtSentence.text = sentences.Dequeue();
        txtSentence.text = string.Empty;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentences.Dequeue()));
        
    }

    IEnumerator TypeSentence(string sentence)
    {
        foreach(var letter in sentence)
        {
            txtSentence.text += letter;
            myaudio.Play();
            yield return new WaitForSeconds(0.1f);
        }
    }
    private void End()
    {
        txtSentence.text = string.Empty;
        anim.SetBool("isOpen", false);
        fade.SetBool("fade", true);
        Invoke("goGame", 1f);
    }    

    public void goGame()
    {
        if (MainAllMenu.firstClear == 0)
        {
            SceneManager.LoadScene("FirstGameScene");
        }
        if (GameDirector.fClear == true)
        {
            SceneManager.LoadScene("GameSelectScene");
        }
        if (MainAllMenu.rsecondClear == 0 && GameDirector.fClear == false && MainAllMenu.firstClear != 0)
        {
            SceneManager.LoadScene("SecondGameScene");
        }
        if (SecondGameDirector.SecondEndStory ==true)
        {
            SceneManager.LoadScene("GameSelectScene");
        }
        if (MainAllMenu.firstClear != 0 && MainAllMenu.rsecondClear != 0 && MainAllMenu.secondClear == 0 && SecondGameDirector.SecondEndStory == false)
        {
            SceneManager.LoadScene("thirdGameScene");
        }
        if (GameManager.ThirdGameClear == true)
        {
            SceneManager.LoadScene("GameSelectScene");
        }
        if (MainAllMenu.firstClear != 0 && MainAllMenu.rsecondClear != 0 && MainAllMenu.secondClear != 0 && MainAllMenu.thirdClear == 0 && GameManager.ThirdGameClear == false)
        {
            SceneManager.LoadScene("FifthGameScene");
        }
        if(FifthGameDirector.lastClear == true)
        {
            SceneManager.LoadScene("TitleScene");
        }

    }
    
    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        
    }
}
