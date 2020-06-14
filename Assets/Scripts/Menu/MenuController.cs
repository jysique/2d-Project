using System.Collections;
using System.Collections.Generic;
using Firebase.Database;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject ListUsersPanel;
    [SerializeField] Button ListUsersbtn = null;
    [SerializeField] Button Loginbtn = null;
    [SerializeField] Button Playbtn = null;
    [SerializeField] Button Backbtn = null;
    [SerializeField] InputField NameInput;

    [SerializeField] GameObject item;
    [SerializeField] GameObject listUsers;
    private Transform list_transform;

    void Start()
    {
        FireDatabase.init();
        ListUsersPanel.SetActive(false);
        Loginbtn.onClick.AddListener(()=>AddUser());
        ListUsersbtn.onClick.AddListener(()=>GoListUserPanel());
        Backbtn.onClick.AddListener(()=>GoMenu());
        Playbtn.onClick.AddListener(()=>GoGame());
        list_transform = listUsers.GetComponent<Transform>();
    }
    private void Update() {
        
    }
    void GoListUserPanel(){
        ListUsersPanel.SetActive(true);
        GetUser();
    }
    void GoGame(){
        SceneManager.LoadScene("Game");

    }
    void GoMenu(){
        ListUsersPanel.SetActive(false);
    }
    void AddUser(){
        if (NameInput.text.Length >= 3)
        {
            int r = Random.Range(0,100);
            User user = new User(NameInput.text, SystemInfo.deviceUniqueIdentifier, "joseysique@gmail.com",r);
            string json  = JsonUtility.ToJson(user); //convierto a json
            FireDatabase.reference.Child("user").Child(user.id).SetRawJsonValueAsync(json);
        }
    }

    void GetUser(){
        FirebaseDatabase.DefaultInstance.GetReference("user").OrderByChild("score")
        .ValueChanged +=(object sender, ValueChangedEventArgs e)=>{
            if (e.DatabaseError != null)
            {
                Debug.LogError(e.DatabaseError.Message);
                return;
            }
            
            Debug.Log("Actualizacion de items");
            if (e.Snapshot != null && e.Snapshot.ChildrenCount > 0)
            {
                foreach (Transform child in listUsers.transform)
                {
                    Destroy(child.gameObject);
                }    
            }
            int index = 0;
            foreach (var childSnapshot in e.Snapshot.Children){
                index++;                
                string username = childSnapshot.Child("username").Value.ToString();
                string email = childSnapshot.Child("email").Value.ToString();
                string score = childSnapshot.Child("score").Value.ToString();
                GameObject temp = GameObject.Instantiate(item.gameObject,listUsers.transform);
                temp.transform.Find("id").GetComponent<Text>().text = index.ToString();
                temp.transform.Find("username").GetComponent<Text>().text = username;
                temp.transform.Find("email").GetComponent<Text>().text = email;
                temp.transform.Find("score").GetComponent<Text>().text = score;
            }

        };
    }

}




