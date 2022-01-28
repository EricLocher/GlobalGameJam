using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlippableObject : MonoBehaviour
{
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
            spr.sprite = GameController.blueSprite;
            gameObject.layer = LayerMask.NameToLayer("Blue");
        }
        else if (dimension == FlipStates.Orange) 
        { 
            spr.sprite = GameController.orangeSprite;
            gameObject.layer = LayerMask.NameToLayer("Orange");
        }

    }
}
