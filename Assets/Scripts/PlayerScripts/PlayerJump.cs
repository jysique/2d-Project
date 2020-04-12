using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerJump : MonoBehaviour
{
    // Start is called before the first frame update
    private BoxCollider2D collider;
    private Rigidbody2D body;
    private Animator animator;
    public Button buttomJump;
    
    private bool isJumping = false;
    public float jumpForce = 12f;
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.Play("Running");

        buttomJump.onClick.AddListener(()=>makeJump());
    }

    void makeJump(){
        //print("Salto");
        if (isJumping)
        {
            isJumping = false;
            float forwardForce = 1.0f;
            if (transform.position.x < 0)
            {
                forwardForce =1.0f;
            }else{
                forwardForce = 0.0f;
            }
            body.velocity = new Vector2(forwardForce,jumpForce);
            
        }


    }
    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(body.velocity.y)==0)
        {
            isJumping =true;
        }
    }
}
