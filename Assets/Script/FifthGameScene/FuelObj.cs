using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelObj : MonoBehaviour
{
    GameObject gameDirector;

    // Start is called before the first frame update
    void Start()
    {
        gameDirector = GameObject.Find("FifthGameDirector");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" & gameDirector != null)
        {
            gameDirector.GetComponent<FifthGameDirector>().AddFuel();
            Destroy(gameObject);
        }
        
    }
}
