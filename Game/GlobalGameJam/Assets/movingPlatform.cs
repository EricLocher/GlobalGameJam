using UnityEngine;

public class movingPlatform : MonoBehaviour
{
    [SerializeField] bool moving;
    public MoveDirections moveDir = MoveDirections.Vertical;
    [SerializeField] float moveDist;
    [SerializeField] float moveSpeed;
    [SerializeField] float offset;

    Vector2 startPos;
    bool check = false;

    public float moveVel;

    void Start()
    {
        startPos = transform.position;
        transform.position = new Vector2(transform.position.x, transform.position.y + offset);
    }


    void Update()
    {
        if (!moving) { return; }

        if (moveDir == MoveDirections.Vertical)
        {
            if (Mathf.Abs(transform.position.y - startPos.y) >= moveDist)
            {
                if (check) { check = false; }
                else { check = true; }
            }

            moveVel = (moveDist * (Time.deltaTime * moveSpeed));

            if (!check) { moveVel *= -1; }
            transform.position = new Vector2(transform.position.x, transform.position.y + moveVel);

        }
        else
        {
            if (Mathf.Abs(transform.position.x - startPos.x) >= moveDist)
            {
                if (check) { check = false; }
                else { check = true; }
            }

            moveVel = (moveDist * (Time.deltaTime * moveSpeed));

            if (!check) { moveVel *= -1; }
            transform.position = new Vector2(transform.position.x + moveVel, transform.position.y);
        }



    }

    public enum MoveDirections
    {
        Vertical,
        Horizontal
    }


}


