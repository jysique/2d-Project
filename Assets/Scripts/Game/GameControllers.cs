using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameControllers : MonoBehaviour
{
    float timeElapse =0f;
    // Start is called before the first frame update
    [Header("Obstacle Prefabs")]
    public List<GameObject> elements = new List<GameObject>();
    public float movementInst= 10.0f;
    public float startX;

    [Header("HUD Buttons")]
    public Button btnStart;
    public Button btnPause;

    void Start()
    {
        btnStart.gameObject.SetActive(false);
        btnStart.onClick.AddListener(()=>startGame());
        btnPause.onClick.AddListener(()=>pauseGame());
        generatePoolObjects();
    }

    void startGame(){
        Time.timeScale = 1f;
        btnStart.gameObject.SetActive(false);
        btnPause.gameObject.SetActive(true);
        print("Start");
    }

    void pauseGame(){
        Time.timeScale = 0f;
        btnStart.gameObject.SetActive(true);
        btnPause.gameObject.SetActive(false);
        print("Pause");
    }
   //Pool de objetos 
    void generatePoolObjects(){
        for (int i = 0; i < elements.Count; i++)
        {
            for (int j = 0; j < elements.Count; j++)
            {
                GameObject ga =Instantiate(elements[i],new Vector3(startX,0.0f,-3.0f),Quaternion.identity);
                ga.transform.localScale = new Vector3(0.5f,0.5f,1);
                ga.SetActive(false);
            }
        }
    }

    void GetFirstDead(){
        GameObject first = GameObject.FindGameObjectWithTag("Enemy");   
        print(first);
    }

    // Update is called once per frame
    void Update()
    {
        timeElapse +=  Time.deltaTime;
        if (timeElapse > 2)
        {
            GetFirstDead();
            /*
            GameObject ga =Instantiate(goNext(),new Vector3(startX,0.0f,-3.0f),Quaternion.identity);
            ga.transform.localScale = new Vector3(0.5f,0.5f,1);
            print("Se crea enemigo");
            timeElapse = 0;
            */
        }
    }

    public GameObject goNext(){
        int rnd = Random.Range(0, elements.Count-1);
        return elements[rnd];
    }
}
