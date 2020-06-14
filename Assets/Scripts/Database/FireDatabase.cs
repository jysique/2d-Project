using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;


public class FireDatabase
{
    private static string url = "https://desarrollojuegos1.firebaseio.com/";
    public static DatabaseReference reference;

    public static void init(){
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(url);
        reference = FirebaseDatabase.DefaultInstance.RootReference;// redirige al nodo principal
        
    }
}
