using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    static GameController _instance;
    public static GameController Instance { get { return _instance; } }

    public static FlipStates flipState = FlipStates.Orange;

    public delegate void OnVariableChangeDelegate(FlipStates state);
    public static event OnVariableChangeDelegate OnVariableChange;

    public static PlayerController playerController;


    public static void ChangeFlipState()
    {
        if(flipState == FlipStates.Orange) 
        { 
            flipState = FlipStates.Blue;
        }
        else { flipState = FlipStates.Orange; }

        OnVariableChange(flipState);
    }

    private void Awake()
    {

        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Enemy"), LayerMask.NameToLayer("Enemy"), true);
        Init();
    }

    void Update()
    {
        FlipStateCheck();
        if (Input.GetKeyDown(KeyCode.Space))
        {          
            FlipState();
        }
    }

    public static void Init()
    {
        UpdateCollision();
    }

    void FlipStateCheck()
    {
        if(GameController.flipState == FlipStates.Orange)
        {
            PlayerController.animator.runtimeAnimatorController = PlayerController.orange;
        }
        else if(GameController.flipState == FlipStates.Blue)
        {
            PlayerController.animator.runtimeAnimatorController = PlayerController.blue;
        }
    }

    public static void FlipState()
    {
        if (Level.amountOfFlips <= 0) { return; }
        Level.useFlip();

        ChangeFlipState();
        UpdateCollision();
    }


    static void UpdateCollision()
    {
        int player = LayerMask.NameToLayer("Player");
        int blue = LayerMask.NameToLayer("Blue");
        int orange = LayerMask.NameToLayer("Orange");

        if (flipState == FlipStates.Blue)
        {
            Physics2D.IgnoreLayerCollision(player, blue, false);
            Physics2D.IgnoreLayerCollision(player, orange, true);

            PlayerController.ignoreLayer ^= (1 << orange);
            PlayerController.ignoreLayer |= (1 << blue);
        }
        else
        {
            Physics2D.IgnoreLayerCollision(player, orange, false);
            Physics2D.IgnoreLayerCollision(player, blue, true);

            PlayerController.ignoreLayer ^= (1 << blue);
            PlayerController.ignoreLayer |= (1 << orange);
        }
    }

}

public enum FlipStates {
    Blue,
    Orange
}

