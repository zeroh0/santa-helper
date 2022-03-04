using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
    float _distance = 20.0f;
    int _count = 10;
    int _index = 2;

    float speed = -2f;

    public GameObject wall;

    GameObject bg1;
    GameObject bg2; 
    GameObject bg3; 
    GameObject bg4;

    GameObject background;

    // Start is called before the first frame update
    void Start()
    {
        bg1 = GameObject.Find("Sky_1");
        bg2 = GameObject.Find("Sky_2");  
        bg3 = GameObject.Find("Sky_3");  
        bg4 = GameObject.Find("Sky_4");

        background = GameObject.Find("background");
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
            return;

        if (speed > -10f){
            speed -= Time.deltaTime;
        }
        gameObject.transform.localPosition += new Vector3(speed * Time.deltaTime, 0, 0);

        _count = 2 + (int)(-gameObject.transform.localPosition.x / 20.0f);

        if (_index != _count)
        {
            wall.transform.localPosition = new Vector3(_distance * _count, -5.25f, 0);
            _index = _count;
        }

        //하늘
        bg1.transform.localPosition -= new Vector3(0.5f * Time.deltaTime, 0, 0);
        bg2.transform.localPosition -= new Vector3(0.5f * Time.deltaTime, 0, 0);
        bg3.transform.localPosition -= new Vector3(0.5f * Time.deltaTime, 0, 0);
        bg4.transform.localPosition -= new Vector3(0.5f * Time.deltaTime, 0, 0);

        background.transform.localPosition -= new Vector3(3f * Time.deltaTime, 0, 0);
    }
}
