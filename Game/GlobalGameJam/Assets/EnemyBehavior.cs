using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] float walkSpeed;
    [SerializeField] LayerMask layerMask;



    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 0.5f, layerMask);


        if(hit.collider != null && hit.collider.gameObject != gameObject)
        {
            walkSpeed *= -1;
        }else
        {
            hit = Physics2D.Raycast(transform.position, transform.right *-1, 0.5f, layerMask);

            if (hit.collider != null && hit.collider.gameObject != gameObject)
            {
                walkSpeed *= -1;
            }
        }

        transform.Translate(new Vector2(walkSpeed * Time.deltaTime, 0));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) { return; }

        if (collision.transform.position.y > transform.position.y )
        {
            Destroy(gameObject);
        }

    }

}
