using UnityEngine;

public class ItemSpawner_shooting : MonoBehaviour
{
    public GameObject Items;        //아이템 프리팹
    public Vector3 spawnPoint;       //스폰 위치

    float spawnTime = 5f;              // 발생 간격
    float elapsedTime = 0f;           // 누적 시간

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= spawnTime)
        {
            Item();
            elapsedTime = 0f;
        }
    }

    void Item()
    {
        Vector3 spawnPoint = new Vector3(Random.Range(-6f, 6f), 6, 3.34f); 
        Instantiate(Items, spawnPoint, Quaternion.identity);
    }
}
