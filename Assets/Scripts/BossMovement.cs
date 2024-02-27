using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public Vector2 areaCenter = new Vector2(0f, 0f);
    public Vector2 areaSize = new Vector2(10f, 10f);
    public float speed = 5f;
    public float pauseTime = 1f;

    private Vector2 currentTarget;

    void Start()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        currentTarget = GetRandomTargetPosition();
        StartCoroutine(MoveToTarget(currentTarget));
    }

    Vector2 GetRandomTargetPosition()
    {
        float randomX = Random.Range(areaCenter.x - areaSize.x / 2, areaCenter.x + areaSize.x / 2);
        float randomY = Random.Range(areaCenter.y - areaSize.y / 2, areaCenter.y + areaSize.y / 2);
        return new Vector2(randomX, randomY);
    }

    IEnumerator MoveToTarget(Vector2 target)
    {
        while (Vector2.Distance(new Vector2(transform.position.x, transform.position.y), target) > 0.01f)
        {
            Vector2 newPosition = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), target,
                speed * Time.deltaTime);
            transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
            yield return null;
        }

        yield return new WaitForSeconds(pauseTime);

        MovePlatform();
    }

}


