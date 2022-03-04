using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> Mobpool = new List<GameObject>();
    public GameObject[] Mobs;
    public int objCnt = 1;
     void Awake()
    {
        for(int i = 0; i<Mobs.Length;i++)
        {
            for(int q = 0; q<objCnt;q++)
            {
                Mobpool.Add(CreateObj(Mobs[i], transform));
            }
        }
        
    }
    private void Start()
    {
        GameManager.instance.onPlay += PlayGame;
       
    }
    void PlayGame(bool isPlay)
    {
        if (isPlay)
        {
            for (int i = 0; i < Mobpool.Count; i++)
            {
                if (Mobpool[i].activeSelf)
                    Mobpool[i].SetActive(false);
            }
            StartCoroutine(CreateMod());
        }
        else
            StopAllCoroutines();
    }

    IEnumerator CreateMod()
    {
        yield return new WaitForSeconds(0.5f);
        while (GameManager.instance.isPlay)
        {
            Mobpool[DeactiveMob()].SetActive(true);
            yield return new WaitForSeconds(Random.Range(0.5f, 2f));
        }
    }

    int DeactiveMob()
    {
        List<int> num = new List<int>();
        for (int i = 0; i < Mobpool.Count; i++)
        {
            if (!Mobpool[i].activeSelf)
            num.Add(i);
        }
        int x = 0;
            if(num.Count > 0)
                x = num[Random.Range(0, num.Count)];
                return x;
      
      
    }

    GameObject CreateObj(GameObject obj, Transform parent)
    {
        GameObject copy = Instantiate(obj);
        copy.transform.SetParent(parent);
        copy.SetActive(false);
        return copy;
    }    
    
  
}
