using UnityEngine;
using System.Collections;

public class ParticleAnim : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (GetComponent<ParticleSystem>().main.loop == false)
        {
            if (Time.timeScale < 0.01f)
            {
                GetComponent<ParticleSystem>().Simulate(Time.unscaledDeltaTime, true, false);
            }
        }
        else if (GetComponent<ParticleSystem>().main.loop == true)
        {
            if (Time.timeScale < 0.01f)
            {
                GetComponent<ParticleSystem>().Simulate(Time.unscaledDeltaTime, true, false);
            }
            if (Time.timeScale > 0.01f)
            {
                GetComponent<ParticleSystem>().Simulate(Time.unscaledDeltaTime, true, false);
            }
        }
    }
}