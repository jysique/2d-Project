using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    [Header("Button Variables")]
    public Button btnPlay;
    public Button btnAchivements;
    // Start is called before the first frame update
    void Start()
    {
        btnPlay.onClick.AddListener(()=>goGame());
        btnAchivements.onClick.AddListener(()=>goAchivements());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void goGame(){
        SceneManager.LoadScene("Game");
    }
    void goAchivements(){
        SceneManager.LoadScene("Menu");
    }
}
