using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobBasis : MonoBehaviour
{
    // Start is called before the first frame update
    float mobSpeed = 15f;
    public Vector2 StartPostion;

    private void OnEnable()
    {
        transform.position = StartPostion;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.isPlay)
        {
            mobSpeed += mobSpeed * Time.deltaTime * 2000;
            transform.Translate(Vector2.left * Time.deltaTime * GameManager.instance.gameSpeed);

            if (transform.position.x < -6)
            {
                gameObject.SetActive(false);
            }

        }


       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!this.CompareTag("Mob")) { 
            this.gameObject.SetActive(false);
            }

        }
      
    }

    public void retry()
    {
        this.gameObject.SetActive(true);
    }
    
}
