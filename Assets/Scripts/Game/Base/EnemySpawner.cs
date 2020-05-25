using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> enemiesToCreate;
    private List<GameObject> poolEnemies;

    public static EnemySpawner instance;
    private float elapsedGeneration = 0f;
    private float totalGeneration = 5f;

    private float minX, maxX;
    void Awake()
    {
        instance = this;
        poolEnemies = new List<GameObject>();
        SetMinAndMax();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    void SetMinAndMax()
    {
        Vector3 bounds =
             Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        minX = -bounds.x;
        maxX = bounds.x;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedGeneration += Time.deltaTime;
        if (elapsedGeneration >= totalGeneration)
        {
            elapsedGeneration = 0f;
            generateEnemy();
        }
    }

    void generateEnemy()
    {
        int index = 0;
        float posX = Random.Range(minX, maxX);
        Vector3 temp = transform.position;
        temp.x = posX;
        if (poolEnemies.Count == 0)
        {
            index = Random.Range(0, enemiesToCreate.Count - 1);
            GameObject ga = Instantiate(enemiesToCreate[index], temp, Quaternion.identity);
            poolEnemies.Add(ga);
        }
        else
        {
            while (true)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Debug.Break();
                }
                index = Random.Range(0, poolEnemies.Count - 1);
                if (!poolEnemies[index].activeInHierarchy)
                {
                    poolEnemies[index].transform.position = temp;
                    poolEnemies[index].SetActive(true);
                    break;
                }
                else
                {
                    index = Random.Range(0, enemiesToCreate.Count - 1);
                    GameObject ga = Instantiate(enemiesToCreate[index], temp, Quaternion.identity);
                    poolEnemies.Add(ga);
                    break;
                }
            }
        }
    }
}
