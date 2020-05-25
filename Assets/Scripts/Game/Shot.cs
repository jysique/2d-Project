using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    // Start is called before the first frame update
    protected float elapsedShooter;
    protected float totalShooter;
    [SerializeField] protected List<GameObject> bullets;
    [SerializeField] protected List<GameObject> poolBullets;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedShooter+=Time.deltaTime;
        if(elapsedShooter>= totalShooter){
            elapsedShooter = 0;
            generateBullet();
        }
    }
    virtual protected void generateBullet(){

    }
}
