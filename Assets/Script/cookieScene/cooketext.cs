using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class cooketext : MonoBehaviour
{
    public Text txtName;
    public Text txtSentence;
    public GameObject dia;
    Animator animator;

    Queue<string> sentences = new Queue<string>();

    AudioSource myaudio;
    float sound;



    void Start()
    {
        animator = dia.GetComponent<Animator>();
        myaudio = GameObject.Find("cooketext").GetComponent<AudioSource>();
        sound = MainAllMenu.music_vol;
        myaudio.volume = sound;
    }

    public void Begin(cookieread info)
    {
        
        sentences.Clear();

        txtName.text = info.cookiename;

        foreach (var sentence in info.sentences)
        {
            sentences.Enqueue(sentence);
        }

        Next();
    }

    public void Next()
    {
        if (sentences.Count == 0)
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
        foreach (var letter in sentence)
        {
            txtSentence.text += letter;
            myaudio.Play();
            yield return new WaitForSeconds(0.1f);
        }
    }
    private void End()
    {
        txtSentence.text = string.Empty;

        animator.SetBool("click", false);

    }

  

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
       

    }
}
