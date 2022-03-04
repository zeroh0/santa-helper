using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobBasis : MonoBehaviour
{
    // Start is called before the first frame update
    public float mobSpeed = 0;
    public Vector2 StartPostion;

    private void OnEnable()
    {
        transform.position = StartPostion;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.isPlay)
        {
            transform.Translate(Vector2.left * Time.deltaTime * GameManager.instance.gameSpeed);

            if (transform.position.x < -6)
            {
                gameObject.SetActive(false);
            }

        }
      
       
    }
}
