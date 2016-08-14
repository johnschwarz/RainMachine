using UnityEngine;
using System.Collections;

public class WeatherController : MonoBehaviour
{

    private static WeatherController Instance;
    public static WeatherController instance
    {
        get { return Instance; }
    }

    void Awake()
    {
        if (Instance != null && Instance != this)
        { Destroy(this.gameObject); return; }
        else
        {
            Instance = this;
        }
    }

    [SerializeField]
    GameObject cloudGO;




    void Update()
    {
        SpawnCloud();
    }

    float timeStamp;

    void Start()
    {
        timeStamp = Time.time + Random.Range(4, 7);

        for (int i = 0; i < 8; i++)
        {
            Instantiate(cloudGO, new Vector3(gameObject.transform.position.x + Random.Range(-1, 2f), gameObject.transform.position.y + Random.Range(1.2f, 2f), 0), Quaternion.identity);
        }
    }

    public void SpawnMultipleClouds(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Instantiate(cloudGO, new Vector3(gameObject.transform.position.x + Random.Range(2, 2.8f), gameObject.transform.position.y + Random.Range(1.2f, 2f), 0), Quaternion.identity);
        }
    }

    void SpawnCloud()
    {
        
        if (timeStamp <= Time.time)
        {
            timeStamp = Time.time + Random.Range(1, 3);
            Instantiate(cloudGO, new Vector3(gameObject.transform.position.x + 2.2f, gameObject.transform.position.y + Random.Range(1.2f, 2f), 0), Quaternion.identity);
            SpawnCloud();
        }

    }



}
