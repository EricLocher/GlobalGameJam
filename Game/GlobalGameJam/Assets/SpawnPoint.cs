using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    static SpawnPoint _instance;
    public static SpawnPoint Instance { get { return _instance; } }

    public static Vector2 pos;
    public static Vector2 startPos;


    void Awake()
    {
        startPos = transform.position;


        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }


        pos = startPos;

    }


}
