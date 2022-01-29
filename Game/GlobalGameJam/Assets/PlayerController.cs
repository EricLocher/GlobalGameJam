using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static LayerMask ignoreLayer;

    Rigidbody2D rb;
    float speed = 5;

    float jumpForce = 7;
    bool isGrounded = false;
    float coyoteTime = 0.1f;
    float coyoteCounter;
    float x;
    float y;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    private SpriteRenderer mySpriteRenderer;

    public RuntimeAnimatorController blue;
    public RuntimeAnimatorController orange;
    public Animator animator;

    [SerializeField] List<GameObject> interactableObjects = new List<GameObject>();

    public bool flipX;

    bool isPushing;

    private void Start()
    {
        blue = Resources.Load<RuntimeAnimatorController>("blue");
        orange = Resources.Load<RuntimeAnimatorController>("orange");

        mySpriteRenderer = GetComponent<SpriteRenderer>();

        ignoreLayer |= (1 << LayerMask.NameToLayer("Ground"));
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        y = Input.GetAxisRaw("Vertical");
        Debug.Log(y);
        if(Input.GetKeyDown(KeyCode.B))
        {
            animator.runtimeAnimatorController = blue;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            animator.runtimeAnimatorController = orange;
        }
        Move();
        Push();
        Jump();
        GroundChecker();
        Interact();
    }

    void Push()
    {
        if (isPushing == true && Mathf.Abs(x) < 1)
        {
            isPushing = false;
            animator.SetBool("isPushing", isPushing);
        }
    }

    void Move()
    {
        x = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("walkForce", Mathf.Abs(x));

        float moveBy = x * speed;
        rb.velocity = new Vector2(moveBy, rb.velocity.y);

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            mySpriteRenderer.flipX = true;
        }
        else
            mySpriteRenderer.flipX = false;
    }

    void Jump()
    {
        if (isGrounded) 
        { 
            coyoteCounter = coyoteTime;          
        }
        else 
        { 
            coyoteCounter -= Time.deltaTime;                      
        }

        if (coyoteCounter >0f && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        if (rb.velocity.y > 0)
        {
            animator.SetBool("isJumping", true);
        }
        else
            animator.SetBool("isJumping", false);
    }

    void GroundChecker()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1, ignoreLayer);

        if (hit.collider != null)
        {
            isGrounded = true;

            movingPlatform _movingPlatform = hit.collider.gameObject.GetComponent<movingPlatform>();

            if (_movingPlatform != null)
            {
                if(_movingPlatform.moveX != 0)
                {
                    transform.position += new Vector3(_movingPlatform.moveX, 0, 0);
                }
                else if(_movingPlatform.moveY != 0)
                {
                    transform.position += new Vector3(0, _movingPlatform.moveY, 0);
                }
            }

        }
        else
            isGrounded = false;
    }
    void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(interactableObjects.Count < 1) { return; }

            //BUBBLE SORT!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! D�LIG ALGORITM JETED�LIG MEN OM DU BARA VILL HA DEN SOM �R ST�RST, JETEBRA
            float dist = Mathf.Abs((interactableObjects[0].transform.position - transform.position).sqrMagnitude);
            GameObject closestObject = interactableObjects[0];

            foreach(GameObject _interactable in interactableObjects)
            {
                float _dist = Mathf.Abs((_interactable.transform.position - transform.position).sqrMagnitude);
                if (dist >= _dist)
                {
                    dist = _dist;
                    closestObject = _interactable;
                }
            }

            closestObject.GetComponent<IInteractable>().interact();

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Box") && 
            collision.gameObject.layer != LayerMask.NameToLayer("Ground") &&
            (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0 ))
        {
            Debug.Log("hall�?2");
            isPushing = true;
        }
        else { isPushing = false; }
        Debug.Log(isPushing);
        animator.SetBool("isPushing", isPushing);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isPushing = false;
        animator.SetBool("isPushing", isPushing);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IInteractable>() != null)
            interactableObjects.Add(collision.gameObject);   
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IInteractable>() != null)
            interactableObjects.Remove(collision.gameObject);
    }
}
