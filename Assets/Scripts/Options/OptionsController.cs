using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsController : MonoBehaviour
{
    [SerializeField]
    private List<ButtonLevel> buttons;

    [SerializeField]
    private Button btnBack;

    // Start is called before the first frame update
    void Start()
    {
        btnBack.onClick.AddListener(()=>goBack());
    }

    void goBack(){
        SceneManager.LoadScene(0);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void resetButtons(){
        for(int i=0; i<buttons.Count;i++){
            buttons[i].resetButton();
        }
    }
    
}
