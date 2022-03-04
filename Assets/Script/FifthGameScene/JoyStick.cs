using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class JoyStick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    RectTransform m_rectBack;
    RectTransform m_rectJoystick;

    Transform player;
    float m_fRadius;
    float m_fSpeed = 8.0f;
    //float m_fSqr = 0f;

    Vector3 m_vecMove;

    Vector2 m_vecNormal;

    bool m_bTouch = false;

    //Animator walkAnim;
    //float moveSpeed = 5f;
    //bool playerMoving;
    //Vector2 lastMove;

    void Start()
    {
        m_rectBack = transform.Find("Joystickback").GetComponent<RectTransform>();
        m_rectJoystick = transform.Find("Joystickback/Joystick").GetComponent<RectTransform>();

        player = GameObject.Find("Player").transform;

        // JoystickBackground의 반지름입니다.
        m_fRadius = m_rectBack.rect.width * 0.5f;

        //walkAnim = player.GetComponent<Animator>();
        //playerMoving = false;
    }

    void Update()
    {
        if (m_bTouch)
        {
            player.position += m_vecMove;

            /*
            playerMoving = false;

            if (Input.GetAxisRaw("Horizontal") > 0f || Input.GetAxisRaw("Horizontal") < 0f)
            {
                transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
                playerMoving = true;
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
            }

            if (Input.GetAxisRaw("Vertical") > 0f || Input.GetAxisRaw("Vertical") < 0f)
            {
                transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
                playerMoving = true;
                lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
            }

            walkAnim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
            walkAnim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
            walkAnim.SetBool("PlayerMoving", playerMoving);
            walkAnim.SetFloat("LastMoveX", lastMove.x);
            walkAnim.SetFloat("LastMoveY", lastMove.y);
            */
        }

    }

    void OnTouch(Vector2 vecTouch)
    {
        Vector2 vec = new Vector2(vecTouch.x - m_rectBack.position.x, vecTouch.y - m_rectBack.position.y);


        // vec값을 m_fRadius 이상이 되지 않도록 합니다.
        vec = Vector2.ClampMagnitude(vec, m_fRadius);
        m_rectJoystick.localPosition = vec;

        // 조이스틱 배경과 조이스틱과의 거리 비율로 이동합니다.
        float fSqr = (m_rectBack.position - m_rectJoystick.position).sqrMagnitude / (m_fRadius * m_fRadius);

        // 터치위치 정규화
        Vector2 vecNormal = vec.normalized;

        m_vecMove = new Vector3(vecNormal.x * m_fSpeed * Time.deltaTime * fSqr, vecNormal.y * m_fSpeed * Time.deltaTime * fSqr, 0f);
        //player.eulerAngles = new Vector3(0f, Mathf.Atan2(vecNormal.x, vecNormal.y) * Mathf.Rad2Deg, 0f);
    }

    public void OnDrag(PointerEventData eventData)
    {
        OnTouch(eventData.position);
        m_bTouch = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnTouch(eventData.position);
        m_bTouch = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // 원래 위치로 되돌립니다.
        m_rectJoystick.localPosition = Vector2.zero;
        m_bTouch = false;
    }
}