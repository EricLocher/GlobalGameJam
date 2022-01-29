using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, IInteractable
{
    PlayerController playerController;
    GameObject player;
    Vector2 playerPos;
    Vector2 boxPos;
    public bool boxOnHead;

    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        //Vector2 playerPos = player.transform.position;
        //boxPos = new Vector2(player.transform.position.x, player.transform.position.y + 1);
        //gameObject.transform.position = boxPos;
        BoxOnHead();
        //cant jump with box
        if (playerController.rb.velocity.y > 0)
        {

        }
    }

    void BoxOnHead()
    {
        if (boxOnHead)
        {
            Vector2 playerPos = player.transform.position;
            boxPos = new Vector2(player.transform.position.x, player.transform.position.y + 0.5f);
            gameObject.transform.position = boxPos;
        }
        else
            boxPos = new Vector2(player.transform.position.x + 1, player.transform.position.y + 2);
        
    }
    public void interact()
    {
        Debug.Log("hell");
        if(boxOnHead == true)
        {
            boxOnHead = false;
        }
        else if (boxOnHead == false)
        boxOnHead = true;
        //if box on head not true then carry crate
        // if box on head true then drop crate

    }
}
