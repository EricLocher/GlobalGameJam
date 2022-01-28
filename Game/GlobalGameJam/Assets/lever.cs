using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lever : MonoBehaviour, IInteractable
{
    [SerializeField] bool isToggled;

    public void interact()
    {
        if(!isToggled) { isToggled = true; }
        else { isToggled = false; }
    }
}
