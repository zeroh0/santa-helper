using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMaker : MonoBehaviour
{
    public GameObject[] wall;
    public GameObject bell;
    public GameObject[] cloud;

    private float nowTime;
    //private float makeTime = 2.5f; //생성 주기

    // Start is called before the first frame update
    void Start()
    {
        nowTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - nowTime > Random.Range(2.5f, 6.0f))
        {
            nowTime = Time.time;

            float wallcycle = Random.Range(12f, 24f);
            float bellcycle = Random.Range(18f, 36f);
            float cloudcycle = Random.Range(10f, 20f);

            if (Random.Range(1, 100) <= 85.0f)
            {
                GameObject wallPrefab = Instantiate(wall[Mathf.Abs(Random.Range(0, 3))]);
                wallPrefab.transform.parent = gameObject.transform;
                wallPrefab.transform.localPosition = new Vector3(-gameObject.transform.localPosition.x + wallcycle, -5.25f, 0);
            }

            //Debug.Log(bellcycle);
            //Debug.Log(wallcycle);

            if(Mathf.Floor(bellcycle - wallcycle) != 0
                && Mathf.Floor(bellcycle - wallcycle) != 1
                && Mathf.Floor(bellcycle - wallcycle) != 2
                && Mathf.Floor(bellcycle - wallcycle) != 3
                && Mathf.Floor(bellcycle - wallcycle) != -1
                && Mathf.Floor(bellcycle - wallcycle) != -2
                && Mathf.Floor(bellcycle - wallcycle) != -3
                )
                if(Random.Range(1, 100) <= 85.0f)
                {
                    GameObject bellPrefab = Instantiate(bell);
                    bellPrefab.transform.parent = gameObject.transform;
                    bellPrefab.transform.localPosition = new Vector3(-gameObject.transform.localPosition.x + bellcycle, -2.55f, 0);
                }

            GameObject cloudPrefab = Instantiate(cloud[Mathf.Abs(Random.Range(0, 2))]);
            cloudPrefab.transform.parent = gameObject.transform;
            cloudPrefab.transform.localPosition = new Vector3(-gameObject.transform.localPosition.x + cloudcycle, Random.Range(-4f, 4f), 0);

        }
    }
}
