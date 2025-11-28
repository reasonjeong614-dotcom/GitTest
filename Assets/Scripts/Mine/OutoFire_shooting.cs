using System.Threading;
using UnityEngine;

public class OutoFire_shooting : MonoBehaviour
{
    public GameObject bullets;        //총알 프리팹
    public Transform firePoint;       //발사 위치

    float fireTime = 1f;              // 발사 간격
    float elapsedTime = 0f;           // 누적 시간 (클래스 변수로 선언)

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= fireTime)
        {
            fire();
            elapsedTime = 0f;
        }
    }

    void fire()
    {
        Instantiate(bullets, firePoint.position, Quaternion.identity);
    }
}
