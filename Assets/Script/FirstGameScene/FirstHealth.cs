using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstHealth : MonoBehaviour
{
    [SerializeField]
    private Slider hpbar;

    private float maxHp = 10f;
    private float curHp = 10f;
    float imsi;

    float birdPos;
    public GameObject birdAlert;

    // Start is called before the first frame update
    void Start()
    {
        hpbar.value = (float)curHp / (float)maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        HandleHP();
    }

    public void DecreaseHP()
    {
        if(curHp > 0)
        {
            curHp -= 1f;
        }
        else
        {
            curHp = 0;
        }
        //imsi = (float)curHp / (float)maxHp;
    }

    private void HandleHP()
    {
        hpbar.value = Mathf.Lerp(hpbar.value, imsi, Time.deltaTime * 10);
    }
}
