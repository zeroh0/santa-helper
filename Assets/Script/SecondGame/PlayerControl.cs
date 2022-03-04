using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour

{
    public AudioClip[] msic = new AudioClip[2];
    AudioSource myaudio;
    float sound;

    Rigidbody2D rigid20;
    float jumpForce = 335.0f; //점프 높이

    public float power;
    public Transform pos;
    public float checkRadius;
    public LayerMask islayer;

    public int JumpCount;
    int jumpCnt;

    Animator animator;

    public bool isGround;
    // Start is called before the first frame update
    void Start()
    {
        myaudio = GameObject.Find("Player").GetComponent<AudioSource>();
        sound = MainAllMenu.music_vol;
        myaudio.volume = sound;

        animator = this.GetComponent<Animator>();
        animator.SetBool("jump", false);
        rigid20 = GetComponent<Rigidbody2D>();
        jumpCnt = JumpCount;
    }


    // Update is called once per frame
    void Update()
    {
        isGround = Physics2D.OverlapCircle(pos.position, checkRadius, islayer);

        Vector3 pos1 = Camera.main.WorldToViewportPoint(transform.position);
        if (pos1.x < 0f) pos1.x = 0f;
        if (pos1.x > 1f) pos1.x = 1f;
        if (pos1.y < 0f) pos1.y = 0f;
        if (pos1.y > 1f) pos1.y = 1f;
        transform.position = Camera.main.ViewportToWorldPoint(pos1);

        if (isGround)
        {
            jumpCnt = JumpCount;
        }


    }



    public void buttonjump()
    {
        myaudio.clip = msic[0];
        myaudio.Play();

        if (isGround)
        {
            jumpCnt = JumpCount;

        }

        isGround = Physics2D.OverlapCircle(pos.position, checkRadius, islayer);
        jumpCnt--;
        if (isGround == true && jumpCnt > 0)
        {
            rigid20.AddForce(transform.up * jumpForce);
            myaudio.clip = msic[1];
            animator.SetBool("jump", true);
            Invoke("rejump", 1f);
            myaudio.Play();

        }

        if (isGround == false && GameManager.instance.isPlay && jumpCnt > 0)
        {
            rigid20.AddForce(transform.up * jumpForce);
            myaudio.clip = msic[1];
            myaudio.Play();
        }

        if(rigid20.velocity.y > 0.5f)
        {
            rigid20.velocity = new Vector2(0, 0.5f);
        }

    }



    public void rejump()
        {
        animator.SetBool("jump", false);
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