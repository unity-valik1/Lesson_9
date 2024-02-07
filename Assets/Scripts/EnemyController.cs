using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5f;
    Vector3 pos_1;
    Vector3 pos_2;
    private void Start()
    {
        pos_1 = transform.position;
        pos_2 = pos_1 - new Vector3(-10, 0, 0);
    }
    void Update()
    {
        transform.position = Vector3.Lerp(pos_1, pos_2, Mathf.PingPong(Time.time * speed, 1.0f));
    }
}
