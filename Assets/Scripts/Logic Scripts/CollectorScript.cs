using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollectorScript : MonoBehaviour
{
    // Start is called before the first frame update
    private BoxCollider2D collider2D;
    private List<string> tags = new List<string>(){"Enemy","Zombie"};
    void Start()
    {
        collider2D = GetComponent<BoxCollider2D>();
        collider2D.isTrigger = true;
    }
    void OnTriggerEnter2D(Collider2D other){
        
        GameObject ga = other.gameObject;
        if (tags.IndexOf(ga.tag)>-1) // devuelve el indie del elemento q estan en la lista
        {
            ga.SetActive(false);
        }
        //si no se activa el isTrigger es OnCollisionEnter2D
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
