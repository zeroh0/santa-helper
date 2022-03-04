using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class GiftDestory : MonoBehaviour
{
    GameObject gameDirector;

    //bool flag = false;

    // Start is called before the first frame update
    void Start()
    {
        gameDirector = GameObject.Find("SecondGameDirector");
    }

    // Update is called once per frame
    void Update()
    {
        //선물 오브젝트의 y축이 -10미만 일때
        if (gameObject.transform.position.y < -10.0f)
        {
            Destroy(gameObject); //선물 오브젝트 파괴
            gameDirector.GetComponent<SecondGameDirector>().DropGift(); //SecondGameDirector의 DropGift() 함수 호출
        }

    }

}
