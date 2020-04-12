using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonLevel : MonoBehaviour
{
    [SerializeField]
    private GameObject check;
    Button button;
    public int level;

    private string key = "level";

    [SerializeField]
    private OptionsController controller;

    // Start is called before the first frame update
    void Start()
    {

        button = GetComponent<Button>();
        
        button.onClick.AddListener(()=>changeOptions());
        check.SetActive(false);

        if (PlayerPrefs.HasKey(key))
        {
            int _level = PlayerPrefs.GetInt(key,0);
            if (_level== level)
            {
                check.SetActive(true);
            }else{
                if (level == 0)
                {
                    check.SetActive(true);
                }
            }
        }
    }

    void changeOptions(){
        if (!check.activeInHierarchy)
        {
            controller.resetButtons();
            PlayerPrefs.SetInt("level",level);//diccionario
            check.SetActive(true);
            //check.SetActive(!check.activeInHierarchy);    
        }
    }
    public void resetButton(){
        check.SetActive(false);
    }
}
