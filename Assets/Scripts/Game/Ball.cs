using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private int touchedFloor = 0;

    private bool touchedRam ;
    private bool touchProtector = false;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "net"){
            if (!touchProtector){
                print("encesto");
                if(touchedRam){
                    GameController.instance.incrementBalls(1);
                }else{
                    //ganas 2
                    GameController.instance.incrementBalls(2);
            }
            GameController.instance.playSound(1);
            }

        }
        if (other.gameObject.tag == "protector")
        {
            touchProtector = true;
        }
    }
    // private void OnBecameInvisible() {
    //     Destroy(gameObject);
    //     GameController.instance.checkeGameOver();
    // }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "holder")
        {
            if (Random.Range(0,2)>1)
            {
                GameController.instance.playSound(3);
            }else{
                GameController.instance.playSound(4);
            }
        }
        if (other.gameObject.tag == "ram")
        {
            if (Random.Range(0,2)>1)
            {
                GameController.instance.playSound(2);
            }else{
                GameController.instance.playSound(5);
            }
        }
        if (other.gameObject.tag == "ground")
        {
            touchedFloor++;
            if (touchedFloor<=3)
            {
                if (Random.Range(0,2)>1)
                {
                    GameController.instance.playSound(3);
                }else{
                GameController.instance.playSound(4);
                }   
            }
        }
        if(other.gameObject.tag == "table"){
            touchedRam = true;
            if(Random.Range(0,2)>1){
                GameController.instance.playSound(2);
            }else{
                GameController.instance.playSound(5);
            }
        }
    }
}
