using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDoor : MonoBehaviour
{
    Lever1 orangeL, blueL;
    [SerializeField] GameObject orangeLever, blueLever;
    [SerializeField] GameObject orangeDoor, blueDoor;

    private void Start()
    {   
        orangeL = orangeLever.GetComponent<Lever1>();
        blueL = blueLever.GetComponent<Lever1>();
    }

    private void Update()
    {
        DoorBehavior();
    }

    void DoorBehavior()
    {
        Debug.Log(orangeL);
        if(orangeL.isToggled)
        {
            orangeDoor.SetActive(false);
        }
        if(blueL.isToggled)
        {
            blueDoor.SetActive(false);
        }
    }
}
