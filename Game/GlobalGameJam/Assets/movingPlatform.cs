using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{
    [SerializeField] bool moving;
    [SerializeField] MoveDirections moveDir = MoveDirections.Vertical;
    [SerializeField] float moveDist;
    [SerializeField] float moveSpeed;
    [SerializeField] float offset;

    Vector2 startPos;
    bool check = false;

    public float moveX, moveY;

    void Start()
    {
        startPos = transform.position;
        transform.position = new Vector2(transform.position.x, transform.position.y + offset);
    }


    void Update()
    {
        if(!moving) { return; }
        
        if(moveDir == MoveDirections.Vertical)
        {
            if(Mathf.Abs(transform.position.y - startPos.y) >= moveDist)
            {
                if(check) { check = false; }
                else { check = true; }
            }

            moveY = (moveDist * (Time.deltaTime * moveSpeed));

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

            moveX = (moveDist * (Time.deltaTime * moveSpeed));

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


