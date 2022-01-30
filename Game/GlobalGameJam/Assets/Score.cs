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
        text.text = "Score : " + Level.score * 100; 
    }
}
