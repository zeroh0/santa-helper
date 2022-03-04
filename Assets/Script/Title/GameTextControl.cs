using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameTextControl : MonoBehaviour
{
    Text adventureText;


    // Use this for initialization
    void Start()
    {
        adventureText = GetComponent<Text>();
        StartCoroutine(BlinkText());
    }

    public IEnumerator BlinkText()
    {
        while(true)
        {
            adventureText.text = "";
            yield return new WaitForSeconds(0.75f);
            adventureText.text = "모험 버튼을 눌러주세요";
            yield return new WaitForSeconds(0.75f);
        }
    }

  
    // Update is called once per frame
    void Update()
    {

    }

}