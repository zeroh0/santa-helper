using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//정해진 시간이 지나면 오브젝트를 파괴
public class SabotageMove : MonoBehaviour
{
    float makeTime;

    // Start is called before the first frame update
    void Start()
    {
        makeTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - makeTime > 5f)
            Destroy(gameObject);
    }


}
