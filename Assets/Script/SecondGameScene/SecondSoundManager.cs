using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondSoundManager : MonoBehaviour
{
    float sound;
    AudioSource myaudio;
    // Start is called before the first frame update
    void Start()
    {
        //사운드
        myaudio = this.GetComponent<AudioSource>();
        sound = MainAllMenu.music_vol;
        myaudio.volume = sound;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
