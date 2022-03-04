using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SabotageMaker : MonoBehaviour
{
    public GameObject[] building;
    //public GameObject[] cloud;
    //public GameObject bird;

    private float nowTime;
    private float makeTime = 2.0f; //생성 주기

    // Start is called before the first frame update
    void Start()
    {
        nowTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - nowTime > makeTime)
        {
            nowTime = Time.time;

            GameObject buildingPrefab = Instantiate(building[Random.Range(0, 4)]);
            buildingPrefab.transform.parent = gameObject.transform;       
            float building_randomY = Random.Range(-5.5f, -5.0f); //이미지가 생성되는 Y축의 범위
            buildingPrefab.transform.localPosition = new Vector3(-gameObject.transform.localPosition.x + 12, building_randomY, 0);

            //GameObject cloudPrefab = Instantiate(cloud[Random.Range(0, 2)]);
            //cloudPrefab.transform.parent = gameObject.transform;
            //float cloud_randomY = Random.Range(-3f, 4.5f); //이미지가 생성되는 Y축의 범위
            //cloudPrefab.transform.localPosition = new Vector3(-gameObject.transform.localPosition.x + Random.Range(16f, 28f), cloud_randomY, 0);

            //GameObject birdPrefab = Instantiate(bird);
            //birdPrefab.transform.parent = gameObject.transform;
            //float bird_randomY = Random.Range(-3f, 4.5f); //이미지가 생성되는 Y축의 범위
            //birdPrefab.transform.localPosition = new Vector3(-gameObject.transform.localPosition.x + Random.Range(20f, 24f), bird_randomY, 0);
        }
    }

}
