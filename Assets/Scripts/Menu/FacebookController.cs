using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using UnityEngine.UI;
public class FacebookController : MonoBehaviour
{
    //EAAHhpwNJpQsBABhnfVIGonVOi3ALt6FSEu3O8MnA70pJTOZCZBbcz0Vp9FK552NnFbgoOUaxcG25m1IRS66D635JQYkwkkpLVOZCDIbUowKicNZBuKz7MYvW4tZBpgVZC354TMAOEEhZBGj52EsHsnXyrCgINIM8HNOv5IzZAek9IAZDZD
    [SerializeField] private Button loginButton;
    [SerializeField] private Image loginimage;

    [SerializeField] private Text loginName;
    [SerializeField] private Text loginLastName;
    // Start is called before the first frame update

    private void Awake() {
        if (!FB.IsInitialized)
        {
            FB.Init(InitCallBack,OnHideUnity);
        }else{
            FB.ActivateApp();
        }
    }

    void InitCallBack(){
        if (FB.IsInitialized)
        {
            FB.ActivateApp();
        }else{
            print("Ocurrio un error");
        }
    }
    void OnHideUnity(bool isGameShow){
        if (isGameShow)
        {
            Time.timeScale = 0f;
        }else{
            Time.timeScale = 1f;
        }
    }
    void Start()
    {
        loginButton.onClick.AddListener(()=>LoginFacebook());
    }
    void LoginFacebook(){
        List<string> permissions = new List<string>(){"public_profile","email"};
        FB.LogInWithReadPermissions(permissions,ResponseCallBack);
    }
    void ResponseCallBack(ILoginResult result){
        if (FB.IsLoggedIn)
        {
            AccessToken aToken = Facebook.Unity.AccessToken.CurrentAccessToken; //ID unico dentro de la aplicacion
            print(aToken.UserId);
            GetUserData();
        }else{
            print("El usuario no acepto el login");
        }
    }
    void GetUserData(){
        FB.API("me?fields=first_name,last_name,id,email",
            Facebook.Unity.HttpMethod.GET,ResultUserData);
    }
    void ResultUserData(IGraphResult result){
        if (result.ResultDictionary!=null)
        {
            foreach (string key in result.ResultDictionary.Keys)
            {
                print(key + " : " + result.ResultDictionary[key].ToString());
                loginName.text = result.ResultDictionary["first_name"].ToString();
                loginLastName.text = result.ResultDictionary["last_name"].ToString();
            }
            FB.API("me/picture?types=square&height=128&width=128",HttpMethod.GET,ResultPicture);
        }
    }

    void ResultPicture(IGraphResult result){

        loginimage.sprite = Sprite.Create(result.Texture,new Rect(0, 0, 130, 130), new Vector2(0.5f, 0.5f));
        print(result.Texture);
    }
}
