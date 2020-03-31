using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieMov : MonoBehaviour
{
    // Start is called before the first frame update
    
    private BoxCollider2D collider;
    private Rigidbody2D body;
    
    [Header("Obstacle Variables")]
    public float speed;
    void Start()
    {
        
        collider = GetComponent<BoxCollider2D>();
        body = GetComponent<Rigidbody2D>();
        
        speed =speed ==0? -2:speed;
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = new Vector2(speed,0.0f);
    }
}
