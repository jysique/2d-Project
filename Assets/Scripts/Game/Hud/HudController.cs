using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HudController : MonoBehaviour
{
    // Start is called before the first frame update
    public static HudController instance;
    private int lifes;
    private int score;
    private float time;
    [SerializeField] private Text txtScore;
    [SerializeField] private Text txtTime;
    private void Awake() {
        instance =this;
        score= 0;
        lifes = GameObject.FindGameObjectsWithTag("Live").Length;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        updateTime();
    }
    public void updateScore(int _score){
        score += _score;
        txtScore.text = score.ToString();
    }

    public void reduceLife(){
        if(lifes>0){
            GameObject ga = GameObject.FindGameObjectWithTag("Live");
            ga.SetActive(false);
            lifes--;
        }
        if (lifes == 0)
        {
            print("me mori");
        }
    }

    private void updateTime(){
        txtTime.text = SetFormatToRoundTime(time);
    }
    string SetFormatToRoundTime(float currentRoundTime){
		int minutes = (int)currentRoundTime / 60;
		int seconds = (int)currentRoundTime % 60;
        string minutesString ="";
        string secondsString = "";
        string currentTimeString = "";
		if (minutes < 10) {
			minutesString = "0" + minutes.ToString ("0");
		} else {
			minutesString = minutes.ToString ("0");
		}
		if (seconds < 10) {
			secondsString = "0" + seconds.ToString ("0");
		} else {
			secondsString = seconds.ToString ("0");
		}
		currentTimeString = minutesString + ":" + secondsString;

		return currentTimeString;
	}
}
