using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] Text text;


    void Update()
    {
        text.text = "Score : " + Level.score * 100; 
    }
}
