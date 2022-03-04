using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    GameObject gameDirector;
    Animator bearAnim;
    Vector3 toGo;
    Vector3 fromHere;
    float speed = 350f;

    void Start()
    {
        gameDirector = GameObject.Find("FifthGameDirector"); ;
        bearAnim = GetComponent<Animator>();
        toGo = RandomPosition();
        bearAnim.Play("BearWalk");
    }

    void Update()
    {
        if ((transform.position - toGo).magnitude > 0.1f)
        {
            if (toGo.x > transform.position.x)
            {
                transform.localScale = new Vector3(-1.75f, 1.75f, 1);
                transform.Translate((toGo - fromHere) / speed * Time.deltaTime * 250f);
            }
            else
            {
                transform.localScale = new Vector3(1.75f, 1.75f, 1);
                transform.Translate((toGo - fromHere) / speed * Time.deltaTime * 250f);
            }

        }
        else
        {
            toGo = RandomPosition();
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" & gameDirector != null)
        {
            gameDirector.GetComponent<FifthGameDirector>().DecreaseFuel();
        }

    }

    Vector2 RandomPosition()
    {
        Vector2 newPos;
        fromHere = transform.position; // 출발위치 기억

        do newPos = new Vector2(fromHere.x + Random.Range(-5f, 5f), fromHere.y + Random.Range(-5f, 5f));
        while (Mathf.Abs(newPos.x) > 45f || Mathf.Abs(newPos.y) > 45f);

        speed = Random.Range(350f, 750f); // 스피드 랜덤 결정

        return newPos;
    }
}
