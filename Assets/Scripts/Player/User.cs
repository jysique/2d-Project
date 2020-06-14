[System.Serializable]
public class User
{
    public string username;
    public string id;
    public string email;
    public int score;
    public User(string _username, string _id, string _email,int _score){
        this.username = _username;
        this.id= _id;
        this.email = _email;
        this.score = _score;
    }
}
