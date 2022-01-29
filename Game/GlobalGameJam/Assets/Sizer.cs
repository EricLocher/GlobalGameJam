using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Sizer : MonoBehaviour
{
    private void Update()
    {
        Vector2 spritzy = GetComponent<SpriteRenderer>().size;
        GetComponent<CapsuleCollider2D>().size = spritzy;
    }
}
