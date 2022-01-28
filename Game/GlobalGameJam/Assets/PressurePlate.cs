using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    //bool active = false;
    [SerializeField] Animator anim;
    //Animation animation;
    public bool isActive = false;

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
        if(collision.gameObject.CompareTag ("Pressure"))
        {
            isActive = true;
            anim.SetBool("active", isActive);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            isActive = true;
            anim.SetBool("active", isActive);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isActive = false;
        anim.SetBool("active", isActive);
    }
}
