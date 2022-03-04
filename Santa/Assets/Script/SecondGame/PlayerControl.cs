using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour

{
    Rigidbody2D rigid20;
    float jumpForce = 210.0f; //점프 높이

    public float power;
    public Transform pos;
    public float checkRadius;
    public LayerMask islayer;

    public int JumpCount;
    int jumpCnt;

    public bool isGround;
    // Start is called before the first frame update
    void Start()
    {

        rigid20 = GetComponent<Rigidbody2D>();
        jumpCnt = JumpCount;
    }


    // Update is called once per frame
    void Update()
    {
        isGround = Physics2D.OverlapCircle(pos.position, checkRadius, islayer);
        if (isGround == true && Input.GetKeyDown(KeyCode.Space) && jumpCnt > 0)
        {
            rigid20.AddForce(transform.up * jumpForce);
        }

        if (isGround == false && Input.GetKeyDown(KeyCode.Space) && jumpCnt > 0 && GameManager.instance.isPlay)
        {
            rigid20.AddForce(transform.up * jumpForce);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            jumpCnt--;
        }
        if (isGround)
        {
            jumpCnt = JumpCount;
        }
        Vector3 pos1 = Camera.main.WorldToViewportPoint(transform.position);
        if (pos1.x < 0f) pos1.x = 0f;
        if (pos1.x > 1f) pos1.x = 1f;
        if (pos1.y < 0f) pos1.y = 0f;
        if (pos1.y > 1f) pos1.y = 1f;
        transform.position = Camera.main.ViewportToWorldPoint(pos1);

    }








    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mob"))
        {
            GameManager.instance.GameOver();
        }

        if (collision.CompareTag("point"))
        {
            GameManager.instance.GamePoint();
        }
    }


}