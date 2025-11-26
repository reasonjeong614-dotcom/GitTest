using UnityEngine;

public class Move : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        
    }

    void Move1()
    {

    }

    void MoveInScreen()
    {
        //움직이는 영역 제한
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, -10f, 10f);
        position.y = Mathf.Clamp(position.y, 0.5f, 10f);
    }

}
