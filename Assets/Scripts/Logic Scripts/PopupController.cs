using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PopupController : MonoBehaviour
{
    public Text txtScore;
    public Button btnReturn;

    public Button btnExit;
    
    GameObject controller;

    private GameControllers gmController;
    private void Awake() { //paso 0
        controller = GameObject.Find("GameController");
        gmController = controller.GetComponent<GameControllers>(); //Sacando scripts
        
    }
    void Start() //paso 1
    {
        btnReturn.onClick.AddListener(()=>returnGame());
        btnExit.onClick.AddListener(()=>returnMenu());
        
    }

    private void OnEnable() { //entre paso 0 y 1
        //cuando paso de inactive a active
        txtScore.text = gmController.getScore();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void returnGame(){

        gmController.startGame();
    }
    void returnMenu()
    {
        Time.timeScale = 1f;
        btnReturn.onClick.RemoveAllListeners();
        btnExit.onClick.RemoveAllListeners();
        SceneManager.LoadScene("Menu");
    }
}
