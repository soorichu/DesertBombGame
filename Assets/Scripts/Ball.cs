using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float collisionTime = 0f;
    public float interval = 10f;
    private Rigidbody ballRigidbody;
    void Start()
    {
        interval = Random.Range(7, 15);
        transform.position = new Vector3(Random.Range(-20, 20), 10, Random.Range(-20, 20));
        ballRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (GameManager.instance.isGameover)
        {
            return;
        }
        if (collisionTime!=0f && Time.time >= collisionTime + interval)
        {
            collisionTime = Time.time;
            interval = Random.Range(7, 15);
            ballRigidbody.AddForce(Random.Range(-20, 20), 0, Random.Range(-30, 20));
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        collisionTime = Time.time;
        ballRigidbody.AddForce(Random.Range(-20, 20), 0, Random.Range(-30, 20));

        if (collision.collider.tag == "Player")
        {
            transform.position = new Vector3(40, 1, 60);
        }
    }
}
