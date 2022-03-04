using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControll : MonoBehaviour
{
    GameObject player;

    GameObject gameDirector;
    GameObject objectMaker;

    Rigidbody2D rigid2D;
    Collider2D coll2D;

    GameObject snow;

    float jumpforce = 550.0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        player.transform.position = new Vector3(-5, 0, 0); //플레이어의 처음 시작 위치

        rigid2D = GetComponent<Rigidbody2D>();
        coll2D = GetComponent<Collider2D>();

        gameDirector = GameObject.Find("GameDirector");

        snow = GameObject.Find("Player/SnowParticle");
    }

    // Update is called once per frame
    void Update()
    {
        //화면 밖으로 나가지 않도록 하는 코드 
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        //if (pos.x < 0f) pos.x = 0f;
        //if (pos.x > 1f) pos.x = 1f;
        if (pos.y < 0f)
        {
            pos.y = 0f;
            rigid2D.velocity = new Vector2(0, 0);
        }
        if (pos.y > 1f)
        {
            pos.y = 1f;
            rigid2D.velocity = new Vector2(0, 0);
        }

        transform.position = Camera.main.ViewportToWorldPoint(pos);

        snow.transform.position = new Vector3(this.transform.position.x - 0.9f, this.transform.position.y - 0.8f, 0);

        //점프
        if (Input.GetMouseButtonDown(0) && Time.timeScale == 1)
        {
            rigid2D.AddForce(transform.up * jumpforce);
        }

        if (rigid2D.velocity.y > 7.5f)
        {
            rigid2D.velocity = new Vector2(0, 7.5f);
        }
    }

    //장애물(나무)과 충돌하게 되면
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("데미지");
        gameDirector.GetComponent<GameDirector>().Damage(); //GameDirector의 Damage() 함수 호출
        coll2D.enabled = false;
        Invoke("DelayCrash", 1.5f);
    }

    void DelayCrash()
    {
        coll2D.enabled = true;
    }

}
