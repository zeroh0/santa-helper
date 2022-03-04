using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//지정된 시간이 지나면 오브젝트 파괴
public class WallDestoy : MonoBehaviour
{
    float makeTime;

    GameObject player;
    GameObject gameDirector;

    bool flag = false;

    // Start is called before the first frame update
    void Start()
    {
        makeTime = Time.time;

        player = GameObject.Find("Player");
        gameDirector = GameObject.Find("SecondGameDirector");
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - makeTime > 7.0f)
        {
            Destroy(gameObject);
        }

        if(transform.position.x < player.transform.position.x && !flag)
        {
            flag = true;
            gameDirector.GetComponent<SecondGameDirector>().WallFinish();
           
        }
    }
}
