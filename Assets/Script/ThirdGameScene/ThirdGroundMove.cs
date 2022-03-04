using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdGroundMove : MonoBehaviour
{
    float _distance = 20.0f;
    int _count = 10;
    int _index = 2;

    public GameObject[] grounds;

    GameObject bg;
    GameObject buliding_1;
    GameObject buliding_2;

    // Start is called before the first frame update
    void Start()
    {
        bg = GameObject.Find("Sky");
        buliding_1 = GameObject.Find("Background_1");
        buliding_2 = GameObject.Find("Background_2");
    }

    // Update is called once per frame
    void Update()
    {
        //땅
        if (Time.timeScale == 0)
            return;

        gameObject.transform.localPosition += new Vector3(-0.05f, 0, 0);

        _count = 2 + (int)(-gameObject.transform.localPosition.x / 20.0f);

        if(_index != _count)
        {
            grounds[(_index - 2) % 3].transform.localPosition = new Vector3(_distance * _count, -4.5f, 0);
            _index = _count;
        }

        //하늘
        bg.transform.localPosition -= new Vector3(0.0005f, 0, 0);

        //집 배경
        buliding_1.transform.localPosition -= new Vector3(0.005f, 0, 0);
        buliding_2.transform.localPosition -= new Vector3(0.005f, 0, 0);
    }
}
