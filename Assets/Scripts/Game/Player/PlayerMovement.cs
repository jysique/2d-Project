using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 8.0f;

    private float maxVelocity = 4f;
    private Rigidbody2D body2D;
    private Animator animator;
    private void Awake() {
        body2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void FixedUpdate() {
        //Fisicas
        PlayerWalkKeyBoard();
    }
    void Update()
    {
        //Logica de juego 
    }
    void PlayerWalkKeyBoard(){
        float forceX = 0f;
        float vel = Mathf.Abs(body2D.velocity.x);
        /*
        GetAxis: Del -1 al 1
        GetAxisRaw: -1,0 o 1
        */
        float h = Input.GetAxisRaw("Horizontal");
        if (h>0)
        {
            if (vel < maxVelocity)
            {
                forceX = speed;
            }
            Vector3 temp = transform.localScale;
            temp.x = 1f;
            transform.localScale = temp;
            animator.SetBool("isWalking",true);
        }
        else if (h< 0)
        {
            if (vel < maxVelocity)
            {
                forceX = -speed;
            }
            Vector3 temp = transform.localScale;
            temp.x = -1f;
            transform.localScale = temp;
            animator.SetBool("isWalking",true);
        }else{
            animator.SetBool("isWalking",false);
            body2D.velocity = Vector2.zero;
        }
        body2D.AddForce(new Vector2(forceX,0));
    }
}
