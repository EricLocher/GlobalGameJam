using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Lever : MonoBehaviour, IInteractable
{
    [SerializeField] bool isToggled;
    [SerializeField] SpriteRenderer spr;

    public void interact()
    {
        if (!isToggled) { isToggled = true; }
        else { isToggled = false; }

        spr.flipX = isToggled;
    }
}
