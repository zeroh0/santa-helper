using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMake : MonoBehaviour
{
    public GameObject bird;
    float nowTime;

    // Start is called before the first frame update
    void Start()
    {
        nowTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - nowTime > Random.Range(4.0f, 8.0f))
        {
            nowTime = Time.time;

            GameObject birdPrefab = Instantiate(bird);
            birdPrefab.transform.parent = gameObject.transform;
            float birdY = Random.Range(0f, 4.5f);
            birdPrefab.transform.localPosition = new Vector3(-gameObject.transform.localPosition.x + 12f, birdY, 0);


        }
    }
}
