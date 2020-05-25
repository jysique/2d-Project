using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    protected float elapsedShooter;
    protected float totalShooter;
    [SerializeField]
    protected List<GameObject> bullets;
    protected List<GameObject> poolBullets;
    [SerializeField]
    protected GameObject prefabProyectile;
    [SerializeField]
    protected Vector2 velocityBullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedShooter += Time.deltaTime;
        if (elapsedShooter >= totalShooter)
        {
            elapsedShooter = 0;
            generateBullet();
        }
    }

    virtual protected void generateBullet()
    {
        //print("Hola desde Shooter");
    }

    protected void CreateBullet(Vector3 origin_position, Vector2 velocity)
    {
        if (bullets.Count == 0)
        {
            GameObject go = Instantiate(prefabProyectile, origin_position, Quaternion.identity);
            go.GetComponent<Rigidbody2D>().velocity = velocity;
            bullets.Add(go);
            return;
        }
        int index = 0;
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Break();
            }
            index = Random.Range(0, bullets.Count - 1);
            if (!bullets[index].activeInHierarchy)
            {
                bullets[index].transform.position = origin_position;
                bullets[index].SetActive(true);
                bullets[index].GetComponent<Rigidbody2D>().velocity = velocity;
                break;
            }
            else
            {
                GameObject go = Instantiate(prefabProyectile, origin_position, Quaternion.identity);
                go.GetComponent<Rigidbody2D>().velocity = velocity;
                bullets.Add(go);
                break;
            }
        }
    }
}
