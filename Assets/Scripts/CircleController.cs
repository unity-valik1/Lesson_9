using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    public GameObject circle;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        circle.SetActive(true);
        Destroy(gameObject);
    }
}
