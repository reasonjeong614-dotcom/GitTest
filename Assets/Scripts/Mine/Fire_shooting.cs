using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 총알 발사!
/// + 총알 발사 최적화를 위한 오브젝트 풀링
/// </summary>

public class Fire_shooting : MonoBehaviour
{
    [SerializeField] GameObject bullets;     //총알 프리팹
    [SerializeField] Transform firePoint;    //발사 위치

    //오브젝트 풀링 = 꽥꽥 @ 최적화
    int poolSize = 10;              //최대 총알 개수
    //큐로 만들어야 가장 성능이 좋다.
    List<GameObject> bulletPool;        //총알 풀 배열


    void Start()
    {
        InitObjectPooling();
    }

    //오브젝트 풀링 초기화
    void InitObjectPooling()
    {
        /*
        // 1. 배열로 오브젝트 풀링 초기화
        bulletPool = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bullets, firePoint.position, Quaternion.identity);
            bulletPool[i] = bullet;
        }
        */

        bulletPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bullets);
            bullet.SetActive(false);
            bulletPool.Add(bullet);
        }
    }

    // Update is called once per frame
    void Update()
    {
        FireBullet();
    }

    void FireBullet()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            /*1.
            //총알 게임 오브젝트 생성
            GameObject bullet = Instantiate(bullets);
            //총알 위치 설정
            bullet.transform.position = firePoint.position;
            //총알 회전 설정
            bullet.transform.rotation = firePoint.rotation;
            */

            //2. 위치와 회전을 한 번에 지정해서 생성
            //GameObject bullet = Instantiate(bullets, firePoint.position, Quaternion.identity); // 회전 값 0

            // 리스트로 오브젝트 풀링
            if (bulletPool.Count > 0)
            {
                //리스트에서 첫번째 오브젝트 가져오기
                GameObject bullet = bulletPool[0];

                //오브젝트 활성화
                bullet.SetActive(true);
                bullet.transform.position = firePoint.position;
                bullet.transform.up = firePoint.up;

                //오브젝트 풀에서 빼
                bulletPool.Remove(bullet);
            }
            else //오브젝트 풀이 비었다.
            {
                GameObject bullet = Instantiate(bullets);
                bullet.SetActive(false);
                bulletPool.Add (bullet);
            }

        }
    }

}
