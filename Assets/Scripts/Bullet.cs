using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;               // 초당 10유닛 이동
    public float destroyDistance = 20f;     // 발사 위치로부터 얼마나 떨어지면 삭제할지
    Vector3 startPosition;                  // 발사 시작 위치

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 발사 위치 저장
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // 총알 이동
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        //발사 위치로부터 일정 거리 이상 떨어지면 삭제
        /* 
        //1. 단순!
        if (startPosition.y > destroyDistance)
        {
            Destroy(gameObject);
        }
        */
        
        /* 
        //2. Vector3.Distance() 함수 사용 (성능에 약간 부담)
        float distance = Vector3.Distance(startPosition, transform.position);
        if (distance > destroyDistance)
        {
            Destroy(gameObject);
        }
        */

        //3. 제곱 거리 비교 sqrMagnitude (2보다 성능에 유리) @ 이걸 쓰자!! - 최적화
        float sqrDistance = (startPosition -  transform.position).sqrMagnitude;
        if (sqrDistance > destroyDistance * destroyDistance)
        {
            gameObject.SetActive(false);
        }




    }
}
