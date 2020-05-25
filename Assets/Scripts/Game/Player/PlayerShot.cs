using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : Shot
{
    // Start is called before the first frame update
    void Start()
    {
        totalShooter =0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    override protected void generateBullet(){
        if (Input.GetKey(KeyCode.Space))
        {
            print("disparando bala");
        }
    }
}
