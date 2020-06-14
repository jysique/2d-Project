using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> ballList;

    private float minX = -2.7f, maxX = 7f, minY = -2.5f, maxY = 1.5f;
    private AudioSource audio;
    [SerializeField]
    private AudioClip rim_hit1,rim_hit2,bounce1,bounce2,net_sound;
    private int index = 0;
    private int total_balls = 10;
    private float volume = 1f;
    public static GameController instance;
[SerializeField] Text txtballs;
    private void Awake() {
        if (instance == null)
        {
            instance = this;
        }
    }

    void setInitialBalls(){
        txtballs.text = "Balls " + total_balls.ToString();
    }
    public void incrementBalls(int increment){
        total_balls += increment;
        if (total_balls > 10)
        {
            total_balls = 10;
        }
        txtballs.text = "Balls "  +total_balls.ToString();
    }
    public void checkeGameOver(){
        if (total_balls<= 0)
        {
                //escena gameover;
            print("Gameover");
        }else{
            createBalls();
        }
    }
    public void decrementBalls(){
        total_balls--;
        txtballs.text = "Balls "  + total_balls.ToString();
        
    }
    public void playSound(int id){
        switch (id)
        {
            case 1:
                audio.PlayOneShot(net_sound,volume);
            break;
            case 2:
                if (Random.Range(0,2)>1)
                {
                    audio.PlayOneShot(rim_hit1,volume);
                }else{
                    audio.PlayOneShot(rim_hit2,volume);
                }
            break;
            case 3:
                if (Random.Range(0,2)>1)
                {
                    audio.PlayOneShot(bounce1,volume);
                }else{
                    audio.PlayOneShot(bounce2,volume);
                }
            break;
            case 4:
                if (Random.Range(0,2)>1)
                {
                    audio.PlayOneShot(bounce1,volume * 0.5f);
                }else{
                    audio.PlayOneShot(bounce2,volume * 0.5f);
                }
            break;
            case 5:
                if (Random.Range(0,2)>1)
                {
                    audio.PlayOneShot(rim_hit1,volume * 0.5f);
                }else{
                    audio.PlayOneShot(rim_hit2,volume * 0.5f);
                }
            break;
        }
    }
    void Start()
    {
        createBalls();
        setInitialBalls();
        audio = GetComponent<AudioSource>();
        
    }
    private void createBalls(){
        int index = PlayerPrefs.GetInt("ball",0);
        Instantiate(ballList[index],new Vector3(Random.Range(minX,maxX),Random.Range(minY,maxY),0),Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
