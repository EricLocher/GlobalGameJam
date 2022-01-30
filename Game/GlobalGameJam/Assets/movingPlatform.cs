using UnityEngine;

public class movingPlatform : MonoBehaviour
{
    [SerializeField] bool moving;
    public MoveDirections moveDir = MoveDirections.Vertical;
    [SerializeField] float moveDist;
    [SerializeField] float moveSpeed;
    [SerializeField] float offset;

    [SerializeField] SpriteRenderer spriteRenderer;

    Vector2 startPos;
    bool checkMax = true, checkMin = false;

    public float moveVel;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        startPos = transform.position;

        if(moveDir == MoveDirections.Vertical)
            transform.position = new Vector2(transform.position.x, transform.position.y + offset);
        else
            transform.position = new Vector2(transform.position.x + offset, transform.position.y);
    }


    void Update()
    {
        if (!moving) { return; }

        if (moveDir == MoveDirections.Vertical)
        {
            if (transform.position.y >= startPos.y + moveDist)
            {
                checkMax = true;
                checkMin = false;
            } else if (transform.position.y <= startPos.y - moveDist)
            {
                checkMax = false;
                checkMin = true;
            }

            if(checkMax)
                moveVel = (moveDist * (Time.deltaTime * moveSpeed)) * -1;
            else if(checkMin)
                moveVel = (moveDist * (Time.deltaTime * moveSpeed));


            transform.position = new Vector2(transform.position.x, transform.position.y + moveVel);

        }
        else
        {
            if (transform.position.x >= startPos.x + moveDist)
            {
                checkMax = true;
                checkMin = false;
            }
            else if (transform.position.x <= startPos.x - moveDist)
            {
                checkMax = false;
                checkMin = true;
            }

            if (checkMax)
                moveVel = (moveDist * (Time.deltaTime * moveSpeed)) * -1;
            else if (checkMin)
                moveVel = (moveDist * (Time.deltaTime * moveSpeed));

            transform.position = new Vector2(transform.position.x + moveVel, transform.position.y);
        }
    }

    public enum MoveDirections
    {
        Vertical,
        Horizontal
    }

    private void OnDrawGizmos()
    {
        if(!moving) { return; }
        Vector2 _tempPos = transform.position;

        if (startPos != Vector2.zero)
        {
            _tempPos = startPos;
        }
        Gizmos.color = Color.green;
        if(moveDir == MoveDirections.Vertical)
        {
            Gizmos.DrawLine(_tempPos, new Vector2(_tempPos.x, _tempPos.y + moveDist));
            Gizmos.DrawLine(_tempPos, new Vector2(_tempPos.x, _tempPos.y - moveDist));

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(new Vector2(_tempPos.x, _tempPos.y + offset), 0.3f);


        }
        else
        {
            Gizmos.DrawLine(_tempPos, new Vector2(_tempPos.x + moveDist + spriteRenderer.size.x/2, _tempPos.y));
            Gizmos.DrawLine(_tempPos, new Vector2(_tempPos.x - moveDist - spriteRenderer.size.x/2, _tempPos.y));

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(new Vector2(_tempPos.x + offset, _tempPos.y), 0.3f);
        }




    }

}


