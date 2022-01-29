using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] Animator anim;
    public bool isActive = false;

    List<GameObject> onPlate = new List<GameObject>();

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            anim.Play("Up");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            isActive = true;
            anim.SetBool("active", isActive);

            onPlate.Add(collision.gameObject);

        }
        /*else if (collision.gameObject.CompareTag("Player"))
        {
            isActive = true;
            anim.SetBool("active", isActive);
        }*/
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            onPlate.Remove(collision.gameObject);

            if(onPlate.Count < 1)
            {
                isActive = false;
            }

            anim.SetBool("active", isActive);
        }
    }
}
