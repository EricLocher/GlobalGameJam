using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] GameObject key;
    PressurePlate pressurePlate;
    Animator animator;

    private void Start()
    {
        pressurePlate = key.GetComponent<PressurePlate>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        DoorBehavior();
    }
    void DoorBehavior()
    {
        if(pressurePlate.isActive)
        {
            animator.SetBool("active", pressurePlate.isActive);
           
        }
        else
        {
            animator.SetBool("active", pressurePlate.isActive);
            
        }
    }
    
}
