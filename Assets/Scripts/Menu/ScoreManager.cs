using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private Text txtScore;

    // Start is called before the first frame update
    public static ScoreManager instance;
    private int score;

    private void Awake() {
        if(instance == null){
            instance =this;
        }
    }
    public void scoreUpdate(int _score){
        score += _score;
        txtScore.text = score.ToString();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
