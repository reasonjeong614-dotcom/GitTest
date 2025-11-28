using UnityEngine;



public class Boss_shooting : MonoBehaviour
{
    [SerializeField] GameObject bulletFactory;   //총알 프리팹
    [SerializeField] Transform target;           //플레이어 위치

    float fireTime = 1.0f;    //총알 발사 시간 간격
    float timer = 0;        //타이머
    int bulletMax = 10;

    // Update is called once per frame
    void Update()
    {
        AutoFire();
    }

    void AutoFire()
    {
        //타겟이 있을 때 총알 발사
        if (target != null)
        {
            timer += Time.deltaTime;
            if (timer >= fireTime)
            {
                GameObject bullet = Instantiate(bulletFactory);
                bullet.transform.position = transform.position;
                Vector3 dir = target.position - transform.position;
                dir.Normalize();

                bullet.transform.up = dir;

                timer = 0;
            }
        }
    }
}
