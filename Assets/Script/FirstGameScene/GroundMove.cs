using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour
{
    float _distance = 20.0f;
    int _count = 10;
    int _index = 2;

    public GameObject[] grounds;

    GameObject bg;

    // Start is called before the first frame update
    void Start()
    {
        bg = GameObject.Find("Sky");
    }

    // Update is called once per frame
    void Update()
    {
        //땅
        if (Time.timeScale == 0)
            return;

        gameObject.transform.localPosition += new Vector3(-13f * Time.deltaTime, 0, 0);

        _count = 2 + (int)(-gameObject.transform.localPosition.x / 20.0f);

        if(_index != _count)
        {
            grounds[(_index - 2) % 3].transform.localPosition = new Vector3(_distance * _count, -4.6f, 0);
            _index = _count;
        }

        //하늘
        bg.transform.localPosition -= new Vector3(0.5f * Time.deltaTime, 0, 0);
    }
}
