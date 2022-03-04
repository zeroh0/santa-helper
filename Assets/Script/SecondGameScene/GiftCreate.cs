using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiftCreate : MonoBehaviour
{
    public GameObject giftPrefab;

    GameObject player;
    GameObject gameDirector;

    Button giftBtn;

    public Slider giftGage;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        gameDirector = GameObject.Find("SecondGameDirector");

        giftBtn = GameObject.Find("GiftBtn").GetComponent<Button>();
    }
    
    //선물 버튼 클릭 시 선물 떨어트리기
    public void DropGift()
    {
        GameObject gift;
        gift = Instantiate(giftPrefab) as GameObject;
        gift.transform.position = player.transform.position;
        GiftDelay();
        gameDirector.GetComponent<SecondGameDirector>().GiftClick();
        gameDirector.GetComponent<SecondGameDirector>().DropGift();
        if (giftGage.value < 0f)
        {
            giftGage.value = 0f;
        }
        else
        {
            giftGage.value -= 1f;
        }
    }

    //선물 오브젝트끼리 충돌해서 점수가 올라가는 걸 방지
    public void GiftDelay()
    {
        giftBtn.interactable = false;
        Invoke("GiftActive", 0.3f);
    }

    public void GiftActive()
    {
        giftBtn.interactable = true;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0) giftBtn.interactable = false;
        else giftBtn.interactable = true;
    }
}
