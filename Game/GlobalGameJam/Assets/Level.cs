using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    static Level _instance;
    public static Level Instance { get { return _instance; } }

    [SerializeField] int _amountOfFlips;
    public static int amountOfFlips;


    void Awake()
    {
        amountOfFlips = _amountOfFlips;

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

    public static void useFlip()
    {
        amountOfFlips--;
        //TODO If flips == 0 end level etc....
    }

    public static void Win()
    {
        //
    }

}
