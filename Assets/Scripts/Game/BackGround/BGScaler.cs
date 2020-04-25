using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaler : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Vector3 tmp = transform.localScale;
        float  width = sr.sprite.bounds.size.x; //ANCHO

        float worldScreenHeight = Camera.main.orthographicSize*2f;
        float worldScreenWidth = worldScreenHeight /Screen.height * Screen.width;
        
        tmp.x = worldScreenWidth / width;
        transform.localScale = tmp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
