using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{

    // Start is called before the first frame update
    [SerializeField] private GameObject[] clouds;
    private float distanceBetweenClouds = 3f;
    private float minX, maxX;
    private float lastCloudPositionY;
    private int controlX;
    [SerializeField] private GameObject[] collectables;
    [SerializeField] private GameObject player;
    private void Start() {
        PositionPlayer();
    }    
    private void Awake() {
        controlX = 0;
        SetMinAndMax();
        CreateClouds();
        player = GameObject.Find("Player");
        for (int i = 0; i < collectables.Length; i++)
        {
            collectables[i].SetActive(false);
        }
    }
    void SetMinAndMax(){
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,0));
        minX = -bounds.x + 0.5f;
        minX = bounds.x + 0.5f;
    }
    void CreateClouds(){
        Shuffle(clouds);
        float positionY = 0;
        for (int i = 0; i < clouds.Length; i++)
        {
            Vector3 temp = clouds[i].transform.position;
            temp.y = positionY;
            if (controlX == 0)
            {
                temp.x = Random.Range(0,maxX);
                controlX = 1;
            }else if(controlX == 1)
            {
                temp.x = Random.Range(0,minX);
                controlX = 2;
            }else if (controlX == 2)
            {
                temp.x = Random.Range(1.0f,maxX);
                controlX = 3;
            }else if (controlX == 3)
            {
                temp.x = Random.Range(-1.0f,minX);
                controlX = 0;
            }
            lastCloudPositionY = positionY;
            clouds[i].transform.position = temp;
            positionY -= distanceBetweenClouds;
        }
    }
    void Shuffle(GameObject[] objects){
        for (int i = 0; i < objects.Length; i++)
        {
            GameObject temp = objects[i];
            int random = Random.Range(1,objects.Length);
            objects[i] = objects[random];
            objects[random] = temp;
        }
    }
    void PositionPlayer(){
        GameObject[] darkClouds = GameObject.FindGameObjectsWithTag("Deadly");
        GameObject[] cloudsInGame = GameObject.FindGameObjectsWithTag("Cloud");


        for (int i = 0; i < darkClouds.Length; i++)
        {
            if (darkClouds[i].transform.position.y == 0)
            {
                Vector3 temp = darkClouds[i].transform.position;
                darkClouds[i].transform.position = new Vector3(
                    cloudsInGame[0].transform.position.x,
                    cloudsInGame[0].transform.position.y,
                    cloudsInGame[0].transform.position.z
                );
                cloudsInGame[0].transform.position = temp;
            }
        }
        Vector3 t = cloudsInGame[0].transform.position;
        for (int i = 0; i < cloudsInGame.Length; i++)
        {
            if (t.y < cloudsInGame[i].transform.position.y)
            {
                t = cloudsInGame[i].transform.position;
            }
        }
        player.transform.position = new Vector3(t.x,t.y +0.8f,t.z);

    }
    private void OnTriggerEnter2D(Collider2D other) {
        GameObject go = other.gameObject;
        if (go.tag == "Deadly"|| go.tag == "Cloud")
        {
            if (go.transform.position.y == lastCloudPositionY)
            {
                Shuffle(clouds);
                Vector3 temp = go.transform.position;
                Shuffle(collectables);
                for (int i = 0; i < clouds.Length; i++)
                {
                    if (!clouds[i].activeInHierarchy)
                    {
                        switch (controlX)
                        {
                            case 0:
                                temp.x = Random.Range(0,maxX);
                                controlX = 1;
                            break;
                            case 1:
                                temp.x = Random.Range(0,minX);
                                controlX = 2;
                            break;
                            case 2:
                                temp.x = Random.Range(1.0f,maxX);
                                controlX = 3;
                            break;
                            case 3:
                                temp.x = Random.Range(-1.0f,minX);
                                controlX = 0;
                            break;
                        }
                        temp.y -= distanceBetweenClouds;
                        lastCloudPositionY = temp.y;
                        clouds[i].SetActive(true);
                        clouds[i].transform.position = temp;
                    }
                }
            }
        }
    }
}
