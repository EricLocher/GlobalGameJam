using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlippableObject : MonoBehaviour
{
    [SerializeField] FlipStates dimension = FlipStates.Blue;

    SpriteRenderer spr;

    [SerializeField] Sprite blueSprite, orangeSprite, blueInactive, orangeInactive;


    void Start()
    {
        Debug.Log(this);
        spr = GetComponent<SpriteRenderer>();

        if (dimension == FlipStates.Blue) 
        { 
            spr.sprite = blueSprite;
            gameObject.layer = LayerMask.NameToLayer("Blue");
        }
        else if (dimension == FlipStates.Orange) 
        { 
            spr.sprite = orangeSprite;
            gameObject.layer = LayerMask.NameToLayer("Orange");
        }


        UpdateSprite(GameController.flipState);

        GameController.OnVariableChange += UpdateSprite;
    }


    void UpdateSprite(FlipStates value)
    {

        if(spr == null) { Start();  }

        if(dimension != value)
        {
            if(dimension == FlipStates.Blue)
            {
                spr.sprite = blueInactive;
            }
            else
            {
                spr.sprite = orangeInactive;
            }
        }
        else
        {
            if (dimension == FlipStates.Blue)
            {
                spr.sprite = blueSprite;
            }
            else
            {
                spr.sprite = orangeSprite;
            }
        }
    }

    void OnDestroy()
    {
        GameController.OnVariableChange -= UpdateSprite;
    }

}
