using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlipText : MonoBehaviour
{
    [SerializeField] Text text;


    void Update()
    {
        text.text = "Flips Remaining : " + Level.amountOfFlips; 
    }



}
