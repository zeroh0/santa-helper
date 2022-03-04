using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdSabotageMaker : MonoBehaviour
{
    public GameObject build; 
    public GameObject bird;
    public GameObject cloud;

    private float nowTime;
    private float makeTime = 2.0f;

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
            GameObject BuildPrefab = Instantiate(build);
            BuildPrefab.transform.parent = gameObject.transform;

            GameObject birdPrefab = Instantiate(bird);
            birdPrefab.transform.parent = gameObject.transform;
            
            GameObject cloudPrefab = Instantiate(cloud);
            cloudPrefab.transform.parent = gameObject.transform;
           
            //첫번째 게임의 나무 오브젝트 + 새 ,구름 오브젝트 추가
            //float tree_randomY = Random.Range(-4.0f, -7.5f);
            BuildPrefab.transform.localPosition = new Vector3(-gameObject.transform.localPosition.x + 12, -5.0f, 0);
            float tree_randomSizeY = Random.Range(1.0f, 2.0f);
            BuildPrefab.transform.localScale = new Vector3(1.5f, tree_randomSizeY, 0);

            float bird_randomY = Random.Range(-4.5f, 4.5f);
            birdPrefab.transform.localPosition = new Vector3(-gameObject.transform.localPosition.x + 24 , bird_randomY, 0);

            float cloud_randomY = Random.Range(-4.5f, 4.5f);
            cloudPrefab.transform.localPosition = new Vector3(-gameObject.transform.localPosition.x + 18, cloud_randomY, 0);


        }
    }
}
