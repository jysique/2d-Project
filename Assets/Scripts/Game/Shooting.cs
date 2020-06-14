using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Shooting : MonoBehaviour
{
    public float power = 2.0f;
    public float life = 1.0f;
    public float dead_sense = 25f;
    public int dots = 30;
    private Vector2 startPosition;
    private bool shoot = false, aiming = false, hit_ground = false;
    private GameObject Dots;
    private List<GameObject> projectilePath;
    private Rigidbody2D body;
    private Collider2D collider;
    
    private void Awake() {
        body = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();

    }
    // Start is called before the first frame update
    void Start()
    {
        Dots = GameObject.Find("Dots");
        body.isKinematic = true;
        collider.enabled = false;
        startPosition = transform.position;
        projectilePath = Dots.transform.Cast<Transform>().ToList().ConvertAll(t=>t.gameObject);
        // print(projectilePath.Count);

        for (int i = 0; i < projectilePath.Count; i++)
        {
            projectilePath[i].GetComponent<Renderer>().enabled = false;
        }
        // ShowPath(false);
    }

    // Update is called once per frame
    void Update()
    {
        Aim();


        if (hit_ground)
        {
            life -= Time.deltaTime;
            Color c = GetComponent<Renderer>().material.GetColor("_Color");
            GetComponent<Renderer>().material.SetColor("_Color",new Color(c.r,c.g,c.b,life));
            // print(life);
            if (life <= 0)
            {
                gameObject.SetActive(false);
                GameController.instance.checkeGameOver();
                // print("hola");
                // Destroy(gameObject);
                
            }
        }
    }
    void Aim(){
	    if (shoot)
			return;
		if (Input.GetAxis ("Fire1") == 1) {
			if (!aiming) {
				aiming = true;
				startPosition = Input.mousePosition;
				CalculatePath ();
				ShowPath (true);
			} else {
				CalculatePath ();
			}
		} else if (aiming && !shoot) {
			if(inDeadZone(Input.mousePosition) || inReleaseZone(Input.mousePosition)) {
				aiming = false;
				ShowPath(false);
				return;
			}
			body.isKinematic = false;
			collider.enabled = true;
			shoot = true;
			aiming = false;
			body.AddForce(GetForce(Input.mousePosition));
            GameController.instance.decrementBalls();
			ShowPath(false);
		}
    }
    Vector2 GetForce(Vector3 mouse) {
		return (new Vector2(startPosition.x, startPosition.y) - new Vector2(mouse.x, mouse.y)) * power;
	}

	bool inDeadZone(Vector2 mouse) {
		return (Mathf.Abs (startPosition.x - mouse.x) <= dead_sense && Mathf.Abs (startPosition.y - mouse.y) <= dead_sense);
	}

    bool inReleaseZone(Vector3 mouseP){
        return mouseP.x < 70;
    }
 	void CalculatePath() {
		Vector2 vel = GetForce (Input.mousePosition) * Time.fixedDeltaTime / body.mass;
		for(int i = 0; i < projectilePath.Count; i++) {
			projectilePath[i].GetComponent<Renderer>().enabled = true;
			float t = i / 30f;
			Vector3 point = PathPoint(transform.position, vel, t);
			point.z = 1.0f;
			projectilePath[i].transform.position = point;
		}

	}
	Vector2 PathPoint(Vector2 startP, Vector2 startVel, float t) {
		return startP + startVel * t + 0.5f * Physics2D.gravity * t * t;
	}
    void ShowPath(bool _hide){
        for (int i = 0; i < projectilePath.Count; i++)
        {
            projectilePath[i].GetComponent<Renderer>().enabled = _hide;
        }
    }
    void OnCollisionEnter2D(Collision2D target) {
		if (target.gameObject.tag == "ground") {
			hit_ground = true;
		}
	}
    
}
