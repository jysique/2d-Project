using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : Shooter
{
    void Start()
    {
        totalShooter = 0.2f;
        poolBullets = new List<GameObject>();
    }
    override protected void generateBullet()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //print("Disparando la bala");
            //Implementar la bala que cuando llegue al collider de arriba se reutiliza en el pool
            Vector3 temp = transform.position;
            //RectTransform rt = (RectTransform)gameObject.transform as RectTransform;
            //float height = rt.rect.width;
            float height = gameObject.GetComponent<BoxCollider2D>().bounds.size.y * 0.75f;
            temp.y += height;
            SoundController.instance.PlaySound(SoundController.Sounds.PLAYER_FIRE);
            CreateBullet(temp, velocityBullet);
        }
    }
}
