using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerJump : MonoBehaviour
{
    public static PlayerJump instance;

    private Rigidbody2D body;
    private Animator animator;
    [SerializeField] private float forceX, forceY ;
    private float treesHoldX = 7f;
    private float treesHoldY = 14f;
    private bool setPower,didJump;
    private float  maxforceX = 6.5f;
    private float  maxforceY = 13.5f;
    private Slider powerBar;
    private float powerBarTreshold = 10f;
    private float powerBarValue = 0f;


    private void Awake() {
        MakeInstance();
        Init();
    }
    
    void Update()
    {
        SetPower();
    }

    void MakeInstance(){
        if (instance == null)
        {
            instance = this;
        }
    }
    void Init(){
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        powerBar = GameObject.Find("PowerBar").GetComponent<Slider>();
        powerBar.minValue = powerBarValue;
        powerBar.maxValue = powerBarTreshold;
        powerBar.value = powerBarValue;
    }
    void SetPower(){
        if (setPower)
        {
            forceX += treesHoldX * Time.deltaTime;
            forceY += treesHoldY * Time.deltaTime;
            if (forceX > maxforceX)
            {
                forceX = maxforceX;
            }
            if (forceY > maxforceY)
            {
                forceY = maxforceY;
            }
            powerBarValue+= powerBarTreshold*Time.deltaTime;
            powerBar.value = powerBarValue;
        }
    }
    public void GivePower(bool power){
        setPower  = power;
        if (!setPower)
        {
            Jump();
        }
    }

    void Jump(){
        body.velocity  = new Vector2(forceX,forceY);
        forceX  = forceY = 0;
        didJump = true;
        animator.SetBool("jump",true);
        powerBarValue = 0;
        powerBar.value = powerBarValue;
        //reduce power bar
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (didJump)
        {
            didJump = false;
            animator.SetBool("jump",false);
            if (other.gameObject.tag == "Platform")
            {
                GameManager.instance.CreateNewPlarformAndLerp(other.transform.position.x);
                ScoreManager.instance.scoreUpdate(10);
            }
            if (other.gameObject.tag == "Dead")
            {
                GameOverManager.instance.showPanel();
            }
        }
    }
}
