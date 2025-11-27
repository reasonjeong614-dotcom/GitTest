using UnityEngine;

public class Item_shooting : MonoBehaviour
{
    public float speed = 5f;               
    public float destroyDistance = 20f;

    Vector3 startPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        float sqrDistance = (startPosition - transform.position).sqrMagnitude;
        if (sqrDistance > destroyDistance * destroyDistance)
        {
            Destroy(gameObject);
        }
    }
}
