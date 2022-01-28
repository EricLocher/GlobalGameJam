using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class FlippableObject : MonoBehaviour
{
    [SerializeField] Sprite BlueSprite, OrangeSprite;
    [SerializeField] FlipStates dimension = FlipStates.Blue;

    SpriteRenderer spr;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        if(dimension == FlipStates.Blue) 
        { 
            spr.sprite = BlueSprite;
            gameObject.layer = 7;
        }
        else if (dimension == FlipStates.Orange) 
        { 
            spr.sprite = OrangeSprite;
            gameObject.layer = 8;
        }

        

    }

    void Update()
    {
        
       
        
    }







}
