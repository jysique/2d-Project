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
    private float generationTime = 4f;
    private float scoreTime= 0f ;

    [Header("HUD")]
    public Button btnStart;
    public Button btnPause;

    [Header("HUD Text")]
    public Text txtScore;
    public  List<GameObject> pool = new List<GameObject>();

    public GameObject popupPause;
    
    void Start()
    {
        popupPause.SetActive(false);
        btnStart.gameObject.SetActive(false);
        btnStart.onClick.AddListener(()=>startGame());
        btnPause.onClick.AddListener(()=>pauseGame());
        generatePoolObjects();
        //shuffle();
    }
    
    public void startGame(){
        Time.timeScale = 1f;
        btnStart.gameObject.SetActive(false);
        btnPause.gameObject.SetActive(true);
        popupPause.SetActive(false);
        print("Start");
    }

    void pauseGame(){
        popupPause.SetActive(true);
        Time.timeScale = 0f;
        btnStart.gameObject.SetActive(true);
        btnPause.gameObject.SetActive(false);
        print("Pause");
    }
   //Pool de objetos 
    void generatePoolObjects(){
        int scale = 1;
        for (int i = 0; i < elements.Count; i++)
        {
            for (int j = 0; j < elements.Count; j++)
            {
                GameObject ga =Instantiate(elements[i],new Vector3(startX,0.0f,-3.0f),Quaternion.identity);
                scale = ga.tag == "Enemy"? 1: -1;
                ga.transform.localScale = new Vector3(0.5f*scale,0.5f,1);
                ga.SetActive(false);
                pool.Add(ga);
            }
        }
    }

    void GetFirstDead(){
        
        //print("getFirstDead");
        while(true){
            int index  = Random.Range(0,pool.Count);
            if(!pool[index].activeInHierarchy){
                print("become active");
                pool[index].SetActive(true);
                pool[index].transform.position = new Vector3(transform.position.x, transform.position.y,0);
                break;
            }else{
                index  = Random.Range(0,pool.Count);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        scoreTime += Time.deltaTime;
        txtScore.text = "SCORE: " + scoreTime.ToString("0");

        timeElapse +=  Time.deltaTime;
        if (timeElapse >generationTime)
        {
            timeElapse = 0;
            GetFirstDead();
            /*
            GameObject ga =Instantiate(goNext(),new Vector3(startX,0.0f,-3.0f),Quaternion.identity);
            ga.transform.localScale = new Vector3(0.5f,0.5f,1);
            print("Se crea enemigo");
            */

            
        }
    }

    public GameObject goNext(){
        int rnd = Random.Range(0, elements.Count-1);
        return elements[rnd];
    }

    public string getScore(){
        return scoreTime.ToString("0");

    }
}
