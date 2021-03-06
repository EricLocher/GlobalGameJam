using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    static Level _instance;
    public static Level Instance { get { return _instance; } }

    public static int score = 0;
    public static int lives;

    void Awake()
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
        lives = 3;
        score = 0;
    }


    public static void useFlip()
    {
        //TODO If flips == 0 end level etc....
    }

    public static void Win()
    {
        //TODO Add Win state
    }

    public static void ResetLevel()
    {

        if(lives <= 1)
        {
            LevelManager.RestartLevel();
        }

        lives--;
        PlayerController.playerTransform.position = SpawnPoint.pos;
        
    }


}
