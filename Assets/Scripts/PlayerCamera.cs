using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] Transform target;
    public float speed = 5;
    void Start()
    {
    }

    void Update()
    {
        float targetX = target.transform.position.x;
        float targetY = target.transform.position.y;
        float targetZ = transform.position.z;

        var playerPosition = new Vector3(targetX, targetY, targetZ);
        transform.position = Vector3.MoveTowards(transform.position, playerPosition, speed * Time.deltaTime);
    }
}
