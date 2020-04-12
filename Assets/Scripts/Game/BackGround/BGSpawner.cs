using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSpawner : MonoBehaviour
{
    [SerializeField] 
    private GameObject[] backgrounds;
    private float lastY;


    // Start is called before the first frame update
    void Start()
    {
        GetBackgroundsAndSaveLastY();
    }
    void GetBackgroundsAndSaveLastY(){
        backgrounds = GameObject.FindGameObjectsWithTag("Background");
        lastY = backgrounds[0].transform.position.y;

        for (int i = 0; i < backgrounds.Length; i++)
        {
            if (lastY > backgrounds[i].transform.position.y)
            {
                lastY = backgrounds[i].transform.position.y;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Background")
        {
            if (other.gameObject.transform.position.y == lastY)
            {
                Vector3 temp = other.transform.position;
                BoxCollider2D col = (BoxCollider2D)other;
                float height = col.size.y;

                for (int i = 0; i < backgrounds.Length; i++)
                {
                    if (!backgrounds[i].activeInHierarchy)
                    {
                        temp.y -= height;
                        lastY = temp.y;
                        backgrounds[i].transform.position = temp;
                        backgrounds[i].SetActive(true);
                    }
                }
            }
        }
    }
}
