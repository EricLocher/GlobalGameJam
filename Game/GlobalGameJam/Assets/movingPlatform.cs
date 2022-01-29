using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{

    [SerializeField] MoveDirections moveDir = MoveDirections.Vertical;
    [SerializeField] float moveDist;
    [SerializeField] float moveSpeed;

    Vector2 startPos;
    bool check = false;

    void Start()
    {
        startPos = transform.position;
    }


    void Update()
    {
        
        if(moveDir == MoveDirections.Vertical)
        {
            if(Mathf.Abs(transform.position.y - startPos.y) >= moveDist)
            {
                if(check) { check = false; }
                else { check = true; }
            }

            float moveY = (moveDist * (Time.deltaTime * moveSpeed));

            if (check)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + moveY);
            }
            else
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - moveY);
            }


        }
        else
        {
            if (Mathf.Abs(transform.position.x - startPos.x) >= moveDist)
            {
                if (check) { check = false; }
                else { check = true; }
            }

            float moveX = (moveDist * (Time.deltaTime * moveSpeed));

            if (check)
            {
                transform.position = new Vector2(transform.position.x + moveX, transform.position.y);
            }
            else
            {
                transform.position = new Vector2(transform.position.x - moveX, transform.position.y);
            }
        }
        


    }

    enum MoveDirections
    {
        Vertical,
        Horizontal
    }


}


