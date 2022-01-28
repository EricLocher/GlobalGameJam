using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{



    static GameController _instance;
    public static GameController Instance { get { return _instance; } }

    public static FlipStates flipState = FlipStates.Orange;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        UpdateCollision();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            FlipState();
            Debug.Log(flipState);
        }
    }

    public static void FlipState()
    {
   
        if(flipState == FlipStates.Blue)
        {
            flipState = FlipStates.Orange;
        }
        else
        {
            flipState = FlipStates.Blue;
        }

        UpdateCollision();
    }


    static void UpdateCollision()
    {

        int blue = LayerMask.NameToLayer("Blue");
        int orange = LayerMask.NameToLayer("Orange");

        if (flipState == FlipStates.Blue)
        {
            Physics2D.IgnoreLayerCollision(9, blue, false);
            Physics2D.IgnoreLayerCollision(9, orange, true);

            PlayerController.ignoreLayer ^= (1 << orange);
            PlayerController.ignoreLayer |= (1 << blue);
        }
        else
        {
            Physics2D.IgnoreLayerCollision(9, orange, false);
            Physics2D.IgnoreLayerCollision(9, blue, true);

            PlayerController.ignoreLayer ^= (1 << blue);
            PlayerController.ignoreLayer |= (1 << orange);
        }
    }

}

public enum FlipStates {
    Blue,
    Orange
}

