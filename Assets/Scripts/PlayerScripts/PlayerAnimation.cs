using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();

    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Enemy"){
            animator.Play("Heroe");
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
         if(other.gameObject.tag == "Enemy"){
            animator.Play("Running");
        }   
    }
}
