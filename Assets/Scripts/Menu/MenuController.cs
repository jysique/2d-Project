using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject mainBallsPanel;
[SerializeField]
    private GameObject mainButtonsPanel;
    private Animator mainBallsPanelAnimator;
    private Animator mainButtonsPanelAnimator;

    [SerializeField]
    private Button btnPlay;

    [SerializeField]
    private Button btnBalls;
        [SerializeField]
    private Button btnBack;
    // Start is called before the first frame update
    void Start()
    {
        mainBallsPanelAnimator = mainBallsPanel.GetComponent<Animator>();
        mainButtonsPanelAnimator = mainButtonsPanel.GetComponent<Animator>();
        btnPlay.onClick.AddListener(()=>goPlay());
        btnBalls.onClick.AddListener(()=>goBalls());

        mainBallsPanel.SetActive(false);
        btnBack.onClick.AddListener(()=>goMenu());
    }

    void goBalls(){
        mainBallsPanel.SetActive(true);
        mainBallsPanelAnimator.Play("fadein");
        mainButtonsPanelAnimator.Play("fadeout");
    }
    void goPlay(){
        SceneManager.LoadScene("Game");
    }
    void goMenu(){
        mainBallsPanelAnimator.Play("fadeout");
        mainButtonsPanelAnimator.Play("fadein");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
