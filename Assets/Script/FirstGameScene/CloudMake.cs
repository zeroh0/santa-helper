using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMake : MonoBehaviour
{
    public GameObject[] cloud;
    float nowTime;

    // Start is called before the first frame update
    void Start()
    {
        nowTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - nowTime > 2.0f)
        {
            nowTime = Time.time;

            GameObject cloudPrefab = Instantiate(cloud[Mathf.Abs(Random.Range(0,2))]);
            cloudPrefab.transform.parent = gameObject.transform;
            cloudPrefab.transform.localPosition = new Vector3(-gameObject.transform.localPosition.x + 12f, Random.Range(-2f, 2f), 0);
        }
    }
}
