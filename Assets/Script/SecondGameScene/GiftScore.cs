using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftScore : MonoBehaviour
{
    GameObject gameDirector;

    // Start is called before the first frame update
    void Start()
    {
        gameDirector = GameObject.Find("SecondGameDirector");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //선물이 굴뚝과 충돌했을 때 
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "point")
        {
            Debug.Log("+5");
            gameDirector.GetComponent<SecondGameDirector>().UpScore(); //SecondGameDirector의 UpScore() 함수 호출
            DelGift();
        }

        if (other.gameObject.tag == "Mob")
        {
            Debug.Log("-5");
            gameDirector.GetComponent<SecondGameDirector>().DownScore(); //SecondGameDirector의 UpScore() 함수 호출
            DelGift();
        }

    }

    void DelGift()
    {
        Destroy(gameObject);
    }
}
