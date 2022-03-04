using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    GameObject fifthDirector;
    Animator walkAnim;
    Button turnOn;

    private float horizontalMove = 0f;
    private float verticalMove = 0f;
    public Joystick joyStick;
    public float speedHorizontal = 1;
    public float speedVertical = 1;
    float moveSpeed = 3f;
    bool playerMoving;
    Vector2 lastMove;

    
    float sound;
    AudioSource myaudio;
    //public AudioClip[] sfx;
    
    // Start is called before the first frame update
    void Start()
    {
        fifthDirector = GameObject.Find("FifthGameDirector");
        walkAnim = GetComponent<Animator>();
        turnOn = GameObject.Find("TurnOnBtn").GetComponent<Button>();

        playerMoving = false;

        
        myaudio = gameObject.GetComponent<AudioSource>();
        sound = MainAllMenu.music_vol;
        myaudio.volume = sound;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //이탈 방지
        Vector3 pos = transform.position;

        if (pos.x < -45.0f) pos.x = -45.0f;
        if (pos.x > 45.0f) pos.x = 45.0f;
        if (pos.y < -45.0f) pos.y = -45.0f;
        if (pos.y > 45.0f) pos.y = 45.0f;

        transform.position = pos;

        //제어
        horizontalMove = joyStick.Horizontal * speedHorizontal;
        transform.position += new Vector3(horizontalMove, 0, 0) * Time.deltaTime * moveSpeed;
        verticalMove = joyStick.Vertical * speedVertical;
        transform.position += new Vector3(0, verticalMove, 0) * Time.deltaTime * moveSpeed;

        playerMoving = false;

        myaudio.volume = 0f;

        if (horizontalMove > 0f || horizontalMove < 0f)
        {
            transform.Translate(new Vector3(horizontalMove * moveSpeed * Time.deltaTime, 0f, 0f));
            playerMoving = true;
            lastMove = new Vector2(horizontalMove, verticalMove);
            myaudio.volume = 1f;
        }

        if (verticalMove > 0f || verticalMove < 0f)
        {
            transform.Translate(new Vector3(0f, verticalMove * moveSpeed * Time.deltaTime, 0f));
            playerMoving = true;
            lastMove = new Vector2(horizontalMove, verticalMove);
            myaudio.volume = 1f;
        }

        //walkAnim.SetBool("PlayerDamage", false);
        walkAnim.SetFloat("MoveX", horizontalMove);
        walkAnim.SetFloat("MoveY", verticalMove);
        walkAnim.SetBool("PlayerMoving", playerMoving);
        walkAnim.SetFloat("LastMoveX", lastMove.x);
        walkAnim.SetFloat("LastMoveY", lastMove.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Finish")
        {
            fifthDirector.GetComponent<FifthGameDirector>().ClearGame();
        }

        if (other.gameObject.tag == "Mob")
        {
            //walkAnim.SetBool("PlayerDamage", true);
        }

    }


    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "point")
        {
            turnOn.interactable = true;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "point")
        {
            turnOn.interactable = false;
        }

    }
}
