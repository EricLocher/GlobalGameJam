using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;

    void Update()
    {
        text.text = ""+ Level.score * 100; 
    }
}
