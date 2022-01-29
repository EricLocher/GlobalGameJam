using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Text text;

    float t = 0;
    int minutes, seconds;

    void Update()
    {
        t += Time.deltaTime;

        if(t >= 1) { seconds++; t = 0; }
        if(seconds >= 60) { minutes++; seconds = 0; }

        if(seconds < 10)
            text.text = minutes + ":0" + seconds;
        else
            text.text = minutes + ":" + seconds;

    }



}
