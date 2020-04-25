using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float speed = 1.0f;
    private float acceleration = 0.2f;
    private float maxSpeed = 3f;

    [HideInInspector]
    public bool canMoveCamera;
    private float easySpeed = 3.2f;
    private float mediumSpeed = 3.7f;
    private float hardSpeed = 4.2f;   
    // Start is called before the first frame update
    void Start()
    {
        int level = PlayerPrefs.GetInt("level",0);
        switch (level)
        {
            case 0:
                maxSpeed = easySpeed;
                break;
            case 1:
                maxSpeed = mediumSpeed;
                break;
            case 2:
                maxSpeed = hardSpeed;
            break;
        }
        canMoveCamera = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMoveCamera)
        {
            moveCamera();
        }
    }
    void moveCamera(){
        Vector3 temp = transform.position;
        float oldY = temp.y;
        float newY = temp.y - (speed*Time.deltaTime);
        temp.y = Mathf.Clamp(temp.y,oldY,newY);
        transform.position = temp;
        speed+= acceleration * Time.deltaTime;
        if(speed> maxSpeed){
            speed = maxSpeed;
        }
    }
}
