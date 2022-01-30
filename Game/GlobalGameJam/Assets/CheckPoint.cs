using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    [SerializeField] Sprite activeSprite;


    bool activated = false;

    private void Start()
    {
        if (activated)
        {
            GetComponent<SpriteRenderer>().sprite = activeSprite;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(activated == true) { return; }
        activated = true;
        SpawnPoint.pos = gameObject.transform.position;

        GetComponent<SpriteRenderer>().sprite = activeSprite;

    }

}
