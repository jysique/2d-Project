using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    Button btnGame;
    // Start is called before the first frame update
    void Start()
    {
        btnGame.onClick.AddListener(() => goGame());
    }

    void goGame()
    {
        btnGame.onClick.RemoveAllListeners();
        SceneManager.LoadScene("Game");
    }
}
