using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlippableObject : MonoBehaviour
{
    [SerializeField] Sprite BlueSprite, OrangeSprite;
    [SerializeField] FlipStates dimension = FlipStates.Blue;

    SpriteRenderer spr;

    void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
    }


    void Start()
    {
        if(dimension == FlipStates.Blue) 
        { 
            spr.sprite = BlueSprite;
            gameObject.layer = LayerMask.NameToLayer("Blue");
        }
        else if (dimension == FlipStates.Orange) 
        { 
            spr.sprite = OrangeSprite;
            gameObject.layer = LayerMask.NameToLayer("Orange");
        }

    }
}
