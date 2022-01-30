using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FlipText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;


    void Update()
    {
        text.text = "Flips Remaining : " + Level.amountOfFlips; 
    }



}
