using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMmanager : MonoBehaviour
{

    AudioSource myaudio;
    float sound;
    // Start is called before the first frame update
    void Start()
    {
        myaudio = this.GetComponent<AudioSource>();

        sound = MainAllMenu.music_vol;

        myaudio.volume = sound;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
