using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    bool activated;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(activated == true) { return; }
        activated = true;
        SpawnPoint.pos = gameObject.transform.position;
    }

}
