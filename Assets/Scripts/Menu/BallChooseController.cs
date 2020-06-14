using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BallChooseController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] btn = GameObject.FindGameObjectsWithTag("ball");
        Button ballBtn;
        foreach (GameObject item in btn)
        {
            ballBtn = item.GetComponent<Button>();
            ballBtn.onClick.AddListener(()=>chooseBall());
        }
    }

    void chooseBall(){
        int index = int.Parse(UnityEngine.EventSystems.EventSystem.current.name);
        PlayerPrefs.SetInt("ball",index);
    }
}
