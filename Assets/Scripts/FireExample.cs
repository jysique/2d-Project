using Firebase.Database;
using UnityEngine;

public class FireExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FireDatabase.init();
        // User user = new User("Jose Ysique Neciosup", SystemInfo.deviceUniqueIdentifier, "etorkizun@gmail.com",10);
        // string json  = JsonUtility.ToJson(user); //convierto a json

        // FireDatabase.reference.Child("user").Child(user.id).SetRawJsonValueAsync(json); //.Child(nombre de la tabla).que_se_guardara

        FireDatabase.reference.Child("user").ChildAdded += HandleChildAdded;
        FireDatabase.reference.Child("user").ChildChanged += HandleChildChanged;
        FireDatabase.reference.Child("user").ChildRemoved += HandleChildRemoved;

    }
    void HandleChildRemoved(object sender, ChildChangedEventArgs args){
        if(args.DatabaseError != null){
            Debug.Log(args.DatabaseError.Message);
            return;
        }
        print("removed"+args.Snapshot);
    }
    void HandleChildChanged(object sender, ChildChangedEventArgs args){
        if(args.DatabaseError != null){
            Debug.Log(args.DatabaseError.Message);
            return;
        }
        print("changed"+args.Snapshot);
    }
    void HandleChildAdded(object sender, ChildChangedEventArgs args){
        if(args.DatabaseError != null){
            Debug.Log(args.DatabaseError.Message);
            return;
        }
        print("added"+ args.Snapshot);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
