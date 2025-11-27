using System.Threading;
using UnityEditor.ShaderGraph.Internal;
using UnityEditor.VersionControl;
using UnityEngine;

public class MiniFlight_shooting : MonoBehaviour
{
    [SerializeField] Transform mother;

    float moveSpeed = 4.5f;

    float itemTime = 10f;
    float elapsedTime = 0f;

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = mother.position + new Vector3(-1f, -0.5f, 0f);
        Vector3 dir = targetPos - transform.position;

        if (dir.magnitude > 0.01f) // 너무 가까우면 이동 중지
        {
            dir.Normalize();
            transform.position += dir * moveSpeed * Time.deltaTime;
        }

        if (gameObject.activeSelf)
            elapsedTime += Time.deltaTime;

        if (elapsedTime > itemTime)
        {
            gameObject.SetActive(false);
            elapsedTime = 0f;
        }
    }

}
