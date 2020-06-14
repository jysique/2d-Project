using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Button btnQuit;
    [SerializeField]
    private Button btnRestart;
    [SerializeField]
    private GameObject panel;

    public static GameOverManager instance;
    private Animator animation;
    private void Awake() {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        panel.SetActive(false);
        animation = panel.GetComponent<Animator>();
        btnQuit.onClick.AddListener(()=>GoMenu());
        btnRestart.onClick.AddListener(()=>GoRestart());
        
        animation.enabled = false;
    }
    public void showPanel(){
        panel.SetActive(true);
        animation.enabled = true;
        animation.Play("Gaveover");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void GoMenu(){
        SceneManager.LoadScene("Menu");
    }
    private void GoRestart(){
        SceneManager.LoadScene("Game");
    }
}
