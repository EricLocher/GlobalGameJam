using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    static GameController _instance;
    public static GameController Instance { get { return _instance; } }

    [SerializeField] Sprite _blueSprite, _orangeSprite, _blueInactive, _orangeInactive;
    public static Sprite blueSprite, orangeSprite, blueInactive, orangeInactive;

    public static FlipStates flipState = FlipStates.Orange;

    public delegate void OnVariableChangeDelegate(FlipStates state);
    public static event OnVariableChangeDelegate OnVariableChange;

    public static void ChangeFlipState()
    {
        if(flipState == FlipStates.Orange) { flipState = FlipStates.Blue; }
        else { flipState = FlipStates.Orange; }

        OnVariableChange(flipState);

    }



    private void Awake()
    {

        blueSprite = _blueSprite;
        orangeSprite = _orangeSprite;
        blueInactive = _blueInactive;
        orangeInactive = _orangeInactive;

        if (_instance == null)
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

