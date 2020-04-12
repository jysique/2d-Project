using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{
    private Animator animator;
    private BoxCollider2D collider2D;
    private Rigidbody2D body2D;
    void Start()
    {
        
        collider2D = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        body2D = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D other){ //isTrigger = false
        if (other.gameObject.tag == "Zombie")
        {
            animator.Play("Heroe");
            body2D.velocity = new Vector2(0.0f,12f);
            collider2D.isTrigger = true;
        }
    }

}
