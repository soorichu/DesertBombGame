using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{

    public float speed = 10.0F;
    public float rotationSpeed = 100.0F;
    private Animator myAnimator;
    public AudioClip deathClip;

    private void Start()
    {
        myAnimator = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        if (GameManager.instance.isGameover)
        {
            return;
        }

        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        if(translation!=0.0f || rotation != 0.0f) 
        {
            translation *= Time.deltaTime;
            rotation *= Time.deltaTime;
            transform.Translate(0, 0, translation);
            transform.Rotate(0, rotation, 0);

            myAnimator.SetBool("walk", true);
        }
        else
        {
            myAnimator.SetBool("walk", false);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (GameManager.instance.isGameover)
        {
            return;
        }
        if (collision.collider.tag == "Obstacle")
        {
            myAnimator.SetTrigger("damage");
            GameManager.instance.AddScore(-1);
        }

        if(collision.collider.tag == "BadBall")
        {
            myAnimator.SetBool("walk", false);
            myAnimator.SetTrigger("attack01");
            GameManager.instance.OnPlayerDead();
        }

        if(collision.collider.tag == "GoodBall")
        {
            GameManager.instance.AddScore(1);
        }
    }
}
