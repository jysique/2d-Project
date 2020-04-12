using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public Button btnStart;
    public Button btnOptions;
    public Button btnHighScore;
    public Button btnQuit;
    public Button btnOn;
    public Button btnOff;

    void Start()
    {
        btnOff.gameObject.SetActive(false);

        btnStart.onClick.AddListener(()=>goGame());
        btnHighScore.onClick.AddListener(()=>ShowHighScore());
        btnOptions.onClick.AddListener(()=>ShowOptions());
        btnQuit.onClick.AddListener(()=>Quit());
        btnOn.onClick.AddListener(()=>onSound());
        btnOff.onClick.AddListener(()=>offSound());
    }
    public void goGame(){
        SceneManager.LoadScene("Game");
    }
    public void ShowHighScore(){
        SceneManager.LoadScene("HighScore");
    }
    public void ShowOptions(){
        SceneManager.LoadScene("Options");
    }
    public void StartGame(){
        SceneManager.LoadScene("Game");
    }
    public void Quit(){

    }
    void onSound(){
        btnOn.gameObject.SetActive(false);
        btnOff.gameObject.SetActive(true);
    }
    void offSound(){
        btnOn.gameObject.SetActive(true);
        btnOff.gameObject.SetActive(false);
    }
    void Update()
    {
        
    }
}
