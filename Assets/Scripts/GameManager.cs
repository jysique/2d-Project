using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameObject player;

    [SerializeField] private GameObject platform;
    [SerializeField] private Button backbtn;
    private void Start() {
        backbtn.onClick.AddListener(()=>GoMenu());
    }
    private float minX  = -2.5f, maxX = 2.5f,minY = -1.5f,maxY = 1.5f;

    private bool lerpCamara;

    private float lerpTime = 1.5f;

    private float lerpX; 
    private void Update() {
            if (lerpCamara)
            {   
                LerpTheCamara();
            }
    }
    private void LerpTheCamara(){
        float x = Camera.main.transform.position.x;
        x = Mathf.Lerp(x,lerpX,lerpTime*Time.deltaTime);
        Camera.main.transform.position = new Vector3(x,Camera.main.transform.position.y,Camera.main.transform.position.z);
        if (Camera.main.transform.position.x >= (lerpX-0.07f) )
        {
            lerpCamara = false;
        }
    }
    public void CreateNewPlarformAndLerp(float lerpPosition){
        CreateNewPlatform();
        lerpX = lerpPosition + maxX;
        lerpCamara = true;
    }

    public void CreateNewPlatform(){
        float cameraX = Camera.main.transform.position.x;
        float newMaxX = (maxX*2) + cameraX;
        Instantiate (platform, 
                new Vector3(Random.Range(newMaxX,newMaxX-1.2f),
                            Random.Range(maxY,maxY-1.2f),0), Quaternion.identity);
    }
    private void Awake() {
        MakeInstance();
        CreateInitialPlarform();
    }
    private void GoMenu(){
        SceneManager.LoadScene("Menu");
    }
    void MakeInstance(){
        if (instance == null)
        {
            instance = this;
        }
    }
    void CreateInitialPlarform(){
		Vector3 temp = new Vector3 (Random.Range(minX, minX + 1.2f), Random.Range(minY, maxY), 0);
		Instantiate (platform, temp, Quaternion.identity);
		temp.y += 2f;
		Instantiate (player, temp, Quaternion.identity);
		temp = new Vector3 (Random.Range(maxX, maxX - 1.2f), Random.Range(minY, maxY), 0);
		Instantiate (platform, temp, Quaternion.identity);
    }
}
