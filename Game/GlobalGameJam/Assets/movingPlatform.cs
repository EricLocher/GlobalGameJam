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
    bool check = false;

    public float moveVel;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        }
        else
        {
            Gizmos.DrawLine(_tempPos, new Vector2(_tempPos.x + moveDist + spriteRenderer.size.x/2, _tempPos.y));
            Gizmos.DrawLine(_tempPos, new Vector2(_tempPos.x - moveDist - spriteRenderer.size.x/2, _tempPos.y));
        }

    }

}


