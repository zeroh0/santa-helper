using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightActive : MonoBehaviour
{
    GameObject gameDirector;
    CapsuleCollider2D lightColl;
    Animator lightOn;

    // Start is called before the first frame update
    void Start()
    {
        gameDirector = GameObject.Find("FifthGameDirector");
        lightOn = GetComponent<Animator>();
        lightColl = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (gameDirector != null)
        {
            gameDirector.SendMessage("SetLightPosition", transform.position);
            gameDirector.SendMessage("LightCollider", lightColl);
            gameDirector.SendMessage("LightOnAnim", lightOn);
        }
    }
}
